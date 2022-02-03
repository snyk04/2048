using System;

namespace TwentyFortyEight.PlayField.Logic
{
    public interface IObjectMerger<out T>
    {
        event Action<(int, int), (int, int), T> OnMerge;

        
        void Merge((int, int) tileToMergeIntoCoordinates, (int, int) mergedTileCoordinates);
    }
}