using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public enum PlayerState { Idle, AttackLeft, AttackRight, AttackUp, AttackDown }

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
        protected PlayerState playerState = PlayerState.Idle;
        private Texture2D idleTexture;
        private Texture2D attackLeftTexture;
        private Texture2D attackRightTexture;
        private Texture2D attackUpTexture;
        private Texture2D attackDownTexture;
        private float currentTime = 0f;
        private float timeBeforeIdleReset = 1f;

        public MonoGameSwordsPerson(Game game) : base(game)
        {
            this.controller = new PlayerController(game);
            player = new Swordsperson();
            this.showMarkers = true;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            LoadTextures();
            this.spriteTexture = idleTexture;
            this.Origin = new Vector2(this.SpriteTexture.Width / 2, this.SpriteTexture.Height / 2);
            this.Location = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
        }

        private void LoadTextures()
        {
            idleTexture = this.Game.Content.Load<Texture2D>("playerIdle");
            attackLeftTexture = this.Game.Content.Load<Texture2D>("playerAttackLeft");
            attackRightTexture = this.Game.Content.Load<Texture2D>("playerAttackRight");
            attackUpTexture = this.Game.Content.Load<Texture2D>("playerAttackUp");
            attackDownTexture = this.Game.Content.Load<Texture2D>("playerAttackDown");
        }

        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            this.controller.Update(gameTime);
            HandleControllerInput(time);
            base.Update(gameTime);
        }

        private void HandleControllerInput(float timeInMs)
        {
            switch (this.controller.HandleKeyboard())
            {
                case "Left":
                    AttackLeft();
                    break;
                case "Right":
                    AttackRight();
                    break;
                case "Top":
                    AttackTop();
                    break;
                case "Bottom":
                    AttackDown();
                    break;
            }
            ResetIdleSprite(timeInMs);
        }

        private void AttackLeft()
        {
            this.spriteTexture = attackLeftTexture;
            Point topLeftPoint = new Point(this.locationRect.Left - this.spriteTexture.Width, this.locationRect.Top);
            Point bottomRightPoint = new Point(this.locationRect.Left, this.locationRect.Bottom);
            Rectangle attackZoneLeft = new Rectangle(topLeftPoint, bottomRightPoint);            
        }

        private void AttackRight()
        {
            this.spriteTexture = attackRightTexture;
            Point topLeftPoint = new Point(this.locationRect.Right, this.locationRect.Top);
            Point bottomRightPoint = new Point(this.locationRect.Right + this.spriteTexture.Width, this.locationRect.Bottom);
            Rectangle attackZoneRight = new Rectangle(topLeftPoint, bottomRightPoint);
        }

        private void AttackTop()
        {
            this.spriteTexture = attackUpTexture;
            Point topLeftPoint = new Point(this.locationRect.Left, this.locationRect.Top - spriteTexture.Height);
            Point bottomRightPoint = new Point(this.locationRect.Right, this.locationRect.Top);
            Rectangle attackZoneTop = new Rectangle(topLeftPoint, bottomRightPoint);
        }

        private void AttackDown()
        {
            this.spriteTexture = attackDownTexture;
            Point topLeftPoint = new Point(this.locationRect.Left, this.locationRect.Bottom);
            Point bottomRightPoint = new Point(this.locationRect.Right, this.locationRect.Bottom + this.spriteTexture.Height);
            Rectangle attackZoneBottom = new Rectangle(topLeftPoint, bottomRightPoint);
        }
        
        private void ResetIdleSprite(float timeInMs)
        {
            if (this.spriteTexture != idleTexture && controller.HandleKeyboard() == "No Input")
            {                
                currentTime += timeInMs / 1000;
                if (currentTime >= timeBeforeIdleReset)
                {
                    this.spriteTexture = idleTexture;
                    currentTime = 0f;
                }
            }
            else if (controller.HandleKeyboard() != "No Input")
            {
                currentTime = 0f;
            }
        }
    }
}
