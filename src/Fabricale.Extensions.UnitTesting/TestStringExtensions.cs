namespace Fabricale.Extensions.UnitTesting
{
    [TestClass]
    public sealed class TestStringExtensions
    {
        // ======================================================================
        // Find / Replace
        // ======================================================================

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

        // ======================================================================
        // Contains Only
        // ======================================================================

        private const string LETTERS_LOWER_CASE = "abcdefghijklmnopqrstuvwxyz";
        private const string LETTERS_UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        [TestMethod]
        [DataRow("Test", LETTERS_LOWER_CASE, true, true)]
        [DataRow("Test", LETTERS_LOWER_CASE, false, false)]
        [DataRow("test", LETTERS_LOWER_CASE, false, true)]
        [DataRow("TEST", LETTERS_LOWER_CASE, true, true)]
        [DataRow("TEST", LETTERS_UPPER_CASE, false, true)]
        [DataRow("TeSt", LETTERS_UPPER_CASE, false, false)]
        public void ContainsOnly_Simple(string input, string allowedCharacters, bool ignoreCase, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, input.ContainsOnly(allowedCharacters, ignoreCase));
        }

        [TestMethod]
        [DataRow("0123456789", true)]
        [DataRow("a0123456789", false)]
        [DataRow("Test", false)]
        public void ContainsOnlyNumbers_Simple(string input, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, input.ContainsOnlyNumbers());
        }

        [TestMethod]
        [DataRow("ABCDEabcde", true)]
        [DataRow("abjsaflka99", false)]
        [DataRow("AabBjasafdsa", true)]
        [DataRow("!@%$4ABCDE", false)]
        public void ContainsOnlyAsciiLetters_Simple(string input, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, input.ContainsOnlyAsciiLetters());
        }

        [TestMethod]
        [DataRow("ABCDEabcde", true)]
        [DataRow("abjsaflka99", true)]
        [DataRow("AabBjasafdsa", true)]
        [DataRow("lfads lksadf !2", false)]
        public void ContainsOnlyAsciiLettersAndNumbers_Simple(string input, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, input.ContainsOnlyAsciiLettersAndNumbers());
        }
    }
}
