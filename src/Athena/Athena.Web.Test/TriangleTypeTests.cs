using Athena.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Athena.Web.Test
{
    [TestClass]
    public class TriangleTypeTests
    {       
        [TestMethod]
        [DataRow(1, 1, 1, DisplayName = "Triangle1")]
        [DataRow(2, 2, 2, DisplayName = "Triangle2")]
        [DataRow(2147483647, 2147483647, 2147483647, DisplayName = "Triangle3")]
        public void ReturnEquilateralForValidTriangle(int a, int b, int c)
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.TriangleType(a, b, c);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(result.StatusCode.Value, 200);
            Assert.AreEqual("Equilateral", result.Value.ToString(), true);
        }

        [TestMethod]
        [DataRow(3, 3, 4, DisplayName = "Triangle1")]
        [DataRow(6, 10, 6, DisplayName = "Triangle2")]
        [DataRow(9, 2147483647, 2147483647, DisplayName = "Triangle3")]
        public void ReturnIsoscelesForValidTriangle(int a, int b, int c)
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.TriangleType(a, b, c);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(result.StatusCode.Value, 200);
            Assert.AreEqual("Isosceles", result.Value.ToString(), true);
        }

        [TestMethod]
        [DataRow(2, 3, 4, DisplayName = "Triangle1")]
        [DataRow(8, 4, 5, DisplayName = "Triangle2")]
        [DataRow(6, 9, 4, DisplayName = "Triangle3")]
        public void ReturnScaleneForValidTriangle(int a, int b, int c)
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.TriangleType(a, b, c);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(result.StatusCode.Value, 200);
            Assert.AreEqual("Scalene", result.Value.ToString(), true);
        }

        [TestMethod]
        [DataRow(1, 2, 3, DisplayName = "Triangle1")]
        [DataRow(4, 2, 1, DisplayName = "Triangle2")]
        [DataRow(1, 4, 6, DisplayName = "Triangle3")]
        [DataRow(2, 10, 5, DisplayName = "Triangle4")]
        [DataRow(2147483647, 2147483646, 1, DisplayName = "Triangle5")]
        [DataRow(-2147483648, 2147483647, 2147483647, DisplayName = "Triangle6")]
        public void ReturnErrorForInvalidTriangle(int a, int b, int c)
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = (ObjectResult)controller.TriangleType(a, b, c);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.HasValue);
            Assert.AreEqual(200, result.StatusCode.Value);
            Assert.AreEqual("Error", result.Value.ToString(), true);
        }       
    }
}
