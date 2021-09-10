﻿using TdFactory.Core.World.Tiles;

namespace TdFactory.Core.World
{
    public interface ITilemap : IComputer, IRenderer
    {
        Tile GetTile(int x, int y);
    }
}