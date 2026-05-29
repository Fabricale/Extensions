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

        // ======================================================================
        // Contains Only (ASCII Performance Implementation)
        // ======================================================================

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

        [TestMethod]
        public void ContainsOnly_InvalidArraySize()
        {
            // The ASCII functions require the array to have 128 positions. Anything different than that should throw an error.
            var boolArray = new bool[127];

            boolArray['A'] = true; // 65
            boolArray['a'] = true; // 97

            var input = "Aa";

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => input.ContainsOnly(boolArray));
        }

        // ======================================================================
        // Contains Only (Unicode Testing)
        // ======================================================================

        private const string RUSSIAN_ALPHABET = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя«»";

        [TestMethod]
        [DataRow("дом", RUSSIAN_ALPHABET, true, true)]
        [DataRow("кот", RUSSIAN_ALPHABET, true, true)]
        [DataRow("«собаку»", RUSSIAN_ALPHABET, true, true)]
        [DataRow("'собаку'", RUSSIAN_ALPHABET, true, false)]
        public void ContainsOnly_Unicode_Simple(string input, string allowedCharacters, bool ignoreCase, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, input.ContainsOnly(allowedCharacters, ignoreCase));
        }

        [TestMethod]
        public void ContainsOnly_Unicode_WithAsciiFunctions()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => RUSSIAN_ALPHABET.ConvertToAsciiBooleanArray());
            var russianText = "«собаку»";

            // This assertion should throw an exception because Russian Alphabet is not compatible with ASCII 7-bit
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => russianText.ContainsOnlyAsciiLetters());

            // This assertion should work, because Russian Alphabet is unicode
            Assert.IsTrue(russianText.ContainsOnly(RUSSIAN_ALPHABET, true));
        }
    }
}
