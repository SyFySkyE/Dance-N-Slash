using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectRythym
{
    class MonoGameSwordsPerson : DrawableSprite
    {
        private PlayerController controller;
        private Swordsperson player;
        protected SwordsPersonState currentState;
        public SwordsPersonState CurrentState
        {
            get { return this.currentState; }
            set
            {
                if (this.currentState != value)
                {
                    this.currentState = this.player.CurrentState = value;
                }
            }
        }

        public MonoGameSwordsPerson(Game game) : base(game)
        {
            this.controller = new PlayerController(game);
            player = new Swordsperson();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            this.SpriteTexture = this.Game.Content.Load<Texture2D>("playerStill");
            this.Origin = new Vector2(this.SpriteTexture.Width / 2, this.SpriteTexture.Height / 2);            
        }

        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            this.controller.Update(gameTime);
            HandleControllerInput();
            base.Update(gameTime);
        }

        private void HandleControllerInput()
        {
            switch (this.controller.HandleKeyboard())
            {
                case "Left":
                    break;
                case "Right":
                    break;
                case "Top":
                    break;
                case "Bottom":
                    break;
            }                
        }
    }
}
