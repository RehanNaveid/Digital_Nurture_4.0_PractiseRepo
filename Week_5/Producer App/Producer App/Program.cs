using Confluent.Kafka;

Console.WriteLine("Kafka Producer Chat App");
var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<Null, string>(config).Build();

while (true)
{
    Console.Write("You: ");
    var message = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(message)) break;

    var result = await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
    Console.WriteLine($"[✔] Sent to Partition {result.Partition}, Offset: {result.Offset}");
}
