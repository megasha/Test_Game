using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    class Player
    {
        Game1 game;
        Texture2D image;
        Vector2 position;
        Rectangle drawRec;

        public Player(Game1 currGame)
        {
            game = currGame;
            position = new Vector2(0,0);
            image = game.Content.Load<Texture2D>("Images/renge");
            drawRec = new Rectangle(0, 0, image.Width, image.Height);
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                position.X-=5;

            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                position.X+=5;

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                position.Y-=5;

            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                position.Y+=5;
        }

        public void Draw()
        {
            game.spriteBatch.Begin();
            game.spriteBatch.Draw(image,position,drawRec, Color.White);
            game.spriteBatch.End();
        }
    }
}
