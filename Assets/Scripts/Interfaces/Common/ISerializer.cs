namespace TwentyFortyEight.Common
{
    public interface ISerializer<T>
    {
        void Serialize(T value);
        T Deserialize();
    }
}