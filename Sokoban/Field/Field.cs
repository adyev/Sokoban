using Microsoft.Xna.Framework.Graphics;
using Sokoban.Field.Tiles;
using Sokoban.Utils;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;

namespace Sokoban.Field
{
    public class Field
    {
        public float TileSize { get; private set; }
        public Tile[,] Tiles { get; }

        public Field(string level, float windowHeight, float windowWidth)
        {
            var terrain = LoadTerrain(level);
            TileSize = CalculateTileSize(terrain, Math.Min(windowWidth, windowHeight));
            Tiles = FormTerrainTilesFromLayout(terrain);
            SetTilePositions(windowHeight, windowWidth);
            SetTileRelations();
        }

        private string LoadTerrain(string level) => File.ReadAllText($"{DirManager.GetRootDir()}\\Content\\Levels\\{level}\\Terrain.txt");

        private static Tile[,] FormTerrainTilesFromLayout(string layout)
        {
            var lines = layout.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
            var width = lines[0].Length;
            var height = lines.Length;

            var result = new Tile[height, width];
            for (var i = 0; i < height; i++)
                for (var j = 0; j < width; j++)
                    result[i, j] = TerrainMapper.SymbolToTile(lines[i][j]);
            
            return result;
        }

        private static float CalculateTileSize(string terrain, float minSide)
        {
            var terrainLines = terrain.Split('\n');
            return minSide / Math.Max(terrainLines.Length, terrainLines[0].Length);
        }

        private void SetTilePositions(float windowHeight, float windowWidth)
        {
            float xStart = (windowWidth - Tiles.GetLength(1) * TileSize) / 2 + TileSize / 2;
            float yStart = (windowHeight - Tiles.GetLength(0) * TileSize) / 2 + TileSize / 2;
            for (var i = 0; i < Tiles.GetLength(0); i++)
            {
                for (var j = 0; j < Tiles.GetLength(1); j++)
                {
                    Tiles[i, j].Position = new Vector2 { X = xStart + j * TileSize, Y = yStart + i * TileSize };
                }
            }
        }

        private void SetTileRelations()
        {
            for (var i = 0; i< Tiles.GetLength(0); i++)
            {
                for(var j = 0; j< Tiles.GetLength(1); j++)
                {
                    Tiles[i, j].SetRelations(Tiles, i, j);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in Tiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}