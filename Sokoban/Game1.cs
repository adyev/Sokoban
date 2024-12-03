using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Actors;
using Sokoban.Map.Tiles;
using Sokoban.Map;
using Sokoban.Utils;
using System.Collections.Generic;
using System;

namespace Sokoban
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Keys PressedKey {  get; set; }
        private Field Field { get; set; }
        static Vector2 center;
        static Dictionary<string, Texture2D> Textures { get; set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.PreferredBackBufferWidth = 1600;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            center = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            
        }

        protected override void Initialize()
        {
            Field = new Field("lvl1", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth);
            PressedKey = Keys.None;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Textures = new Dictionary<string, Texture2D>
            {
                ["Player"] = Content.Load<Texture2D>("gordon"),
                ["RoadTile"] = Content.Load<Texture2D>("DirtTile"),
                ["Box"] = Content.Load<Texture2D>("Box"),
                ["DestinationPointTile"] = Content.Load<Texture2D>("DestinationTile"),
            };
            foreach (var tile in Field.Tiles)
            {
                if (Textures.TryGetValue(tile.NameTag, out var tileTexture))
                {
                    tile.Texture = tileTexture;
                    tile.Scale = Field.TileSize / tile.Texture.Width;
                }
                if (tile.Occupand != null && Textures.TryGetValue(tile.Occupand.NameTag, out var actorTexture))
                {
                    tile.Occupand.Texture = actorTexture;
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var keyState = Keyboard.GetState();

            if (PressedKey == Keys.None)
            {
                PressedKey = Controls.GetPressedKey(keyState);
                Field.Player.TryMoveTo(Field
                                      .Player
                                      .CorrentTile
                                      .GetTileByDirection(Controls
                                                         .GetMoveDirection(PressedKey))); 
            }
            else if (keyState.IsKeyUp(PressedKey))
                PressedKey = Keys.None;   

            if (Field.IsLvlFinished())
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            Field.Draw(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
