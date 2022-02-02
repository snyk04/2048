using System;

namespace TwentyFortyEight.Common
{
    public interface IIndexable<T>
    {
        T this [int i, int j] { get; set; }
        int GetLength(int dimension);
    }
}