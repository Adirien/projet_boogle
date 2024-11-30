using Microsoft.VisualStudio.TestTools.UnitTesting;
using boogle;
// namespace Company.TestProject1;
namespace boogletest;

    

[TestClass]
public class TestDe
{
    private Alphabet alphabet ;

    public TestDe(){
        this.alphabet = new Alphabet(4);
    }

    [TestMethod]
    public void TestContient2Fois()
    {
        De de = new De();
        de.Add(this.alphabet.DicoLettre["A"]);
        bool is_contient = de.Contient2Fois(this.alphabet.DicoLettre["A"]);
        Console.WriteLine("le de contient il 2 fois la lettre A ? : {0}",is_contient);
    }
}
