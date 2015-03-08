using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operators
{
    abstract class Shape
    {
        public abstract double GetSize();
        public abstract double GetArea();
    }

    class Rectangle : Shape
    {
        private double m_length;
        private double m_width;

        public Rectangle(double length, double width)
        {
            m_length = length;
            m_width = width;
        }

        public override double GetSize()
        {
            return 2 * (m_length + m_width);
        }

        public override double GetArea()
        {
            return m_length * m_width;
        }

        public override bool Equals(object o)
        {
            Rectangle other = o as Rectangle;
            if (other == null)
            {
                return false;
            }

            return other.m_length == this.m_length && other.m_width == this.m_width;
        }

        // Overriding Equals() must go hand in hand with overriding GetHashCode()
        // This is used in collections like HashSet or Dictionary
        public override int GetHashCode()
        {
            // System.Double inherits from System.Object => it has GetHashCode()
            return m_width.GetHashCode() * m_length.GetHashCode();
        }

        public static bool operator ==(Rectangle r1, Rectangle r2)
        {
            return r1.Equals(r2);
        }

        public static bool operator !=(Rectangle r1, Rectangle r2)
        {
            return !r1.Equals(r2);
        }

        // Could actually move up to the Shape class
        public static bool operator <(Rectangle r1, Rectangle r2)
        {
            return r1.GetSize() < r2.GetSize();
        }

        public static bool operator >(Rectangle r1, Rectangle r2)
        {
            return r1.GetArea() < r2.GetArea();
        }

        public static Rectangle operator +(Rectangle r1, Rectangle r2)
        {
            if (r1.m_length == r2.m_length)
            {
                return new Rectangle(r1.m_length, r1.m_width + r2.m_width);
            }

            if (r1.m_width == r2.m_width)
            {
                return new Rectangle(r1.m_length + r2.m_length, r1.m_width);
            }

            return null;
        }
    }

    class Circle : Shape
    {
        private double m_radius;

        public Circle(double radius)
        {
            m_radius = radius;
        }

        public override double GetSize()
        {
            return 2 * m_radius * Math.PI;
        }

        public override double GetArea()
        {
            return Math.PI * m_radius * m_radius;
        }

        public override bool Equals(object o)
        {
            Circle other = o as Circle;
            if (other == null)
            {
                return false;
            }

            return other.m_radius == this.m_radius;
        }

        public override int GetHashCode()
        {
            return m_radius.GetHashCode();
        }

        public static Circle operator ++(Circle c)
        {
            return new Circle(c.m_radius + 1);
        }

        public static Circle operator --(Circle c)
        {
            return new Circle(c.m_radius - 1);
        }
    }
}
