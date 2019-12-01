using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace ProjectRythym
{    
    class SongManager : GameComponent
    {
        private Song song;
        private int bpm = 60;
        public int Bpm { get { return this.bpm; } }
        private float previousFrameTime;

        public SongManager( Game game) : base(game)
        {            
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }

        public override void Initialize()
        {
            song = Game.Content.Load<Song>("metro");            
            MediaPlayer.IsRepeating = true;
            base.Initialize();
        }

        private void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            MediaPlayer.Volume = 0.5f;            
        }

        public override void Update(GameTime gameTime)
        {
            previousFrameTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            
            base.Update(gameTime);
        }

        public void PlaySong()
        {
            MediaPlayer.Play(song);
        }
    }    
}
