using Microsoft.Xna.Framework;
using Sokoban.Map.Tiles;
using Sokoban.Utils;
using System.Collections.Generic;
using System.IO;

namespace Sokoban.Map
{
    public class MapLayout : IValidatable
    {
        public List<Tile> Terrain { get; }
        public List<Vector2> ActorPositions { get; }

        public MapLayout(string lvl)
        {
            string terrainStr = GetTerrainText(lvl);
            Validate();
        }

        public void Validate()
        {
           
        }

        public static string GetTerrainText(string levelDirName)
        {
            string root = DirManager.GetRootDir();
            return File.ReadAllText($"{root}\\Content\\Levels\\{levelDirName}\\Terrain.txt");
        }
    }
}