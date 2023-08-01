using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiguresLib.Tests {
    [TestClass]
    public class TriangleTests {
        private const double EPS = 0.00001;

        [ExpectedException(typeof(ArgumentNullException), "Exception for null a-side was not thrown")]
        [TestMethod]
        public void TriangleConstrucnt_ANull_Exception() {
            // arrange
            double? a = null;
            double? b = 10;
            double? c = 4;

            // exception
            Triangle t = new Triangle(a, b, c);
        }

        [ExpectedException(typeof(ArgumentNullException), "Exception for null b-side was not thrown")]
        [TestMethod]
        public void TriangleConstrucnt_BNull_Exception() {
            // arrange
            double? a = 10;
            double? b = null;
            double? c = 4;

            // exception
            Triangle t = new Triangle(a, b, c);
        }

        [ExpectedException(typeof(ArgumentNullException), "Exception for null c-side was not thrown")]
        [TestMethod]
        public void TriangleConstrucnt_CNull_Exception() {
            // arrange
            double? a = 4;
            double? b = 10;
            double? c = null;

            // exception
            Triangle t = new Triangle(a, b, c);
        }

        [ExpectedException(typeof(ArgumentNullException), "Exception for null a and b sides was not thrown")]
        [TestMethod]
        public void TriangleConstrucnt_AAndBNull_Exception() {
            // arrange
            double? a = null;
            double? b = null;
            double? c = 4;

            // exception
            Triangle t = new Triangle(a, b, c);
        }

        [ExpectedException(typeof(ArgumentNullException), "Exception for null a and c sides was not thrown")]
        [TestMethod]
        public void TriangleConstrucnt_AAndCNull_Exception() {
            // arrange
            double? a = null;
            double? b = 10;
            double? c = null;

            // exception
            Triangle t = new Triangle(a, b, c);
        }

        [ExpectedException(typeof(ArgumentNullException), "Exception for null b and c sides was not thrown")]
        [TestMethod]
        public void TriangleConstrucnt_BAndCNull_Exception() {
            // arrange
            double? a = 10;
            double? b = null;
            double? c = null;

            // exception
            Triangle t = new Triangle(a, b, c);
        }

        [ExpectedException(typeof(ArgumentNullException), "Exception for all null sides was not thrown")]
        [TestMethod]
        public void TriangleConstrucnt_AAndBAndCNull_Exception() {
            // arrange
            double? a = null;
            double? b = null;
            double? c = null;

            // exception
            Triangle t = new Triangle(a, b, c);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException), "Exception for one of the side less than 0 was not thrown")]
        [TestMethod]
        public void TriangleConstrucnt_ALessZero_Exception() {
            // arrange
            double? a = -5;
            double? b = 8;
            double? c = 10;

            // exception
            Triangle t = new Triangle(a, b, c);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException), "Exception for one of the side equal to 0 was not thrown")]
        [TestMethod]
        public void TriangleConstrucnt_CEqualZero_Exception() {
            // arrange
            double? a = 10;
            double? b = 8;
            double? c = 0;

            // exception
            Triangle t = new Triangle(a, b, c);
        }

        [ExpectedException(typeof(ArgumentException), "Exception for not valid triangle was not thrown")]
        [TestMethod]
        public void TriangleConstrucnt_NotValidTriangle_Exception() {
            // arrange
            double? a = 8;
            double? b = 2;
            double? c = 5;

            // exception
            Triangle t = new Triangle(a, b, c);
        }

        [TestMethod]
        public void TriangleArea_10And4And8_15returned() {
            // arrange
            double? a = 10;
            double? b = 4;
            double? c = 8;
            double expected = 15.198684153570664;

            // act
            Triangle t = new Triangle(a, b, c);
            double actual = t.GetArea();

            // assert
            Assert.AreEqual(expected, actual, EPS, 
                "Area of the triangle with sides {0}, {1}, {2} should have been {3}!", a, b, c, actual);
        }

        [TestMethod]
        public void Triangle_IsRectangle_TrueReturned() {
            // arrange
            double? a = 16;
            double? b = 63;
            double? c = 65;

            // act
            Triangle t = new Triangle(a, b, c);
            bool actual = t.IsRectangularTriangle();

            // assert
            Assert.IsTrue(actual, "Triangle with sides {0}, {1}, {2} should be a right triangle", a, b, c);
        }

        [TestMethod]
        public void Triangle_IsRectangle_FalseReturned() {
            // arrange
            double? a = 11;
            double? b = 15;
            double? c = 8;

            // act
            Triangle t = new Triangle(a, b, c);
            bool actual = t.IsRectangularTriangle();

            // assert
            Assert.IsFalse(actual, "Triangle with sides {0}, {1}, {2} should not be a right triangle", a, b, c);
        }
    }
}