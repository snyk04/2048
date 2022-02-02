namespace TwentyFortyEight.Common
{
    public interface IReadOnlyContainer<out T>
    {
        T Value { get; }
    }
}