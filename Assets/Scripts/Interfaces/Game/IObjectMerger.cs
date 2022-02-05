using System;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.Game
{
    public interface IObjectMerger<T>
    {
        event Action<(int, int), (int, int), T> OnMerge;
        event Action OnVictoryNumberReach;
        bool IsInCheckMode { get; set; }
        
        void Merge(IIndexable<IContainer<IContainer<T>>> board, (int, int) tileToMergeIntoCoordinates,
            (int, int) mergedTileCoordinates);
        void Merge((int, int) tileToMergeIntoCoordinates, (int, int) mergedTileCoordinates);
    }
}