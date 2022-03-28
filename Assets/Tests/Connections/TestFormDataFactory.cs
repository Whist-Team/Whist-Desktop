using System.Collections.Generic;
using Connections;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Connections
{
    public class TestFormDataFactory
    {
        [Test]
        public void CreationTest()
        {
            Dictionary<string, string> loginDict = new Dictionary<string, string>
            {
                { "username", "marcel" },
                { "password", "pwd" }
            };

            WWWForm expectedForm = new WWWForm();
            expectedForm.AddField("username", "marcel");
            expectedForm.AddField("password", "pwd");
            WWWForm form = FormDataFactory.Create(loginDict);
            Assert.AreEqual(expectedForm.data, form.data);
        }
    }
}