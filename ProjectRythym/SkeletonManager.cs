using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectRythym
{
    class SkeletonManager : DrawableGameComponent
    {
        public List<MonogameSkeleton> Skeletons;

        public SkeletonManager(Game game) : base(game)
        {
            Skeletons = new List<MonogameSkeleton>();
        }

        public void AddSkeleton(string direction)
        {
            AddSkeletonToList(direction);
        }

        private void AddSkeletonToList(string direction)
        {
            MonogameSkeleton skeleton = new MonogameSkeleton(this.Game);
            skeleton.Initialize();
            if (direction == "Top")
            {
                skeleton.Direction = new Vector2(0, 1);
                skeleton.Location = new Vector2(GraphicsDevice.Viewport.Width / 2 - skeleton.spriteTexture.Width / 2, 0 - skeleton.spriteTexture.Height);
            }
            else if (direction == "Bottom")
            {
                skeleton.Direction = new Vector2(0, -1);
                skeleton.Location = new Vector2(GraphicsDevice.Viewport.Width / 2 - skeleton.spriteTexture.Width / 2, GraphicsDevice.Viewport.Height + skeleton.spriteTexture.Height);
            }
            else if (direction == "Left")
            {
                skeleton.Direction = new Vector2(1, 0);
                skeleton.Location = new Vector2(0 - skeleton.spriteTexture.Width - skeleton.spriteTexture.Height, GraphicsDevice.Viewport.Height / 2 - skeleton.spriteTexture.Height / 2);
            }
            else if (direction == "Right")
            {
                skeleton.Direction = new Vector2(-1, 0);
                skeleton.Location = new Vector2(GraphicsDevice.Viewport.Width + skeleton.spriteTexture.Width, GraphicsDevice.Viewport.Height / 2 - skeleton.spriteTexture.Height / 2);
            }
            skeleton.SetTranformAndRect();
            skeleton.Enabled = true;
            skeleton.Visible = true;
            Skeletons.Add(skeleton);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            AddSkeleton("Top");
            AddSkeleton("Bottom");
            AddSkeleton("Left");
            AddSkeleton("Right");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < Skeletons.Count; i++)
            {
                Skeletons[i].Update(gameTime);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (MonogameSkeleton skele in Skeletons)
            {
                skele.Draw(gameTime);
            }
            base.Draw(gameTime);
        }
    }
}
