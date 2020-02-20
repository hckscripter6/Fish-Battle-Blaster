using Microsoft.Xna.Framework;
using System;

namespace Fish
{
    class Enemy
    {
        Vector2 position, direction;
        float speed = 60;
        double countDown;
        Random rand = new Random();
        int health = 12;
        int radius = 30;

        double startCount;

        public Enemy(Vector2 newPos)
        {
            position = newPos;

            startCount = 1;
            countDown = startCount;
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            direction = Player.position - position;
            direction.Normalize();
            position += speed * dt * direction;

            countDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (countDown <= 0)
            {
                Projectile.projectiles.Add(new Projectile(350, position , false));
                countDown = rand.NextDouble();
            }



        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
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

        public void Reset()
        {
            position = new Vector2(500, 300);
            health = 12;
        }

    }
}
