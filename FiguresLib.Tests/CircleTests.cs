using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiguresLib.Tests {
    [TestClass]
    public class CircleTests {
        private const double EPS = 0.00001;

        [TestMethod]
        public void CircleArea_10_314returned() {
            // arrange
            double? r = 10;
            double expected = 314.1592653589793;

            // act
            Circle c = new Circle(r);
            double actual = c.GetArea();

            // assert
            Assert.AreEqual(expected, actual, EPS, "Area of the circle with radius {0} should have been {1}!", r, expected);
        }

        [ExpectedException(typeof(ArgumentNullException), "Exception for null was not thrown")]
        [TestMethod]
        public void CircleConstruct_null_radius_Exception() {
            // arrange
            double? r = null;

            // exception
            Circle c = new Circle(r);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException), "Exception for negative radius was not thrown")]
        [TestMethod]
        public void CircleConstruct_negative_radius_Exception() {
            // arrange
            double? r = -5;

            // exception
            Circle c = new Circle(r);
        }
    }
}