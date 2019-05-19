using System;

namespace Server
{
    static class Helper
    {
        public static byte[] ToByteArray(this string obj)
        {
            var byteArray = new byte[obj.Length];
            for (var i = 0; i < obj.Length; i++)
            {
                byteArray[i] = (byte) obj[i];
            }

            return byteArray;
        }

        public static string ToStringRedux(this byte[] obj)
        {
            return BitConverter.ToString(obj).Replace("-", ""); ;
        }
    }
}
