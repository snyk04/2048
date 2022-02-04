namespace TwentyFortyEight.Common
{
    public interface IIndexable<T>
    {
        T this [int i, int j] { get; set; }
        T this [(int, int) coordinates] { get; set; }
        
        
        int GetLength(int dimension);
        IIndexable<T> Copy();
    }
}