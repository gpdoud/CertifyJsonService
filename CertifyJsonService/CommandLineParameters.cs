using System;
using static System.Diagnostics.Trace;
namespace CertifyJsonService
{
    public static class CommandLineParameters
    {
        public static IDictionary<string, string?> ParseCommandLinesParameters(string[] args)
        {
            Dictionary<string, string?> commandLineParms = new();
            var argStr = string.Join(" ", args);
            var parmArgs = argStr.Split("--").ToList().Skip(1);
            foreach(var arg in parmArgs)
            {
                var kv = arg.Trim().Split(" ");
                commandLineParms.Add(kv[0], (kv.Length == 1 ? null : kv[1]));
            }
            return commandLineParms;
        }
    }
}

