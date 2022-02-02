﻿using System;
using TwentyFortyEight.Common;
using TwentyFortyEight.PlayField.Logic;

namespace TwentyFortyEight
{
    // TODO : Make it generic
    public interface IObjectMover
    {
        event Action<(int, int), (int, int)> OnMove;
        void Move(Direction direction, IIndexable<IContainer<IContainer<int>>> objects);
    }
}