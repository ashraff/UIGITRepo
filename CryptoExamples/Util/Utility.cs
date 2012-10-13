using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace CryptoExamples.Util
{
    class Utility
    {

        public static string Hex2Binary(string hexString)
        {
            string binaryString = String.Join(String.Empty,
                   hexString.Select(
                       c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                   ));
            return binaryString;
        }


        public static string Binary2Hex(string binaryString)
        {
            string hexString = "";
            for (int i = 0; i <= binaryString.Length - 4; i += 4)
            {
                hexString += string.Format("{0:X}", Convert.ToByte(binaryString.Substring(i, 4), 2));
            }

            return hexString;
        }


        public static string XORBinaryString(string one, string two)
        {
            string output = "";
            for (int i = 0; i < one.Length; i++)
               output+= one[i] ^ two[i];
            return output;
        }

        static public string ShiftLeft(string inputstring, int z_shift)
        {
            string outputstring="";
            int shiftcount = 0;
            for (int i = 0; i < inputstring.Length; i++)
            {
                outputstring += ((i + z_shift) < inputstring.Length) ? inputstring[i + z_shift] : inputstring[shiftcount++];
            }
            return outputstring;
        }


        static public string ShiftRight(string inputstring, int z_shift)
        {
            string outputstring = "";
            int shiftcount = z_shift;
            for (int i = 0; i < inputstring.Length; i++)
            {
                outputstring += (shiftcount != 0) ? inputstring[inputstring.Length - shiftcount--] : inputstring[i - z_shift];
            }
            return outputstring;
        }

        public static string[] String2HexArray(string data,int hexlength)
        {
            return (from str in (Regex.Replace(BitConverter.ToString(Encoding.ASCII.GetBytes(data)).Replace("-", ""), @"(.{" + hexlength + "})", "$1 ").Split(' ')) select str.PadRight(hexlength, '0')).ToArray();           

            
        }
      
    }

    public class Win32
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
    }
}
