using Sokoban.Field.Tiles;
using System;
using System.Collections.Generic;

namespace Sokoban.Field
{

    public class Field
    {
        public int TileSize { get; }
        public List<Tile> Tiles { get; }
        public List<Tile> DestinationTiles { get; }

        public Field(MapLayout mapLayout)
        {
            throw new NotImplementedException();
        }

    }
}