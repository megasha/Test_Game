using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class World
    {
        Game1 game;

        Player player;
        Vector2 winSize;

        public World(Game1 currGame)
        {
            game = currGame;
            winSize = new Vector2();
        }

        public void Initialize()
        {

        }

        public void LoadContent()
        {
            player = new Player(game);
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            winSize.X = game.GraphicsDevice.Viewport.Width;
            winSize.Y = game.GraphicsDevice.Viewport.Height;

            player.Update();
        }

        public void Draw(GameTime gameTime)
        {
            player.Draw();
        }
    }
}
