using Confluent.Kafka;

Console.WriteLine("Kafka Consumer Chat App");
var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "chat-consumer-group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Null, string>(config).Build();
consumer.Subscribe("chat-topic");

CancellationTokenSource cts = new();
Console.CancelKeyPress += (_, e) => {
    e.Cancel = true;
    cts.Cancel();
};

try
{
    while (true)
    {
        var cr = consumer.Consume(cts.Token);
        Console.WriteLine($"Friend: {cr.Message.Value}");
    }
}
catch (OperationCanceledException)
{
    Console.WriteLine("⛔ Exiting...");
    consumer.Close();
}
