using System;

namespace WinFormsApp1
{
    public class RationalFraction
    {
        private int numerator;
        private int denominator;

        public RationalFraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть равен 0");

            this.numerator = numerator;
            this.denominator = denominator;

            if (this.denominator < 0)
            {
                this.numerator = -this.numerator;
                this.denominator = -this.denominator;
            }
        }

        public int Numerator => numerator;
        public int Denominator => denominator;

        public string RawVerbose()
        {
            return $"{numerator}/{denominator}";
        }

        public RationalFraction Reduce()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            return new RationalFraction(numerator / gcd, denominator / gcd);
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            var reduced = Reduce();
            return $"{reduced.numerator}/{reduced.denominator}";
        }

        public static RationalFraction operator +(RationalFraction a, RationalFraction b)
        {
            int newNumerator = a.numerator * b.denominator + b.numerator * a.denominator;
            int newDenominator = a.denominator * b.denominator;
            return new RationalFraction(newNumerator, newDenominator).Reduce();
        }

        public static RationalFraction operator -(RationalFraction a, RationalFraction b)
        {
            int newNumerator = a.numerator * b.denominator - b.numerator * a.denominator;
            int newDenominator = a.denominator * b.denominator;
            return new RationalFraction(newNumerator, newDenominator).Reduce();
        }

        public static RationalFraction operator *(RationalFraction a, RationalFraction b)
        {
            return new RationalFraction(a.numerator * b.numerator, a.denominator * b.denominator).Reduce();
        }

        public static RationalFraction operator /(RationalFraction a, RationalFraction b)
        {
            if (b.numerator == 0)
                throw new DivideByZeroException("Деление на ноль");
            return new RationalFraction(a.numerator * b.denominator, a.denominator * b.numerator).Reduce();
        }

        public static bool operator ==(RationalFraction a, RationalFraction b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return ReferenceEquals(a, b);

            var reducedA = a.Reduce();
            var reducedB = b.Reduce();
            return reducedA.numerator == reducedB.numerator &&
                   reducedA.denominator == reducedB.denominator;
        }

        public static bool operator !=(RationalFraction a, RationalFraction b)
        {
            return !(a == b);
        }

        public static bool operator >(RationalFraction a, RationalFraction b)
        {
            return a.numerator * b.denominator > b.numerator * a.denominator;
        }

        public static bool operator <(RationalFraction a, RationalFraction b)
        {
            return a.numerator * b.denominator < b.numerator * a.denominator;
        }
        public override bool Equals(object obj)
        {
            if (obj is RationalFraction other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            var reduced = Reduce();
            return HashCode.Combine(reduced.numerator, reduced.denominator);
        }
    }
}