using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces
{
    public class Vector : IComparable<Vector>
    {
        private static readonly Vector left = new Vector(-1, 0);
        private static readonly Vector right = new Vector(1, 0);
        private static readonly Vector forward = new Vector(0, 1);
        private static readonly Vector back = new Vector(0, -1);
        private static readonly Vector stand = new Vector(0, 0);

        public static Vector Left { get { return left; } }
        public static Vector Right { get { return right; } }
        public static Vector Forward { get { return forward; } }
        public static Vector Back { get { return back; } }
        public static Vector Stand { get { return stand; } }

        public int X { get; set; }
        public int Y { get; set; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator *(Vector a, int num)
        {
            return new Vector(a.X * num, a.Y * num);
        }

        public static Vector operator *(int num, Vector a)
        {
            return new Vector(a.X * num, a.Y * num);
        }

        //public static Vector GetVector(Direction dir)
        //{
        //    switch (dir)
        //    {
        //        case Direction.BACK:
        //            return Vector.BACK;
        //        case Direction.FORWARD:
        //            return Vector.FORWARD;
        //        case Direction.LEFT:
        //            return Vector.LEFT;
        //        case Direction.RIGHT:
        //            return Vector.RIGHT;
        //        default:
        //            return Vector.STAND;
        //    }
        //}
        public int CompareTo(Vector other)
        {
            int x = this.X.CompareTo(other.X);
            int y = this.Y.CompareTo(other.Y);
            if (x == 0 && y == 0) return 0;
            return 1;
        }
    }

    public enum ObjType { Stone, Metal, Forest, Sand, Water }

    public enum TracksType { Fast, Medium, Width }
    public enum BodyType { Light, Medium, Heavy }
    public enum GunType { LowDamageGun, MediumDamageGun, HightDamageGun }

    public enum TankType { Enemy, Player }
}
