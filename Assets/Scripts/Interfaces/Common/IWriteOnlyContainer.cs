namespace TwentyFortyEight.Common
{
    public interface IWriteOnlyContainer<in T>
    {
        T Value { set; }
    }
}