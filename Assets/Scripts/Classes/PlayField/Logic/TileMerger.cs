using System;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
{
    public class TileMerger : IObjectMerger<int>
    {
        public event Action<(int, int), (int, int), int> OnMerge;
        public bool IsInCheckMode { get; set; }
        
        private readonly IIndexable<IContainer<IContainer<int>>> _board;

        public TileMerger(IIndexable<IContainer<IContainer<int>>> board)
        {
            _board = board;
        }

        
        public void Merge(IIndexable<IContainer<IContainer<int>>> board,
            (int, int) tileToMergeIntoCoordinates, (int, int) mergedTileCoordinates)
        {
            IContainer<int> tileToMergeInto = board[tileToMergeIntoCoordinates].Value;
            tileToMergeInto.Value *= 2;
            board[mergedTileCoordinates].Value = null;

            if (!IsInCheckMode)
            {
                OnMerge?.Invoke(tileToMergeIntoCoordinates, mergedTileCoordinates, tileToMergeInto.Value);
            }
        }
        public void Merge((int, int) tileToMergeIntoCoordinates, (int, int) mergedTileCoordinates)
        {
            Merge(_board, tileToMergeIntoCoordinates, mergedTileCoordinates);
        }
    }
}