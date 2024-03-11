using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Auth.Service.Interface;
using IModel = RabbitMQ.Client.IModel;

namespace VistaBasket.Auth.Service.Service
{
    public class MessageBus: IMessageBus
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private string connectionString = "amqp://guest:guest@host.docker.internal:5672/";

        public MessageBus(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                //HostName = _configuration["RabbitMqHost"],
                //Port = int.Parse(_configuration["RabbitMqPort"]),
                //UserName = "guest",
                //Password = "guest",
                Uri = new Uri(connectionString)
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionSutdown;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void RabbitMQ_ConnectionSutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("RabbitMq connection shutdown");
        }

        public async Task publishMessage()
        {


            var message = new { Name = "Producer", Messgae = "Hello" };
            //var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            if (_connection.IsOpen)
            {
                Console.WriteLine("RabbitMQ connection opened");
            }
            else
            {
                Console.WriteLine("RabbitMQ Connection is closed");
            }
            SendMessage(JsonConvert.SerializeObject(message));
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);
            Console.WriteLine("We have sent message");
        }

    }
}
