using Microsoft.Xna.Framework.Graphics;
using Sokoban.Map.Tiles;
using Sokoban.Utils;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using Sokoban.Actors;

namespace Sokoban.Map
{
    public class Field
    {
        public float TileSize { get; private set; }
        public Tile[,] Tiles { get; }
        public Player Player { get; private set; }

        public List<Tile> DestinationPoints { get; private set; }

        public Field(string level, float windowHeight, float windowWidth)
        {
            var terrain = LoadTerrain(level);
            var actors = LoadActors(level);
            DestinationPoints = [];
            TileSize = CalculateTileSize(terrain, Math.Min(windowWidth, windowHeight));
            Tiles = FormTerrainTilesFromLayout(terrain);
            SetTilePositions(windowHeight, windowWidth);
            SetTileRelations();
            SetActors(actors);
            DestinationPoints = GetDestinationPoints();
        }

        public void SetActors(string layout)
        {
            var lines = layout.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
            var width = lines[0].Length;
            var height = lines.Length;

            for (var i = 0; i < height; i++)
                for (var j = 0; j < width; j++)
                {
                    Tiles[i, j].Occupand = Mapper.SymbolToActor(lines[i][j]);
                    if (Tiles[i, j].Occupand != null)    
                        Tiles[i, j].Occupand.CorrentTile = Tiles[i, j];
                    if (Tiles[i, j].Occupand is Player player)
                        Player = player;
                }
        }

        private static string LoadTerrain(string level)
        {
            return File.ReadAllText($"{DirManager.GetRootDir()}\\Content\\Levels\\{level}\\Terrain.txt");
        }

        private static string LoadActors(string level)
        {
            return File.ReadAllText($"{DirManager.GetRootDir()}\\Content\\Levels\\{level}\\Actors.txt");
        }

        private static Tile[,] FormTerrainTilesFromLayout(string layout)
        {
            var lines = layout.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
            var width = lines[0].Length;
            var height = lines.Length;

            var result = new Tile[height, width];
            for (var i = 0; i < height; i++)
                for (var j = 0; j < width; j++)
                    result[i, j] = Mapper.SymbolToTile(lines[i][j]);

            return result;
        }

        private List<Tile> GetDestinationPoints()
        {
            var points = new List<Tile>();
            foreach (var tile in Tiles)
                if (tile is DestinationPointTile)
                    points.Add(tile);
            return points;
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

        public bool IsLvlFinished()
        {
            foreach (var tile in DestinationPoints)
            {
                if (tile.Occupand is not Box)
                    return false;
            }
            return true;
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