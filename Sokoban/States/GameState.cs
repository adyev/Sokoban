using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.States
{
    internal class GameState(Game game, ContentManager content, Texture2D backgroundTexture) 
        : State(game, content, backgroundTexture)
    {
        public override void LoadContent()
        {
            EventHandler a;
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        public override void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
