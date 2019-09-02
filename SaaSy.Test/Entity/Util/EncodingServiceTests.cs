using SaaSy.Domain.Services.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SaaSy.Test.Entity.Util
{
    public class EncodingServiceTests
    {
        private readonly string[] letters = { "a", "c", "e", "h", "j", "k", "i", "f", "d", "b" };
        [Fact]
        public void IntToAlpha()
        {
            var service = new EncodingService();
            Assert.Equal(letters[0], service.IntToAlpha(0));
            Assert.Equal(letters[1], service.IntToAlpha(1));
            Assert.Equal(letters[2], service.IntToAlpha(2));
            Assert.Equal(letters[3], service.IntToAlpha(3));
            Assert.Equal(letters[4], service.IntToAlpha(4));
            Assert.Equal(letters[5], service.IntToAlpha(5));
            Assert.Equal(letters[6], service.IntToAlpha(6));
            Assert.Equal(letters[7], service.IntToAlpha(7));
            Assert.Equal(letters[8], service.IntToAlpha(8));
            Assert.Equal(letters[9], service.IntToAlpha(9));
        }

        [Fact]
        public void AlphaToInt()
        {
            var service = new EncodingService();
            Assert.Equal(0, service.AlphaToInt(letters[0]));
            Assert.Equal(1, service.AlphaToInt(letters[1]));
            Assert.Equal(2, service.AlphaToInt(letters[2]));
            Assert.Equal(3, service.AlphaToInt(letters[3]));
            Assert.Equal(4, service.AlphaToInt(letters[4]));
            Assert.Equal(5, service.AlphaToInt(letters[5]));
            Assert.Equal(6, service.AlphaToInt(letters[6]));
            Assert.Equal(7, service.AlphaToInt(letters[7]));
            Assert.Equal(8, service.AlphaToInt(letters[8]));
            Assert.Equal(9, service.AlphaToInt(letters[9]));
        }

        [Fact]
        public void AlphaIntAlpha()
        {
            var service = new EncodingService();
            var number = 1234567890;
            var text = service.IntToAlpha(number);
            var newNumber = service.AlphaToInt(text);
            Assert.Equal(number, newNumber);

            number = Int32.MaxValue;
            text = service.IntToAlpha(number);
            newNumber = service.AlphaToInt(text);
            Assert.Equal(number, newNumber);
        }

        [Fact]
        public void Base64()
        {
            var service = new EncodingService();
            var test = "this is a string with numbers 123123";
            var base64 = service.Base64Encode(test);
            var text = service.Base64Decode(base64);
            Assert.Equal(test, text);
        }
    }
}
