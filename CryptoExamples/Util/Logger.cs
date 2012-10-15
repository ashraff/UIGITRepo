namespace CryptoExamples.Util
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class Logger
    {
        #region Methods

        public static void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static void Log(Type type, string message)
        {
            // Log(type.FullName + ":" + message);
        }

        #endregion Methods
    }
}