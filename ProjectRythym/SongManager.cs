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

        public SongManager( Game game) : base(game)
        {
            
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

        }

        public override void Initialize()
        {
            song = Game.Content.Load<Song>("metro");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            base.Initialize();
        }

        private void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            MediaPlayer.Volume = 1f;            
        }        
    }    
}
