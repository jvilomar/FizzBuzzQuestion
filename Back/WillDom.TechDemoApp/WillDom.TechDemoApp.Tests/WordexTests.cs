using NUnit.Framework;
using System.Collections.Generic;
using WillDom.TechDemo.Common;
using WillDom.TechDemo.Interfaces;
using WillDom.TechDemo.Models;

namespace WillDom.TechDemoApp.Tests
{
    public class Tests
    {
        private Wordex _wordex;
        private Operations _operations;

        [SetUp]
        public void Setup()
        {
            _wordex = new Wordex();
            _operations = new Operations();
        }

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        public void ShouldReceiveRigthElementCounts(int input)
        {
            //Act
            var output = _wordex.GetWordex(input);

            //Assert
            Assert.AreEqual(input, output.Count);
        }

        [Test]
        [TestCaseSource("FizzBuzzCorrectWords")]
        public void ShouldReturnCorrectWord(IWordexInfo wordexInfo, string expectedOuput)
        {
            //Act
            var result = _operations.GetWord(wordexInfo);

            //Assert
            Assert.AreEqual(result, expectedOuput);
        }

        public static IEnumerable<TestCaseData> FizzBuzzCorrectWords
        {
            get 
            { 
                yield return new TestCaseData(new WordexInfo { Multiple = 3, Multiplier = 3, Word = "Fizz" }, "Fizz").SetName("ReturnFizzWord");
                yield return new TestCaseData(new WordexInfo { Multiple = 5, Multiplier = 5, Word = "Buzz" }, "Buzz").SetName("ReturnBuzzWord");
                yield return new TestCaseData(new WordexInfo { Multiple = 7, Multiplier = 7, Word = "Jazz" }, "Jazz").SetName("ReturnJazzWord");
            }
        }
    }
}