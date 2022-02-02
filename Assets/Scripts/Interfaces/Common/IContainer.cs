namespace TwentyFortyEight.Common
{
    public interface IContainer<T> : IReadOnlyContainer<T>, IWriteOnlyContainer<T>
    {
        new T Value { get; set; }
    }
}