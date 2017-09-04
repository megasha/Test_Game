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
        Texture2D currImage;
        List<Texture2D> imageList;
        bool faceRight;
        public Rectangle drawRec { get; set; }

        public Vector2 position { get; set; }

        int columns;

        private Keys prevKey;
        private int currentFrame = 0;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 200;

        public Player(Game1 currGame)
        {
            game = currGame;
            position = new Vector2(0,0);
            imageList = new List<Texture2D>();

            // Populate sprite images
            imageList.Add(game.Content.Load<Texture2D>("Images/homura_nr"));
            imageList.Add(game.Content.Load<Texture2D>("Images/homura_nl"));
            imageList.Add(game.Content.Load<Texture2D>("Images/homura_rr"));
            imageList.Add(game.Content.Load<Texture2D>("Images/homura_rl"));
            faceRight = true;

            columns = 8;
        }

        public void Update(GameTime gameTime)
        {
            // IO Manager
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                position = new Vector2(position.X - 10, position.Y);

            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                position = new Vector2(position.X + 10, position.Y);

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                position = new Vector2(position.X, position.Y - 10);

            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                position = new Vector2(position.X, position.Y + 10);

            // Animation selection manager
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                faceRight = false;

                if (prevKey != Keys.Left)
                {
                    prevKey = Keys.Left;
                    currImage = imageList[3];
                    currentFrame = 0;
                    timeSinceLastFrame = 0;
                    millisecondsPerFrame = 50;
                }
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                faceRight = true;

                if (prevKey != Keys.Right)
                {
                    prevKey = Keys.Right;
                    currImage = imageList[2];
                    currentFrame = 0;
                    timeSinceLastFrame = 0;
                    millisecondsPerFrame = 50;
                }
            }

            else
            {
                currImage = faceRight ? imageList[0] : imageList[1];

                if (prevKey != Keys.None)
                {
                    prevKey = Keys.None;
                    currentFrame = 0;
                    timeSinceLastFrame = 0;
                    millisecondsPerFrame = 200;
                }
            }

            // Animation frame manager
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;

                currentFrame++;
                timeSinceLastFrame = 0;

                if (currentFrame == columns)
                {
                    currentFrame = 0;
                }
            }

        }

        public void Draw(Camera cam)
        {
            Vector2 pos = Vector2.Transform(position, cam.TranslationMatrix);
            Console.WriteLine("Player Position Camera Space: {0}", pos.ToString());

            int width = currImage.Width / columns;
            int height = currImage.Height;
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, 0, width, height);
            drawRec = new Rectangle((int)pos.X, (int)pos.Y, width, height);
 
            // Draw image
            game.spriteBatch.Begin();
            game.spriteBatch.Draw(currImage, drawRec, sourceRectangle, Color.White);
            game.spriteBatch.End();
        }
    }
}
