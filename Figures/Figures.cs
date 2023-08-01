namespace Figures {
    /// <summary>
    /// Class that represent Figures
    /// </summary>
    public abstract class Figures {
        /// <summary>
        /// Get the area of the figure
        /// </summary>
        /// <returns>Figure area</returns>
        public abstract double GetArea();
    }

    /// <summary>
    /// Class that represent Circle
    /// </summary>
    public class Circle: Figures {
        private double Radius { get; }
        private double? Area { get; set; }

        /// <summary>
        /// Circle constructor
        /// </summary>
        /// <param name="radius">Circle radius</param>
        public Circle(double? radius) {
            if (radius == null) {
                throw new ArgumentNullException(nameof(radius));
            }
            if (radius < 0) {
                throw new ArgumentOutOfRangeException("radius", "Значение радиуса не должно быть меньше нуля");
            }
            Radius = (double)radius;
            Area = null;
        }

        /// <summary>
        /// Get the area of the circle
        /// </summary>
        /// <returns>Circle area</returns>
        public override double GetArea() {
            if (Area == null) {
                Area = Math.PI * Radius * Radius;
            }
            return (double)Area;
        }
    }

    /// <summary>
    /// Class that represent Triangle
    /// </summary>
    public class Triangle: Figures {
        private double A { get; }
        private double B { get; }
        private double C { get; }
        private bool? IsRectangle { get; set; }
        private double? Area { get; set; }

        private const double EPS = 0.00001;

        /// <summary>
        /// Triangle constructor
        /// </summary>
        /// <param name="a">Side A</param>
        /// <param name="b">Side B</param>
        /// <param name="c">Side C</param>
        public Triangle(double? a, double? b, double? c) {
            if (a == null || b == null || c == null) {
                throw new ArgumentNullException();
            }

            if (a <= 0 || b <= 0 || c <= 0) {
                throw new ArgumentOutOfRangeException("Длина стороны треугольника должна быть больше 0");
            }

            A = (double)a;
            B = (double)b;
            C = (double)c;
            IsRectangle = null;
            Area = null;

            if (!IsValidTriangle()) {
                throw new ArgumentException("Треугольника с такими сторонами не существует");
            }
        }

        /// <summary>
        /// Check if the triangle is valid 
        /// </summary>
        /// <returns>Is the traingle valid</returns>
        private bool IsValidTriangle() {
            return (A + B > C) && (B + C > A) && (A + C > B);
        }

        /// <summary>
        /// Check if the triangle is rectangular
        /// </summary>
        /// <returns>Is the triangle rectangular</returns>
        public bool IsRectangularTriangle() {
            if (IsRectangle == null) {
                double[] sides = new double[] { A, B, C };
                Array.Sort(sides);

                // To check rectangularity we use Pythagora's theorem
                IsRectangle = Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[1], 2) + Math.Pow(sides[0], 2))) < EPS;
            }

            return (bool)IsRectangle;
        }

        /// <summary>
        /// Get the area of the triangle
        /// </summary>
        /// <returns>Triangle area</returns>
        public override double GetArea() {
            if (Area == null) {
                double perimeter = (A + B + C) / 2;

                Area = Math.Sqrt(perimeter * (perimeter - A) * (perimeter - B) * (perimeter - C));
            }

            return (double)Area;
        }
    }
}