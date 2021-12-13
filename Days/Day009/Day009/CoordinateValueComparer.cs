﻿namespace Day009
{
    internal class CoordinateValueComparer : IEqualityComparer<CoordinateValue>
    {
        public bool Equals(CoordinateValue x, CoordinateValue y)
        {
            return x.Row == y.Row && x.Column == y.Column;
        }
        public int GetHashCode(CoordinateValue obj)
        {
            return obj.Row.GetHashCode() ^ obj.Column.GetHashCode();
        }
    }
}