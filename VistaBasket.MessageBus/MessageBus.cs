
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

        public MessageBus(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMqHost"],
                Port = int.Parse(_configuration["RabbitMqPort"])
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
            }
            catch(Exception ex)
            {

            }
        }
        private string connectionString = "amqp://guest:guest@localhost:5672";

        public async Task publishMessage()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(connectionString)
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("demo-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var message = new { Name = "Producer", Messgae = "Hello" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("", "demo-queue", null, body);
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
