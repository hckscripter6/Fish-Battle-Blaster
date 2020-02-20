using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Fish
{
    public class Fish : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player = new Player();
        Enemy enemy;

        Texture2D fishSprite;
        Texture2D monsterSprite;
        Texture2D projectileSprite;

        static public float height;
        static public float width;
        static public Random rand = new Random();

        SpriteFont debug;
        SpriteFont winScreen;
        SpriteFont loseScreen;

        bool win = false;
        bool lose = false;

        public Fish()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            width = graphics.PreferredBackBufferWidth;
            height = graphics.PreferredBackBufferHeight;
        }


        protected override void Initialize()
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            fishSprite = Content.Load<Texture2D>("fish");
            monsterSprite = Content.Load<Texture2D>("redEnemy");
            projectileSprite = Content.Load<Texture2D>("projectile");
            enemy = new Enemy(new Vector2(500, 300));
            debug = Content.Load<SpriteFont>("debug");
            winScreen = Content.Load<SpriteFont>("debug");
            loseScreen = Content.Load<SpriteFont>("debug");
        }


        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (!win && !lose)
            {
                player.Update(gameTime);
                enemy.Update(gameTime);

               
                if (Vector2.Distance(enemy.Position, player.Position) < 40)
                {
                    player.Health = 0;
                    lose = true;
                }

                foreach (Projectile proj in Projectile.projectiles)
                {
                    proj.Update(gameTime);
                }

                foreach (Projectile proj in Projectile.projectiles)
                {
                    int sum = enemy.Radius - proj.Radius;
                    if (Vector2.Distance(proj.Position, enemy.Position) < sum && proj.IsFromPlayer)
                    {
                        proj.Collided = true;
                        enemy.Health--;
                        if (enemy.Health <= 0)
                        {
                            win = true;
                        }
                    }

                    if (Vector2.Distance(proj.Position, player.Position) < sum && !proj.IsFromPlayer)
                    {
                        proj.Collided = true;
                        player.Health--;
                        if (player.Health <= 0)
                        {
                            lose = true;
                        }
                    }


                }

                Projectile.projectiles.RemoveAll(p => p.Collided);
            } else
            {
                KeyboardState kstate = Keyboard.GetState();
                bool space = kstate.IsKeyDown(Keys.Space);
                if (space)
                {
                    enemy.Reset();
                    player.Reset();
                    win = false;
                    lose = false;
                    Projectile.projectiles.Clear();
                }
                
            }




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aqua);
            spriteBatch.Begin();
            spriteBatch.DrawString(debug, "Battle Blaster! \n mouse cursor -> direction; W -> move; D -> shoot", Vector2.Zero, Color.Black);
            foreach (Projectile proj in Projectile.projectiles)
            {
                spriteBatch.Draw(projectileSprite, proj.Position, null, Color.White, 0, new Vector2(projectileSprite.Height, projectileSprite.Width) / 2, .5f, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(fishSprite, player.Position, null, Color.White, player.Angle, new Vector2(fishSprite.Height, fishSprite.Width) / 2, 2.0f, SpriteEffects.None, 0);
            spriteBatch.Draw(monsterSprite, enemy.Position, null, Color.White, 0, new Vector2(monsterSprite.Height, monsterSprite.Width) / 2, 2.0f, SpriteEffects.None, 0);


            

            if (win)
            {
                spriteBatch.DrawString(winScreen, "You Win! Press space bar to play again", new Vector2(400, 250), Color.Black);
            }
            if (lose)
            {
                spriteBatch.DrawString(loseScreen, "You Lost! Press space bar to play again", new Vector2(400, 250), Color.Black);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
