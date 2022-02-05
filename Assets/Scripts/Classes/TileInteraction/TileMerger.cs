using System;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.TileInteraction.Logic
{
    public class TileMerger : IObjectMerger<int>
    {
        public event Action<(int, int), (int, int), int> OnMerge;
        public event Action OnVictoryNumberReach;
        public bool IsInCheckMode { get; set; }
        
        private readonly IIndexable<IContainer<IContainer<int>>> _board;
        private readonly int _victoryNumber;

        
        public TileMerger(IIndexable<IContainer<IContainer<int>>> board, int victoryNumber)
        {
            _board = board;
            _victoryNumber = victoryNumber;
        }

        
        public void Merge(IIndexable<IContainer<IContainer<int>>> board, 
            (int, int) tileToMergeIntoCoordinates, (int, int) mergedTileCoordinates)
        {
            IContainer<int> tileToMergeInto = board[tileToMergeIntoCoordinates].Value;
            int valueAfterMerge = tileToMergeInto.Value * 2;
            tileToMergeInto.Value = valueAfterMerge;
            board[mergedTileCoordinates].Value = null;

            if (valueAfterMerge == _victoryNumber)
            {
                OnVictoryNumberReach?.Invoke();
            }
            
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