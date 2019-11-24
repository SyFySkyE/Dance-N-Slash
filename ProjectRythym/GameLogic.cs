using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectRythym
{
    //class GameLogic : DrawableGameComponent
    //{
    //    MonoGameSwordsPerson player;
    //    SkeletonManager enemySpawner;
    //    ScoreManager score;
    //    SpriteBatch sb;

    //    public GameLogic(Game game, SpriteBatch sb) : base(game)
    //    {
    //        this.sb = sb;
    //        player = new MonoGameSwordsPerson(game);
    //        enemySpawner = new SkeletonManager(game);
    //    }

    //    public override void Initialize()
    //    {
    //        base.Initialize();
    //    }

    //    protected override void LoadContent()
    //    {
    //        base.LoadContent();
    //    }

    //    public override void Update(GameTime gameTime)
    //    {
    //        foreach (MonogameSkeleton skele in enemySpawner.Skeletons)
    //        {
    //            if (skele.Intersects(player))
    //            {
    //                ScoreManager.Lives--;
    //                ScoreManager.Score--;
    //            }
    //        }
    //        base.Update(gameTime);
    //    }

    //    public override void Draw(GameTime gameTime)
    //    {
    //        sb.Begin();
    //        enemySpawner.Draw(gameTime);
    //        player.Draw(gameTime);
    //        sb.End();
    //        base.Draw(gameTime);
    //    }
    //}
}
