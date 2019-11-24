using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectRythym
{
    class ScoreManager : DrawableGameComponent
    {
        SpriteFont font;
        public static int Lives;
        private static int startLives = 8;
        public static int Score;

        private SpriteBatch sb;
        private Vector2 livesLoc, scoreLoc;

        public ScoreManager(Game game) : base(game)
        {
            SetUpGame();
        }

        private static void SetUpGame()
        {
            Lives = startLives;
            Score = 0;
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            font = this.Game.Content.Load<SpriteFont>("SpriteFont1");
            livesLoc = Vector2.Zero;
            scoreLoc = new Vector2(0, 100);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.DrawString(font, "Lives: " + Lives, livesLoc, Color.White);
            sb.DrawString(font, "Score: " + Score, scoreLoc, Color.White);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
