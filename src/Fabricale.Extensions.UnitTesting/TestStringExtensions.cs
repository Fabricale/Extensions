namespace Fabricale.Extensions.UnitTesting
{
    [TestClass]
    public sealed class TestStringExtensions
    {
        [TestMethod]
        public void SimpleFindReplace()
        {
            var originalString = "Server={$this.Server},User={$this.User},Encoding=UTF8";

            var result = originalString.MultiReplace(new MultiReplaceOptions("{$this.Server}", "SERVER01"),
                                                     new MultiReplaceOptions("{$this.User}", "VERO"));

            Assert.AreEqual("Server=SERVER01,User=VERO,Encoding=UTF8", result);
        }

        [TestMethod]
        public void MultipleInstancesSameString()
        {
            var originalString = "Test ABCDE Test ABCDE Test ABCDE Test ABCDE Test ABCDE Test ABCDE";
            var result = originalString.MultiReplace(new MultiReplaceOptions("ABCDE", "FGHIJKL"),
                                                     new MultiReplaceOptions("Test", "Tested"));

            Assert.AreEqual("Tested FGHIJKL Tested FGHIJKL Tested FGHIJKL Tested FGHIJKL Tested FGHIJKL Tested FGHIJKL", result);
        }

        [TestMethod]
        public void CaseSensitive()
        {
            var originalString = "test ABCDE test ABCDE Test ABCDE test ABCDE Test ABCDE Test ABCDE";
            var result = originalString.MultiReplace(new MultiReplaceOptions("ABCDE", "FGHIJKL"),
                                                     new MultiReplaceOptions("Test", "TESTED"));

            Assert.AreEqual("TESTED FGHIJKL TESTED FGHIJKL TESTED FGHIJKL TESTED FGHIJKL TESTED FGHIJKL TESTED FGHIJKL", result);
        }
    }
}
