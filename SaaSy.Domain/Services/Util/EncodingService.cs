using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaaSy.Domain.Services.Util
{
    public class EncodingService : IEncodingService
    {
        //TODO: use two arrays so we can convert negative values as well. Need to map "-" to a letter;
        private readonly string[] letters = { "a", "c", "e", "h", "j", "k", "i", "f", "d", "b" };

        public EncodingService()
        {

        }

        /// <summary>
        /// Convert a non-negative int to a string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string IntToAlpha(int value)
        {
            var intList = value.ToString().Select(c => (int)Char.GetNumericValue(c));
            return string.Join<string>("", intList.Select(i => letters[i]));
        }

        /// <summary>
        /// Convert a string to a non-negative int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AlphaToInt(string value)
        {
            var strList = value.Select(c => Array.IndexOf(letters, c.ToString()).ToString());
            return Convert.ToInt32(string.Join<string>("", strList));
        }

        /// <summary>
        /// Convert a string to Base64 encoding
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Convert Base64 encoded text back to plain text
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
