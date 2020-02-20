using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Fish
{
    class GameObjects
    {
        protected Vector2 position, origin, velocity, direction;
        protected Texture2D mainSprite;
        protected float angle;

        public GameObjects(string sprite)
        {
            mainSprite = ExtendedGame.ContentManager.Load<Texture2D>(sprite);

            position = Vector2.Zero;
            origin = Vector2.Zero;
            velocity = Vector2.Zero;
            direction = Vector2.Zero;
            angle = 0;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(mainSprite, position, null, Color.White, angle, origin, 1.0f, SpriteEffects.None, 0);
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

    }
}
