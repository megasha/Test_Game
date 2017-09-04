using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Xna.Framework;

namespace Game2
{
    class Camera
    {
        public Camera()
        {
            Zoom = 1.0f;
            Position = new Vector2(0, 0);
        }
    
        public Player Player { get; set; }
        public Vector2 Position { get; set; }
        public float Zoom { get; private set; }
        public float Rotation { get; private set; }

        public int ViewportWidth { get; set; }
        public int ViewportHeight { get; set; }

        public Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(ViewportWidth * 0.5f, ViewportHeight * 0.5f);
            }
        }

        public Matrix TranslationMatrix
        {
            get
            {
                return Matrix.CreateTranslation(-(int)Position.X, -(int)Position.Y, 0) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                    Matrix.CreateTranslation(new Vector3(ViewportCenter, 0));
            }
        }

        public void AdjustZoom(float amount)
        {
            Zoom += amount;
            if (Zoom < 0.25f )
            {
                Zoom = 0.25f;
            }
        }

        public void MoveCamera(Vector2 cameraMovement, bool clampToMap = false)
        {
            Position += cameraMovement;
        }

        public void SetFocus(Player player)
        {
            Player = player;
            Position = player.position;
        }

        public void FollowFocus()
        {
            Vector2 currPos = Position;
            Vector2 playerPosWorld = Vector2.Transform(Player.position, TranslationMatrix);
            Vector2 playerBound = new Vector2(Player.drawRec.Width, Player.drawRec.Height);

            float left = playerPosWorld.X;
            float top = playerPosWorld.Y;
            float right = playerPosWorld.X + playerBound.X;
            float bottom = playerPosWorld.Y + playerBound.Y;

            if (right >= ViewportWidth)
            {
                currPos.X += right - ViewportWidth;
            }

            else if (left < 0)
            {
                currPos.X += left;
            }

            if (bottom >= ViewportHeight)
            {
                currPos.Y += bottom - ViewportHeight; 
            }

            else if (top < 0)
            {
                currPos.Y += top;
            }

            Position = currPos;

        }



        public void Update(GameTime gameTime)
        {
            FollowFocus();
        }


    }
}
