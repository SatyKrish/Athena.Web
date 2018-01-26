using Athena.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Athena.Web.Test
{
    [TestClass]
    public class FibonacciTests
    {       
        [TestMethod]
        [DataRow(5, DisplayName = "Index1")]
        [DataRow(50, DisplayName = "Index2")]
        public void ReturnOkForPositiveInteger(int n)
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.Fibonacci(n);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(200, result.StatusCode.Value);
        }

        [TestMethod]
        [DataRow(-5, DisplayName = "Index1")]
        [DataRow(-50, DisplayName = "Index2")]
        public void ReturnOkForNegativeInteger(int n)
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.Fibonacci(n);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(200, result.StatusCode.Value);
        }

        [TestMethod]
        [DataRow(1, DisplayName = "Index1")]
        [DataRow(2, DisplayName = "Index2")]
        public void ReturnFibonacciNumber1(int n)
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.Fibonacci(n);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(200, result.StatusCode.Value);
            Assert.AreEqual(1, (long)result.Value);
        }

        [TestMethod]
        [DataRow(7, DisplayName = "Index1")]
        [DataRow(-7, DisplayName = "Index2")]
        public void ReturnFibonacciNumber13(int n)
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.Fibonacci(n);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(200, result.StatusCode.Value);
            Assert.AreEqual(13, (long)result.Value);
        }

        [TestMethod]
        [DataRow(0, DisplayName = "Index1")]
        public void ReturnFibonacciNumber0(int n)
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.Fibonacci(n);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(200, result.StatusCode.Value);
            Assert.AreEqual(0, (long)result.Value);
        }
    }
}
