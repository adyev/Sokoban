using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Actors;
using Sokoban.Field.Tiles;
using Sokoban.Field;
using Sokoban.Utils;
using System.Collections.Generic;
using System;

namespace Sokoban
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Tile Tile {  get; set; }
        private Keys PressedKey {  get; set; }
        private Player Player {  get; set; }
        private Field.Field Field { get; set; }
        static Vector2 center;
        static float step;
        static Dictionary<string, Texture2D> Textures { get; set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            center = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            step = _graphics.PreferredBackBufferHeight / 8;
            
        }

        protected override void Initialize()
        {
            Field = new Field.Field("lvl1", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth);
            Player = new Player();
            Player.CorrentTile = Field.Tiles[1, 1];
            Field.Tiles[1, 1].Occupand = Player;
            PressedKey = Keys.None;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            var tileSafeArea = GraphicsDevice.Viewport.TitleSafeArea;
            var playerPosition = center;
            Textures = new Dictionary<string, Texture2D>
            {
                ["Player"] = Content.Load<Texture2D>("gordon"),
                ["RoadTile"] = Content.Load<Texture2D>("DirtTile"),
            };
            Player.Texture = Textures["Player"];
            foreach (var tile in Field.Tiles)
            {
                if (tile is RoadTile)
                {
                    tile.Texture = Textures["RoadTile"];
                    tile.Scale = Field.TileSize / tile.Texture.Width;
                }
            }
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var keyState = Keyboard.GetState();
            if (PressedKey == Keys.None)
            {
                PressedKey = Controls.GetPressedKey(keyState);
                Player.Move(PressedKey); 
            }
            else if (keyState.IsKeyUp(PressedKey))
                PressedKey = Keys.None;   

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            _spriteBatch.Begin();
            //Tile.Position = center;
            //foreach (var tile in Field.Tiles)
            //    tile.Draw(_spriteBatch, Tile.GetScale(_graphics.PreferredBackBufferHeight, 8));
            Field.Draw(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
