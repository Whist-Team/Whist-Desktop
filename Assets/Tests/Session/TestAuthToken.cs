using System.Collections.Generic;
using NUnit.Framework;
using Session;

namespace Tests.Session
{
    public class TestAuthToken
    {
        private readonly AuthToken authToken = new AuthToken(tokenString, tokenType);
        private static readonly string tokenString = "abcd";
        private static readonly string tokenType = "Bearer";

        [Test]
        public void TestFromString()
        {
            string result = $"{{\"token\":\"{tokenString}\",\"token_type\":\"{tokenType}\"}}}}";
            AuthToken expectedToken = authToken;

            AuthToken token = AuthToken.FromString(result);
            Assert.AreEqual(expectedToken, token);
        }

        [Test]
        public void TestFromStringMissingType()
        {
            string result = $"{{\"token\":\"{tokenString}\"}}";

            Assert.Throws<KeyNotFoundException>(() => AuthToken.FromString(result));
        }

        [Test]
        public void TestFromStringMissingToken()
        {
            string result = $"{{\"token_type\":\"{tokenType}\"}}";

            Assert.Throws<KeyNotFoundException>(() => AuthToken.FromString(result));
        }

        [Test]
        public void TestEqual()
        {
            AuthToken otherToken = new AuthToken(tokenString, tokenType);
            Assert.AreEqual(authToken, otherToken);
        }

        [Test]
        public void TestNotTokenEqual()
        {
            AuthToken otherToken = new AuthToken("abc", tokenType);
            Assert.AreNotEqual(authToken, otherToken);
        }

        [Test]
        public void TestNotTypeEqual()
        {
            AuthToken otherToken = new AuthToken(tokenString, "Bear");
            Assert.AreNotEqual(authToken, otherToken);
        }

        [Test]
        public void TestNullEqual()
        {
            Assert.AreNotEqual(authToken, null);
        }
    }
}