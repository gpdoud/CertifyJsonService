using System;
using static System.Diagnostics.Trace;
namespace CertifyJsonService
{
    public static class CommandLineParameters
    {
        private static Dictionary<string, string?>? commandLineParms = null;

        public static void Parse(string[] args)
        {
            commandLineParms = new Dictionary<string, string?>();
            var argStr = string.Join(" ", args);
            var parmArgs = argStr.Split("--").ToList().Skip(1);
            foreach(var arg in parmArgs)
            {
                var kv = arg.Trim().Split(" ");
                commandLineParms.Add(kv[0].ToUpper(), (kv.Length == 1 ? null : kv[1]));
            }
        }

        public static string? Get(string key)
        {
            CheckInitialization();
            key = key.ToUpper();
            if (!Contains(key))
                return null;
            return commandLineParms!.GetValueOrDefault(key);
        }

        public static bool Contains(string key)
        {
            CheckInitialization();
            key = key.ToUpper();
            return commandLineParms!.ContainsKey(key);
        }

        private static void CheckInitialization()
        {
            if (commandLineParms is null)
                throw new NullReferenceException("Not Initialized -- call Parse()");
        }
    }
}

