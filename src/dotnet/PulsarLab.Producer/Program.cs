using DotPulsar;
using DotPulsar.Extensions;
using Serilog;
using Serilog.Templates;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(new ExpressionTemplate("[{UtcDateTime(@t):o} {@l:u3} {SourceContext}] {@m}\n{@x}"))
    .CreateLogger();

Log.Debug("PulsarLab.Producer started");

Log.Debug("Creating Pulsar client");
var client = PulsarClient.Builder()
    .ServiceUrl(new Uri("pulsar://192.168.86.20:6650"))
    .Build();

Log.Debug("Creating Pulsar producer");
var producer = client.NewProducer()
                     .Topic("persistent://acmecode/lab/partitions")
                     .Create();


//var data = Encoding.UTF8.GetBytes("{\"partition\": \"12345\", \"action\": \"DELETE\"}");
//await producer.Send(data);

if (args.Length > 0)
{
    await producer.Send(Encoding.UTF8.GetBytes(args[0]));
}
else
{
    Log.Information("No message specified");
}

Log.Debug("PulsarLab.Producer ended");

Log.CloseAndFlush();