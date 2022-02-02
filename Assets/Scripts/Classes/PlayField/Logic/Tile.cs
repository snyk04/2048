using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
{
    public class Tile : IContainer<int>
    {
        public int Value { get; set; }
        
        
        public Tile(int value)
        {
            Value = value;
        }
    }
}