using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Fish
{
    class Player
    {
        public static Vector2 position;
        private Vector2 direction, origin;
        private float angle;
        private float speed;
        private float startSpeed = 225;
        bool setToFire;
        int health = 7;
        private int radius = 25;

        

        public Player()
        {
            position = new Vector2(100, 100);
            speed = startSpeed;
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            KeyboardState keyboard = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 mousePosition = new Vector2(mouse.X, mouse.Y);

            double opposite = mousePosition.Y - position.Y;
            double adjacent = mousePosition.X - position.X; 

            angle = (float)Math.Atan2(opposite, adjacent);

            if (position.X > 0)           { position.X -= dt * speed; }
            if (position.X < Fish.width)  { position.X += dt * speed; }
            if (position.Y > 0)           { position.Y -= dt * speed; }
            if (position.Y < Fish.height) { position.Y += dt * speed; }


               if (keyboard.IsKeyDown(Keys.W))
                {

                
                        if (Vector2.Distance(position, mousePosition) > 35)
                        {
                            speed = startSpeed;
                            direction = mousePosition - position;
                            direction.Normalize();

                                position += dt * direction * speed;
                        } else
                        {
                            speed = 0;
                        }

                }

            
            if (keyboard.IsKeyDown(Keys.D) && setToFire)
            {
                Projectile.projectiles.Add(new Projectile(400, position, true));
                setToFire = false;
            } else if (keyboard.IsKeyUp(Keys.D))
            {
                setToFire = true;
            }

 

        }

        public void Reset()
        {
            position = new Vector2(100, 100);
            health = 7;
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }
    }
}

