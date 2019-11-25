using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectRythym
{
    class MonogameSkeleton : DrawableSprite
    {
        private Skeleton skeleton;
        private Texture2D currentTexture;
        private Texture2D rightSprite;
        private Texture2D leftSprite;
        public SkeletonEnum CurrentState
        {
            get { return this.skeleton.CurrentState; }
            set
            {
                if (this.skeleton.CurrentState != value)
                {
                    this.skeleton.CurrentState = value; 
                }
            }
        }
        private float speed = 385;

        public MonogameSkeleton(Game game) : base(game)
        {
            skeleton = new Skeleton();
        }

        public override void Initialize()
        {            
            if (this.skeleton.CurrentState == SkeletonEnum.Left || this.skeleton.CurrentState == SkeletonEnum.Up)
            {
                currentTexture = leftSprite;
            }
            else
            {
                currentTexture = rightSprite;
            }
            this.spriteTexture = this.Game.Content.Load<Texture2D>("skeletonRight");
            this.Origin = new Vector2(this.spriteTexture.Width / 2, this.spriteTexture.Height / 2);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            rightSprite = this.Game.Content.Load<Texture2D>("skeletonRight");
            leftSprite = this.Game.Content.Load<Texture2D>("skeletonLeft");
            this.Speed = speed;
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            this.Location += (this.Direction * (lastUpdateTime / 1000) * speed);
            base.Update(gameTime);
        }
    }
}
