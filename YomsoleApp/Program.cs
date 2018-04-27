using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using YomsoleApp.Utils;

namespace YomsoleApp
{
    class Program
    {
        private static AssemblyName assembly = Assembly.GetExecutingAssembly().GetName();

        #region App exit codes
        // Microsoft convention
        // Full list -> https://msdn.microsoft.com/en-us/library/windows/desktop/ms681382(v=vs.85).aspx
        private const int ERROR_SUCCESS = 0x0;
        private const int ERROR_INVALID_FUNCTION = 0x1;
        #endregion

        static void Main(string[] args)
        {
            string cmd;
            string temp;

            bool cmdMode = args.Length > 0;
            bool hasArgs = args.Length > 1;

        read_next:
            try
            {
                if (cmdMode)
                {
                    cmd = args[0].Trim();
                }
                else
                {
                    Rainbow.WriteColor(ConsoleColor.Yellow, "-> ");
                    cmd = Console.ReadLine().Trim();
                }

                switch (cmd)
                {
                    case "--version":
                        PrintAppVersion();
                        break;

                    case "cls":
                    case "clear":
                        Console.Clear();
                        break;

                    case "today":
                        if (cmdMode && hasArgs && !string.IsNullOrEmpty(args[1]))
                        {
                            temp = DateTime.Now.ToString(args[1]);
                        }
                        else
                        {
                            temp = DateTime.Now.ToLongDateString();
                        }

                        Console.WriteLine(temp);
                        break;

                    case "uptime":
                        using (var eventLog = new EventLog("System", Environment.MachineName, "Winlogon"))
                        {
                            var logs = from e in eventLog.Entries.Cast<EventLogEntry>()
                                       where e.TimeGenerated.Date == DateTime.Today && e.InstanceId == 7001
                                       orderby e.TimeGenerated descending
                                       select e;

                            if (logs.Any())
                            {
                                Console.Write("It's been ");

                                Rainbow.WriteColor(ConsoleColor.Green,
                                    DateTime.Now.Subtract(logs.FirstOrDefault().TimeGenerated).With(up =>
                                       $"{up.Hours}h {up.Minutes}m {up.Seconds}s"
                                    )
                                );

                                Console.WriteLine(" since computer was last (re)started.");
                            }
                        }
                        break;

                    case "shutdown":
                        // Especially for timed shutdown operation.
                        if (cmdMode && hasArgs)
                        {
                            HandleTimedShutdown(args);
                        }
                        break;

                    case "exit":
                        ExitConsole();
                        return;

                    case "":
                        Console.WriteLine();
                        break;

                    default:
                        Warn("invalid command: " + cmd);
                        break;
                }

                if (!cmdMode)
                {
                    if (cmd != "clear" && cmd != "cls")
                    {
                        Console.WriteLine();
                    }

                    goto read_next;
                }
            }
            catch (Exception)
            {
                if (cmdMode)
                {
                    Warn("operation failure");
                    ExitConsole(ERROR_INVALID_FUNCTION);
                }
            }
        }

        /// <summary>
        /// Schedule a Windows shutdown.
        /// </summary>
        /// <param name="args">Takes the first 3 params, ignores the rest.</param>
        private static void HandleTimedShutdown(string[] args)
        {
            if (args.Length == 2)
            {
                double delay = 0D;
                string message;

                if (double.TryParse(args[1], out delay))
                {
                    message = $"Shutting down in {delay} minute(s)".Quote();

                    Shell($"shutdown -s -t {delay * 60} -c {message}");
                }
                else
                {
                    if (args[1] == "abort")
                    {
                        Shell("shutdown -a");
                    }
                }
            }
        }

        private static void ExitConsole() => Environment.Exit(ERROR_SUCCESS);
        private static void ExitConsole(int code) => Environment.Exit(code);

        private static void Warn(string message)
        {
            Rainbow.WriteLineColor(ConsoleColor.Red, $"ERROR: {message}");
        }

        private static void Shell(string command)
        {
            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    Arguments = "/C " + command,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                process.Start();
            }
        }

        private static void PrintAppVersion()
        {
            string version = assembly.Version.With(v => $"v{v.Major}.{v.Minor}.{v.Revision} build {v.Build}");
            int width = version.Length + 6;

            Rainbow.WriteColor(ConsoleColor.Cyan, $@"
     __    __                                     ___              
    /\ \  /\ \                                   /\_ \             
    \ `\`\\/'/  ___     ___ ___      ____    __  \//\ \       __   
     `\ `\ /'  / __`\ /' __` __`\   /',__\  / __`\ \ \ \    /'__`\ 
       `\ \ \ /\ \L\ \/\ \/\ \/\ \ /\__, `\/\ \L\ \ \_\ \_ /\  __/ 
         \ \_\\ \____/\ \_\ \_\ \_\\/\____/\ \____/ /\____\\ \____\
          \/_/ \/___/  \/_/\/_/\/_/ \/___/  \/___/  \/____/ \/____/
");
            Rainbow.WriteLineColor(ConsoleColor.DarkGray, version.PadLeft(width, (char)32));
        }

    }
}
