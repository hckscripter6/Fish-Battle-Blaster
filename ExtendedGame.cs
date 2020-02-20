using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Fish
{

    class ExtendedGame : Game
    {
        public static ContentManager ContentManager { get; private set; }

        protected override void LoadContent()
        {
            ContentManager = Content;
            base.LoadContent();
        }
    }
}
