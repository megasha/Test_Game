using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Game2
{
    class World
    {
        Game1 game;

        Player player;
        Camera cam;

        Texture2D image;
        Rectangle drawRec;

        Song song;

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
            //Asset loads here
            player = new Player(game);
            cam.SetFocus(player);


            image = game.Content.Load<Texture2D>("Images/tmp");
            song = game.Content.Load<Song>("Sounds/moe");
            drawRec = new Rectangle(0, 0, image.Width, image.Height);

            //MediaPlayer.Play(song);
            //MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }

        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(song);
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            cam.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            Vector2 origin = Vector2.Transform(new Vector2(0, 0), cam.TranslationMatrix);
            game.spriteBatch.Begin();
            game.spriteBatch.Draw(image, origin, drawRec, Color.White);
            game.spriteBatch.End();

            player.Draw(cam);
        }
    }
}
