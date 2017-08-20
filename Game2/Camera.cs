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
        public Vector2 Position;
        public float Zoom;
        public float Rotation;

        public int ViewportWidth;
        public int ViewportHeight;
    }
}
