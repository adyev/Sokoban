using Sokoban.Utils;
using System.Collections.Generic;

namespace Sokoban.Field
{
    public class MapLayout : IValidatable
    {
        public string Terrain { get; }
        public List<Point> ActorPositions { get; }

        public MapLayout(string terrain, List<Point> actorPositions)
        {
            Terrain = terrain;
            ActorPositions = actorPositions;
            Validate();
        }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}