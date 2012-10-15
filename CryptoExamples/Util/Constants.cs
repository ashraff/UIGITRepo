namespace CryptoExamples.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Constants
    {
        #region Fields

        public static Dictionary<int, string> DES_MODES = new Dictionary<int, string>()
         {
            {0,"Electronic Code Book (ECB)"},
            {1,"Cipher Block Chaining (CBC)"},
            {2,"Cipher Feedback (CFB)"},
         };
        public static Dictionary<int, string> SKC_ALOGRITHMS = new Dictionary<int, string>()
        {   {0,""},
            {1,"Data Encryption Standard (DES)"},
            {2,"Triple-DES(3DES)"},
            {3,"DESX"},
            {4,"Advanced Encryption Standard (AES)"},
            {5,"CAST-128"},
            {6,"CAST-256"},
            {7,"International Data Encryption Algorithm (IDEA)"},
            {8,"Rivest Ciphers (aka Ron's Code) - RC1"},
            {9,"Rivest Ciphers (aka Ron's Code) - RC2"},
            {10,"Rivest Ciphers (aka Ron's Code) - RC3"},
            {11,"Rivest Ciphers (aka Ron's Code) - RC4"},
            {12,"Rivest Ciphers (aka Ron's Code) - RC5"},
            {13,"Rivest Ciphers (aka Ron's Code) - RC6"},
            {14,"Blowfish"},
            {15,"Twofish"},
            {16,"Camellia"},
            {17,"MISTY1"},
            {18,"Secure and Fast Encryption Routine (SAFER"},
            {19,"KASUMI"},
            {20,"SEED"},
            {21,"ARIA"},
            {22,"CLEFIA"},
            {23,"SMS4"},
            {24,"Skipjack"}
        };

        #endregion Fields
    }
}