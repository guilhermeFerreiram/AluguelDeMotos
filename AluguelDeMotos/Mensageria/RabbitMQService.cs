using RabbitMQ.Client;
using System.Text;

namespace AluguelDeMotos.Mensageria
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq_container" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "aluguel_de_motos",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        public void PostMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "",
                                  routingKey: "aluguel_de_motos",
                                  basicProperties: null,
                                  body: body);
        }

        ~RabbitMQService()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
