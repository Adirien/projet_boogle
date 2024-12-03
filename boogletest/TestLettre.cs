using boogle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace Company.TestProject1;
namespace boogletest;

[TestClass]
public class TestLettre
{
    [TestMethod]
    public void TestToString()
    {
        Lettre lettre = new Lettre("A",5,9);
        lettre.NbApparition = 8;
        Assert.AreEqual("A-> frequence: 9, nbApparition: 8",lettre.ToString());
    }
}
