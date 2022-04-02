using System;
using System.Collections.Generic;

namespace FoxToolKit.Bytes
{
    /// 字节帮助类
    /// </summary>
    public class ByteHelper
    {
        /// <summary>
        /// 字节数组转为16进制字符串
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>16进制字符串</returns>
        public static string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;
            for (int i = 0; i < bytes.Length; i++)
            {
                hexString += ByteToHexStr(bytes[i]);
            }

            return hexString;
        }

        /// <summary>
        /// 字节转为16进制字符串（一个字节转为两个字符：[0-F][0-F]）
        /// </summary>
        /// <param name="inByte">字节</param>
        /// <returns>字符串</returns>
        public static string ByteToHexStr(byte inByte)
        {
            string result = string.Empty;
            try
            {
                char[] hexDict = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
                char[] charParts = new char[2];
                charParts[0] = hexDict[(inByte >> 4) & 0x0F]; //放在byte左半部分的重新移回右边并匹配十六进制字符;
                charParts[1] = hexDict[inByte & 0x0F];        //放在byte右半部分的直接匹配十六进制字符;
                result = new string(charParts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }

        /// <summary>
        /// 十六进制字符串转为字节数组
        /// </summary>
        /// <param name="hexStr">十六进制字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] HexStrToBytes(string hexStr)
        {
            /* 说明：1byte=8bit，中文char=2byte(此处不考虑)，英文char=1byte，
             1个“个位”的十六进制数占4bit，所以2个英文char转为十六进制数后占一个byte */
            byte[] bytes = new byte[hexStr.Length / 2 + (((hexStr.Length % 2) > 0) ? 1 : 0)];
            for (int i = 0; i < bytes.Length; i++)
            {
                char leftPart = hexStr[i * 2];
                char rightPart;

                if ((i * 2 + 1) < hexStr.Length)
                    rightPart = hexStr[i * 2 + 1];
                else
                    rightPart = '0';

                int a = ByteToHexValue((byte)leftPart);
                int b = ByteToHexValue((byte)rightPart);
                //由于16进制数的'个位'数只占4bit，所以左部分左移4位，加上右部分，共占8位，即一个byte;
                bytes[i] = (byte)((a << 4) + b);
            }

            return bytes;
        }

        /// <summary>
        /// 转换字节（实际为英文char）为16进制数据（0-15）
        /// </summary>
        /// <param name="b">字节</param>
        /// <returns>字节</returns>
        public static byte ByteToHexValue(byte b)
        {
            byte value = 0;

            if (b >= '0' && b <= '9')
            {
                //原值在ASCII中介于'0'-'9'之间的：减去0x30，即ASCII中'0'的十六进制表示（十进制为48），得到数值0-9。
                value = (byte)(b - 0x30);
            }

            if (b >= 'A' && b <= 'F')
            {
                //原值在ASCII中介于'A'-'F'之间的：减去0x37，十进制为55，‘A’的ASCII十进制为65，所以可得到数值10-15。
                value = (byte)(b - 0x37);
            }

            if (b >= 'a' && b <= 'f')
            {
                //原值在ASCII中介于'a'-'f'之间的：减去0x57，十进制为87，‘a’的ASCII十进制为97，所以可得到数值10-15。
                value = (byte)(b - 0x57);
            }

            return value;
        }

        /// <summary>
        /// 区块字符串数据转为区块字节数据（不足则补位：16字节）
        /// </summary>
        /// <param name="blockData">区块字符串数据</param>
        /// <returns>List<byte></returns>
        public static List<byte> GetBlockBytes(string blockData)
        {
            List<byte> blockBytes = new List<byte>();
            blockBytes.AddRange(HexStrToBytes(blockData));
            if (blockBytes.Count < 16)
            {
                for (int i = blockBytes.Count; i < 16; i++)
                {
                    blockBytes.Add(0x00);
                }
            }

            return blockBytes;
        }
    }
}
