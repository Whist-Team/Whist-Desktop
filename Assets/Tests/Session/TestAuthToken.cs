using System.Collections.Generic;
using NUnit.Framework;
using Session;

namespace Tests.Session
{
    public class TestAuthToken
    {
        [Test]
        public void TestFromString()
        {
            string result = "{\"token\":\"abcd\",\"token_type\":\"Bearer\"}";
            AuthToken expectedToken = new AuthToken("abcd", "Bearer");

            AuthToken token = AuthToken.FromString(result);
            Assert.AreEqual(expectedToken, token);
        }

        [Test]
        public void TestFromStringMissingType()
        {
            string result = "{\"token\":\"abcd\"}";

            Assert.Throws<KeyNotFoundException>(() => AuthToken.FromString(result));
        }

        [Test]
        public void TestFromStringMissingToken()
        {
            string result = "{\"token_type\":\"Bearer\"}";

            Assert.Throws<KeyNotFoundException>(() => AuthToken.FromString(result));
        }

        [Test]
        public void TestEqual()
        {
            AuthToken authToken = new AuthToken("abcd", "Bearer");
            AuthToken otherToken = new AuthToken("abcd", "Bearer");
            Assert.AreEqual(authToken, otherToken);
        }

        [Test]
        public void TestNotTokenEqual()
        {
            AuthToken authToken = new AuthToken("abcd", "Bearer");
            AuthToken otherToken = new AuthToken("abc", "Bearer");
            Assert.AreNotEqual(authToken, otherToken);
        }

        [Test]
        public void TestNotTypeEqual()
        {
            AuthToken authToken = new AuthToken("abcd", "Bearer");
            AuthToken otherToken = new AuthToken("abcd", "Bear");
            Assert.AreNotEqual(authToken, otherToken);
        }

        [Test]
        public void TestNullEqual()
        {
            AuthToken authToken = new AuthToken("abcd", "Bearer");
            Assert.AreNotEqual(authToken, null);
        }

        [Test]
        public void TestToString()
        {
            AuthToken authToken = new AuthToken("abcd", "Bearer");
            Assert.AreEqual("Bearer abcd", authToken.ToString());
        }
    }
}