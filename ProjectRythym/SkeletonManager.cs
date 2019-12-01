using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace ProjectRythym
{
    class SkeletonManager : DrawableGameComponent
    {
        private List<MonogameSkeleton> skeletons;
        private List<MonogameSkeleton> deadSkeletons;
        private SongManager songManager;
        private MonoGameSwordsPerson player;
        private float currentTime = 0;
        private bool isPlaying = false;

        public SkeletonManager(Game game, MonoGameSwordsPerson player) : base(game)
        {
            this.player = player;
            skeletons = new List<MonogameSkeleton>();
            songManager = new SongManager(game);           
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
                skeleton.CurrentState = SkeletonEnum.Up;
                skeleton.Direction = new Vector2(0, 1);
                skeleton.Location = new Vector2(GraphicsDevice.Viewport.Width / 2 - skeleton.spriteTexture.Width / 2, 0 - skeleton.spriteTexture.Height);
            }
            else if (direction == "Bottom")
            {
                skeleton.CurrentState = SkeletonEnum.Down;
                skeleton.Direction = new Vector2(0, -1);
                skeleton.Location = new Vector2(GraphicsDevice.Viewport.Width / 2 - skeleton.spriteTexture.Width / 2, GraphicsDevice.Viewport.Height + skeleton.spriteTexture.Height);
            }
            else if (direction == "Left")
            {
                skeleton.CurrentState = SkeletonEnum.Left;
                skeleton.Direction = new Vector2(1, 0);
                skeleton.Location = new Vector2(0 - skeleton.spriteTexture.Width - skeleton.spriteTexture.Height, GraphicsDevice.Viewport.Height / 2 - skeleton.spriteTexture.Height / 2);
            }
            else if (direction == "Right")
            {
                skeleton.CurrentState = SkeletonEnum.Right;
                skeleton.Direction = new Vector2(-1, 0);
                skeleton.Location = new Vector2(GraphicsDevice.Viewport.Width + skeleton.spriteTexture.Width, GraphicsDevice.Viewport.Height / 2 - skeleton.spriteTexture.Height / 2);
            }
            skeleton.SetTranformAndRect();
            skeleton.Enabled = true;
            skeleton.Visible = true;
            skeletons.Add(skeleton);
        }

        public override void Initialize()
        {
            deadSkeletons = new List<MonogameSkeleton>();
            base.Initialize();
            StartSong();            
        }

        private void StartSong()
        {
            songManager.Initialize();
        }

        protected override void LoadContent()
        {
            AddSkeleton("Left");            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (isPlaying)
            {
                SpawnAtBeat(gameTime);
                for (int i = 0; i < skeletons.Count; i++)
                {

                    skeletons[i].Update(gameTime);
                    if (PlayerAttack(skeletons[i]))
                    {
                        skeletons.Remove(skeletons[i]);
                    }
                }
            }
            
            base.Update(gameTime);
        }

        private void SpawnAtBeat(GameTime gameTime)
        {
            float lastUpdateTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            currentTime += lastUpdateTime;
                if ((currentTime / 1000) >= (songManager.Bpm / 60))
                {
                //float newnum = songManager.Bpm - songManager.Bpm / (currentTime / 1000); // if this doesn't work then
                                //newnum = songManager.Bpm - songManager.Bpm / (currentTime / 1000)
                    AddSkeleton("Left");
                    currentTime = 0;
                }
                        
        }

        private bool PlayerAttack(MonogameSkeleton skele)
        {
            foreach (AttackRectangle attackRect in player.attackRects)
            {
                if (skele.Intersects(attackRect))
                {
                    if (skele.CurrentState.ToString() == player.AttackDir.ToString())
                    {
                        return true;
                    }
                }
            }
            if (skele.Intersects(player))
            {
                if (skele.PerPixelCollision(player))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (MonogameSkeleton skele in skeletons)
            {
                skele.Draw(gameTime);
            }
            base.Draw(gameTime);
        }

        public void StartSpawning()
        {
            isPlaying = true;
        }
    }
}
