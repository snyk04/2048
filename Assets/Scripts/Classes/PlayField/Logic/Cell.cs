using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
{
    public class Cell : IContainer<IContainer<int>>
    {
        public IContainer<int> Value { get; set; }
    }
}