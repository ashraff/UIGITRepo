namespace CryptoExamples.DES
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using CryptoExamples.Util;

    class DESAlgorithm
    {
        #region Methods

        public SharedObject decrypt(SharedObject inputObject)
        {
            string[] subKeys = createSubkeys(Utility.String2HexArray(inputObject.Key, 16)[0]);
            Array.Reverse(subKeys);

            /* Convert the string into hexadecimal form and split it as 16 character hex.
             * If the splitted string is not of 16 character it right pads with 0 */
            string[] hexDataArray = Regex.Replace(inputObject.CipherText, @"(.{16})", "$1 ").Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            /* To Test hexDataArray = new string[]{"0123456789ABCDEF"};*/

            string decryptedData = "";
            string decryptedBlock = "";
            string inputVector = "";
            for (int i = 0; i < hexDataArray.Length; i++)
            {
              decryptedBlock = encodeData(hexDataArray[i], subKeys);
              if (inputObject.Mode == 1)
              {
                  if (i == 0)
                  {
                      inputVector = Utility.String2HexArray(inputObject.InputVector, 16)[0];
                      decryptedBlock = Utility.XORBinaryString(Utility.Hex2Binary(decryptedBlock), Utility.Hex2Binary(inputVector));
                  }
                  else
                      decryptedBlock = Utility.XORBinaryString(Utility.Hex2Binary(hexDataArray[i-1]), Utility.Hex2Binary(decryptedBlock));
              }

              decryptedData += Utility.Binary2Hex(decryptedBlock);
            }

            SharedObject resultObject = new SharedObject();
            resultObject.PlainText = Utility.Hex2String(decryptedData);
            resultObject.CipherText = inputObject.PlainText;

            Logger.Log(this.GetType(), "Decrypted Data" + decryptedData);
            return resultObject;
        }

        public SharedObject encrypt(SharedObject inputObject)
        {
            string[] subKeys = createSubkeys(Utility.String2HexArray(inputObject.Key, 16)[0]);

            /* Convert the string into hexadecimal form and split it as 16 character hex.
             * If the splitted string is not of 16 character it right pads with 0 */
            string[] hexDataArray = Utility.String2HexArray(inputObject.PlainText, 16);

            string encryptedData = "";
            string encyptedBlock = "";
            string inputVector = "";
            
            for (int i = 0; i < hexDataArray.Length; i++)
            {  
                    if (inputObject.Mode == 1)
                    {
                        if (i == 0)
                        {
                            inputVector = Utility.String2HexArray(inputObject.InputVector, 16)[0];
                            hexDataArray[i] = Utility.Binary2Hex(Utility.XORBinaryString(Utility.Hex2Binary(hexDataArray[i]),Utility.Hex2Binary(inputVector)));
                        }
                        else hexDataArray[i] = Utility.Binary2Hex(Utility.XORBinaryString(Utility.Hex2Binary(hexDataArray[i]), Utility.Hex2Binary(encyptedBlock))); 
                    }
                    encyptedBlock = encodeData(hexDataArray[i], subKeys);
                    encryptedData += encyptedBlock;
            }
            SharedObject resultObject = new SharedObject();
            resultObject.PlainText = inputObject.PlainText;
            resultObject.CipherText = encryptedData;
            resultObject.InputVector = Utility.Hex2String(inputVector);
            Logger.Log(this.GetType(), "Encrypted Data" + encryptedData);
            return resultObject;
        }

        private string applyFeistelFunction(string L, string R, string K)
        {
            /* EXPANSION */
            string expandedString = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    expandedString += R[DESConstats.EXPANSION_FUNCTION[i, j] - 1];
                }
            }
            Logger.Log(this.GetType(), "Expanded String - " + Regex.Replace(expandedString, @"(.{6})", "$1 "));

            /* KEY MIXING */
            expandedString = Utility.XORBinaryString(K, expandedString);

            Logger.Log(this.GetType(), "Key Mixed String - " + Regex.Replace(expandedString, @"(.{6})", "$1 "));

            /* SUBTITUTION */
            string[] expandedStringArray = Regex.Replace(expandedString, @"(.{6})", "$1 ").Split(' ');
            int rowNo = -1,colNo=-1;
            expandedString = "";
            for(int i = 0;i<8;i++)
            {
                 rowNo = Convert.ToInt32("" + expandedStringArray[i][0] + expandedStringArray[i][5], 2);
                 colNo = Convert.ToInt32("" + expandedStringArray[i].Substring(1,4), 2);
                 expandedString += Convert.ToString(DESConstats.SBOXES[i, rowNo, colNo], 2).PadLeft(4, '0');
            }

            Logger.Log(this.GetType(), "Substituted String - " + Regex.Replace(expandedString, @"(.{4})", "$1 "));

            /* PERMUTATION */
            string permutedString = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    permutedString += expandedString[DESConstats.PERMUTATION[i, j] - 1];
                }
            }
            Logger.Log(this.GetType(), "Permuted String - " + Regex.Replace(permutedString, @"(.{4})", "$1 "));

            permutedString = Utility.XORBinaryString(L, permutedString);

            Logger.Log(this.GetType(), "L0 + f(R0 , K1) String - " + Regex.Replace(permutedString, @"(.{4})", "$1 "));
            return permutedString;
        }

        private string[] createSubkeys(string key)
        {
            Logger.Log(this.GetType(), "KEY is - " + key);
            string binaryString = Utility.Hex2Binary(key);

            Logger.Log(this.GetType(), "Binary Form of KEY is - " + Regex.Replace(binaryString, @"(.{8})", "$1 "));

            /*
             * Create the 56-bit permutation using the PC-1
             * The 64-bit key is permuted according to the DESConstats.PERMUTED_CHOICE_ONE.
             * Since the first entry in the table is "57", this means that the 57th
             * bit of the original key K becomes the first bit of the permuted key K+.
             * The 49th bit of the original key becomes the second bit of the permuted key.
             * The 4th bit of the original key is the last bit of the permuted key. Note only
             * 56 bits of the original key appear in the permuted key.
             */
            string permutedString = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    permutedString += binaryString[DESConstats.PERMUTED_CHOICE_ONE[i, j] - 1];
                }
            }
            Logger.Log(this.GetType(), "Permuted Form 1 of KEY is - " + Regex.Replace(permutedString, @"(.{7})", "$1 "));

            string[] C = new string[17];
            string[] D = new string[17];

            /* Split the key into left and right halves, C0 and D0, where each half has 28 bits */
            C[0] = permutedString.Substring(0, 28);
            D[0] = permutedString.Substring(28);

            Logger.Log(this.GetType(), "Split Key C0 - " + Regex.Replace(C[0], @"(.{7})", "$1 "));
            Logger.Log(this.GetType(), "Split Key D0 - " + Regex.Replace(D[0], @"(.{7})", "$1 "));

            /* Left shift the key block's using the KEY_SCHEDULE_ROTATION and create 16 sub key halves */
            for (int i = 0; i < 16; i++)
            {
                C[i + 1] = Utility.ShiftLeft(C[i], DESConstats.KEY_SCHEDULE_ROTATION[i, 1]);
                D[i + 1] = Utility.ShiftLeft(D[i], DESConstats.KEY_SCHEDULE_ROTATION[i, 1]);

                Logger.Log(this.GetType(), "Split Key C[" + (i + 1) + "] - " + Regex.Replace(C[i + 1], @"(.{7})", "$1 "));
                Logger.Log(this.GetType(), "Split Key D[" + (i + 1) + "] - " + Regex.Replace(D[i + 1], @"(.{7})", "$1 "));
            }

            /* Apply the second permutation table on the 32 halves we created and get the 16 Subkeys */
            string[] subKeys = new string[16];
            for (int k = 1; k < 17; k++)
            {
                permutedString = "";
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (DESConstats.PERMUTED_CHOICE_TWO[i, j] <= 28)
                            permutedString += C[k][DESConstats.PERMUTED_CHOICE_TWO[i, j] - 1];
                        else permutedString += D[k][DESConstats.PERMUTED_CHOICE_TWO[i, j] - 29];
                    }
                }
                subKeys[k - 1] = permutedString;
                Logger.Log(this.GetType(), "Permuted Form 2 of KEY is - " + Regex.Replace(subKeys[k - 1], @"(.{6})", "$1 "));
            }

            return subKeys;
        }

        private string encodeData(string data,string[] K)
        {
            string binaryString = Utility.Hex2Binary(data);
            Logger.Log(this.GetType(), "Binary Form of M is - " + Regex.Replace(binaryString, @"(.{4})", "$1 "));
            string permutedString = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    permutedString += binaryString[DESConstats.INITAL_PERMUTATION[i, j] - 1];
                }
            }

            Logger.Log(this.GetType(), "Permuted Form of M is - " + Regex.Replace(permutedString, @"(.{4})", "$1 "));

            string[] L = new string[17];
            string[] R = new string[17];

            /* Split the key into left and right halves, C0 and D0, where each half has 28 bits */
            L[0] = permutedString.Substring(0, 32);
            R[0] = permutedString.Substring(32);

            Logger.Log(this.GetType(), "Split Data L0 - " + Regex.Replace(L[0], @"(.{4})", "$1 "));
            Logger.Log(this.GetType(), "Split Data R0 - " + Regex.Replace(R[0], @"(.{4})", "$1 "));

            /* Need to Change to 16 */
            for (int i = 0; i < 16; i++)
            {
                L[i + 1] = R[i];
                R[i + 1] = applyFeistelFunction(L[i],R[i],K[i]);

            }

            Logger.Log(this.GetType(), "Permuted Data L16 - " + Regex.Replace(L[16], @"(.{4})", "$1 "));
            Logger.Log(this.GetType(), "Permuted Data R16 - " + Regex.Replace(R[16], @"(.{4})", "$1 "));

            permutedString = R[16] + L[16];

            string resultString = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    resultString += permutedString[DESConstats.FINAL_PERMUTATION[i, j] - 1];
                }
            }

            Logger.Log(this.GetType(), "Final Permuated Data  - " + Regex.Replace(resultString, @"(.{8})", "$1 "));
            return Utility.Binary2Hex(resultString);
        }

        #endregion Methods
    }
}