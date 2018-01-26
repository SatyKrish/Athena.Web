using Athena.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Athena.Web.Test
{
    [TestClass]
    public class ReverseWordsTests
    {
        [TestMethod]
        public void ReturnOkForSentenceWithSpacesBetweenWords()
        {
            // Arrange
            var input = "This is a sample test.";
            var expectedOutput = "sihT si a elpmas .tset";
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.ReverseWords(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(200, result.StatusCode.Value);
            Assert.AreEqual(expectedOutput, result.Value.ToString());
        }

        [TestMethod]
        public void ReturnOkForSentenceWithLeadingSpaces()
        {
            // Arrange
            var input = " Hello World!";
            var expectedOutput = " olleH !dlroW";
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.ReverseWords(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(200, result.StatusCode.Value);
            Assert.AreEqual(expectedOutput, result.Value.ToString());
        }

        [TestMethod]
        public void ReturnOkForSentenceWithTrailingSpaces()
        {
            // Arrange
            var input = "Hello World! ";
            var expectedOutput = "olleH !dlroW ";
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.ReverseWords(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(200, result.StatusCode.Value);
            Assert.AreEqual(expectedOutput, result.Value.ToString());
        }

        [TestMethod]
        public void ReturnOkForSentenceWithLeadingAndTrailingSpaces()
        {
            // Arrange
            var input = " Good Morning ";
            var expectedOutput = " dooG gninroM ";
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.ReverseWords(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(200, result.StatusCode.Value);
            Assert.AreEqual(expectedOutput, result.Value.ToString());
        }

        [TestMethod]
        [DataRow(" ", DisplayName = "Sentence1")]
        [DataRow(null, DisplayName = "Sentence2")]
        public void ReturnErrorForNullOrEmptySentence(string sentence)
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.ReverseWords(sentence);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(200, result.StatusCode.Value);
            Assert.AreEqual("Error", result.Value.ToString(), true);
        }
    }
}
