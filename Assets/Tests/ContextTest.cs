using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

public class ContextTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ContextTestSimplePasses()
    {
        Assert.IsTrue(true);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ContextTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
        Assert.IsTrue(true);
    }
}
