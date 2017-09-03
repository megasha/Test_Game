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
        //Vector2 position;
        public Rectangle drawRec { get; set; }

        public Vector2 position { get; set; }

        public Player(Game1 currGame)
        {
            game = currGame;
            position = new Vector2(0,0);
            image = game.Content.Load<Texture2D>("Images/renge");
            drawRec = new Rectangle(0, 0, image.Width/2, image.Height/2);
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                position = new Vector2(position.X - 5, position.Y);

            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                position = new Vector2(position.X + 5, position.Y);

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                position = new Vector2(position.X, position.Y - 5);

            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                position = new Vector2(position.X, position.Y + 5);
        }

        public void Draw(Camera cam)
        {
            Vector2 pos = Vector2.Transform(position, cam.TranslationMatrix);
            Console.WriteLine("Player Position Camera Space: {0}" , pos.ToString());
            game.spriteBatch.Begin();
            game.spriteBatch.Draw(image,pos,drawRec, Color.White);
            game.spriteBatch.End();
        }
    }
}
