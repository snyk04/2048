using System;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
{
    public class TileMerger : IObjectMerger<int>
    {
        public event Action<(int, int), (int, int), int> OnMerge;
        
        private readonly IIndexable<IContainer<IContainer<int>>> _board;


        public TileMerger(IIndexable<IContainer<IContainer<int>>> board)
        {
            _board = board;
        }

        
        public void Merge((int, int) tileToMergeIntoCoordinates, (int, int) mergedTileCoordinates)
        {
            IContainer<int> tileToMergeInto = _board[tileToMergeIntoCoordinates.Item1, tileToMergeIntoCoordinates.Item2].Value;
            tileToMergeInto.Value *= 2;
            _board[mergedTileCoordinates.Item1, mergedTileCoordinates.Item2].Value = null;
            
            OnMerge?.Invoke(tileToMergeIntoCoordinates, mergedTileCoordinates, tileToMergeInto.Value);
        }
    }
}