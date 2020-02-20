using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Fish
{


    class Projectile
    {
        private Vector2 position, direction;
        private float speed;
        private bool isFromPlayer;
        private int radius = 5;
        private bool collided = false;

        public static List<Projectile> projectiles = new List<Projectile>();

        public Projectile(float newSpeed, Vector2 newPos, bool isPlayer)
        {
            position = newPos;
            isFromPlayer = isPlayer;
            speed = newSpeed;

            MouseState mouse = Mouse.GetState();
            Vector2 mousePos = new Vector2(mouse.X, mouse.Y);

            if (isFromPlayer)
            {
                direction = mousePos - position;
            } else
            {
                direction = Player.position - position;
            }

            direction.Normalize();
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += speed * direction * dt;

            
        }

        public Vector2 Position {
            get { return position; }
            set { position = value; }
        }

        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public bool Collided
        {
            get { return collided; }
            set { collided = value; }
        }
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public bool IsFromPlayer
        {
            get { return isFromPlayer; }
            set { isFromPlayer = value; }
        }
    }
}
