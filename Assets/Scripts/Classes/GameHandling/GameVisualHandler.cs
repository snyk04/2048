using TwentyFortyEight.Common;
using TwentyFortyEight.TileInteraction.Visual;
using TwentyFortyEight.PlayField.Visual;
using UnityEngine;

namespace TwentyFortyEight.GameHandling
{
    public class GameVisualHandler
    {
        private readonly IGameHandler _gameHandler;
        
        private readonly GameObject _boardPrefab;
        private readonly GameObject _cellPrefab;
        private readonly GameObject _tilePrefab;
        private readonly float _offsetBetweenCells;


        public GameVisualHandler(IGameHandler gameHandler,
            GameObject boardPrefab, GameObject cellPrefab, GameObject tilePrefab, float offsetBetweenCells)
        {
            _gameHandler = gameHandler;
            _boardPrefab = boardPrefab;
            _cellPrefab = cellPrefab;
            _tilePrefab = tilePrefab;
            _offsetBetweenCells = offsetBetweenCells;

            _gameHandler.OnGameStart += PrepareVisuals;
        }


        private void PrepareVisuals()
        {
            IIndexable<CellVisual> boardVisual = new BoardVisual(
                _gameHandler.Board,
                _boardPrefab,
                _cellPrefab,
                _offsetBetweenCells
                );

            var tileVisualMerger = new TileVisualMerger(boardVisual);
            var tileVisualMover = new TileVisualMover(boardVisual);
            var tileVisualSpawner = new TileVisualSpawner(_tilePrefab, boardVisual);
            
            _gameHandler.TileMerger.OnMerge += tileVisualMerger.Merge;
            _gameHandler.TileMover.OnMove += tileVisualMover.Move;
            _gameHandler.TileSpawner.OnSpawn += tileVisualSpawner.SpawnTile;
        }
    }
}