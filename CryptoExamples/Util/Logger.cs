using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CryptoExamples.Util
{
    public class Logger
    {
        
        public static void Log(string message)
        {
            Console.WriteLine(message);                       
        }

        public static void Log(Type type, string message)
        {
            // Log(type.FullName + ":" + message);
        }
    }
}
