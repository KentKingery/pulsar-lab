using DotPulsar;
using DotPulsar.Extensions;
using Serilog;
using Serilog.Templates;
using System.Buffers;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(new ExpressionTemplate("[{UtcDateTime(@t):o} {@l:u3} {SourceContext}] {@m}\n{@x}"))
    .CreateLogger();

Log.Debug("PulsarLab.Consumer started");

Log.Debug("Creating Pulsar client");
var client = PulsarClient.Builder()
    .ServiceUrl(new Uri("pulsar://192.168.86.20:6650"))
    .Build();

Log.Debug("Creating Pulsar consumer");
var consumer = client.NewConsumer()
                     .SubscriptionName("dotnet-consumer")
                     .Topic("persistent://acmecode/lab/general.notify")
                     .Create();

await foreach (var message in consumer.Messages())
{
    Log.Debug("Message received: " + Encoding.UTF8.GetString(message.Data.ToArray()));
    Log.Debug("Acknowledging message");
    await consumer.Acknowledge(message);
}

Log.Debug("PulsarLab.Consumer ended");

Console.ReadKey();
Log.CloseAndFlush();