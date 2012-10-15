namespace CryptoExamples.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class SharedObject
    {
        #region Properties

        public int Algorithm
        {
            get; set;
        }

        public string CipherText
        {
            get; set;
        }

        public bool IsEncrypt
        {
            get; set;
        }

        public string Key
        {
            get; set;
        }

        public int Mode
        {
            get; set;
        }

        public string PlainText
        {
            get; set;
        }

        public string TimeTaken
        {
            get; set;
        }

        public int Type
        {
            get; set;
        }

        #endregion Properties
    }
}