using System;

namespace TwentyFortyEight.Common
{
    public interface IObjectSpawner<out T>
    {
        event Action<(int, int), T> OnSpawn;

        void SpawnAtRandomPosition(int tilesToSpawn = 1);
    }
}