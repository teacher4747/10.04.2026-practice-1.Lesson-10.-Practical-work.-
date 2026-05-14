using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _10._04._2026__practice_1_
{
    
    public readonly struct Coord : IEquatable<Coord>
    {
        public int X { get; }
        public int Y { get; }

        public Coord(int x, int y) { X = x; Y = y; }

        // Операторы
        public static Coord operator +(Coord a, Coord b) => new Coord(a.X + b.X, a.Y + b.Y);
        public static Coord operator -(Coord a, Coord b) => new Coord(a.X - b.X, a.Y - b.Y);
        public static Coord operator *(Coord a, int scalar) => new Coord(a.X * scalar, a.Y * scalar);
        public static Coord operator *(int scalar, Coord a) => a * scalar;

        public static bool operator ==(Coord a, Coord b) => a.Equals(b);
        public static bool operator !=(Coord a, Coord b) => !a.Equals(b);

        // Переопределение Equals и GetHashCode
        public override bool Equals(object obj) => obj is Coord other && Equals(other);
        public bool Equals(Coord other) => X == other.X && Y == other.Y;

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public override string ToString() => $"({X},{Y})";
    }
}

