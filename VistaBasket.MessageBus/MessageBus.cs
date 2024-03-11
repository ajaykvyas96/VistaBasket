
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Net.Http.Headers;
using System.Text;

namespace VistaBasket.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private string connectionString = "amqp://guest:guest@rabbitmq:5672/";

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

        public void Dispose()
        {
            Console.WriteLine("MessageBus disposed");
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }
        public async Task PublishMessageAsync(string message)
        {
            try
            {
                var factory = new ConnectionFactory() { Uri = new Uri("amqp://guest:guest@localhost:5672") }; // replace with your RabbitMQ server details

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    // Declare a queue
                    channel.QueueDeclare(queue: "demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                    // Convert the message to bytes
                    var body = Encoding.UTF8.GetBytes(message);

                    // Publish the message to the queue
                    channel.BasicPublish(exchange: "", routingKey: "demo-queue", basicProperties: null, body: body);

                    Console.WriteLine($" [x] Sent {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Message sent successfully.");
        }
    }
}
