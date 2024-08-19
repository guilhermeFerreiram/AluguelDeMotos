//A visibilidade das mensagens recebidas fica prejudicada por conta do Docker estar rodando varias aplicações ao mesmo tempo.

using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory { HostName = "rabbitmq_container" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "aluguel_de_motos",
             durable: false,
             exclusive: false,
             autoDelete: false,
             arguments: null);

while (true)
{
    Console.WriteLine(" [*] Esperando mensagens.");

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($" [x] Recebida: {message}");
    };
    channel.BasicConsume(queue: "aluguel_de_motos",
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Digite 'sair' para fechar o app, ou [ENTER] para continuar.");
    var s = Console.ReadLine();
    if (s == "sair") break;
}