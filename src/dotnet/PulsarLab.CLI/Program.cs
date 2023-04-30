// See https://aka.ms/new-console-template for more information
using PulsarLab.CLI;
using System.Security.Cryptography.X509Certificates;
using System.Text;

HandleArgs(args);

Console.ReadKey();

static void HandleArgs(string[] args)
{

    if (args.Length == 0)
    {
        ShowHelp();
    }
    else if (args[0] == "broker")
    {
        Pulsar.ListBrokers();
    }
    else if (args[0] == "tenant")
    {
        Pulsar.ListTenants();
    }
    else if (args[0] == "version")
    {
        ShowShortVersion();
    }
    else if (args[0] == "--version")
    {
        ShowLongVersion();
    }
}

static void ShowHelp()
{
    StringBuilder help = new StringBuilder();

    help.AppendLine(@"    ____        __                   ________    ____");
    help.AppendLine(@"   / __ \__  __/ /________ ______   / ____/ /   /  _/");
    help.AppendLine(@"  / /_/ / / / / / ___/ __ `/ ___/  / /   / /    / /  ");
    help.AppendLine(@" / ____/ /_/ / (__  ) /_/ / /     / /___/ /____/ /   ");
    help.AppendLine(@"/_/    \__,_/_/____/\__,_/_/      \____/_____/___/   ");
    help.AppendLine();
    help.AppendLine(@"Welcome to the Pulsar CLI!");
    help.AppendLine();
    help.AppendLine(@"Use 'az --version' to display the current version.");
    help.AppendLine(@"Here are the base commands:");
    help.AppendLine();
    //                1=========2=========3=========4=========5=========6=========7=========8=========
    help.AppendLine(@"version          : Show the versions of Pulsar CLI modules and extensions");
    help.AppendLine(@"                   in JSON format                                        ");

    Console.Write( help );
}

static void ShowLongVersion()
{
    StringBuilder help = new StringBuilder();

    help.AppendLine(@"    ____        __                   ________    ____");
    help.AppendLine(@"   / __ \__  __/ /________ ______   / ____/ /   /  _/");
    help.AppendLine(@"  / /_/ / / / / / ___/ __ `/ ___/  / /   / /    / /  ");
    help.AppendLine(@" / ____/ /_/ / (__  ) /_/ / /     / /___/ /____/ /   ");
    help.AppendLine(@"/_/    \__,_/_/____/\__,_/_/      \____/_____/___/   ");
    help.AppendLine();
    help.AppendLine(@"This is a basic help file.");
    help.AppendLine(@"I wonder what this does.");

    Console.Write(help);
}

static void ShowShortVersion()
{
    StringBuilder help = new StringBuilder();

    help.AppendLine(@"    ____        __                   ________    ____");
    help.AppendLine(@"   / __ \__  __/ /________ ______   / ____/ /   /  _/");
    help.AppendLine(@"  / /_/ / / / / / ___/ __ `/ ___/  / /   / /    / /  ");
    help.AppendLine(@" / ____/ /_/ / (__  ) /_/ / /     / /___/ /____/ /   ");
    help.AppendLine(@"/_/    \__,_/_/____/\__,_/_/      \____/_____/___/   ");
    help.AppendLine();
    help.AppendLine(@"This is a basic help file.");
    help.AppendLine(@"I wonder what this does.");

    Console.Write(help);
}