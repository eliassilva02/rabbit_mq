using System.Text;
using RabbitMQ.Client;

var fact = new ConnectionFactory() { HostName = "localhost" };

using var conn = fact.CreateConnection();
using var channel = conn.CreateModel();

channel.QueueDeclare(
    queue: "hello",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

const string msg = "Hello World!";

var body = Encoding.UTF8.GetBytes(msg);

channel.BasicPublish(exchange: string.Empty,
                    routingKey: "hello",
                    basicProperties: null,
                    body: body);
Console.WriteLine($" [x] Sent {msg}");

Console.WriteLine(" Press X to exit.");
