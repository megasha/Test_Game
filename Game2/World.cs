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
        Camera cam;

        Texture2D image;
        Rectangle drawRec;

        public World(Game1 currGame)
        {
            game = currGame;
        }

        public void Initialize()
        {
            cam = new Camera();
            cam.ViewportWidth = game.GraphicsDevice.Viewport.Width;
            cam.ViewportHeight = game.GraphicsDevice.Viewport.Height;
        }

        public void LoadContent()
        {
            player = new Player(game);
            cam.SetFocus(player);

            image = game.Content.Load<Texture2D>("Images/glory");
            drawRec = new Rectangle(0, 0, image.Width, image.Height);
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            player.Update();
            cam.Update();
        }

        public void Draw(GameTime gameTime)
        {
            player.Draw(cam);


            Vector2 origin = Vector2.Transform(new Vector2(0, 0), cam.TranslationMatrix);
            game.spriteBatch.Begin();
            game.spriteBatch.Draw(image, origin, drawRec, Color.White);
            game.spriteBatch.End();
        }
    }
}
