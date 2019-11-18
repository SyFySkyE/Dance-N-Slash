using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectRythym
{
    class PlayerController : GameComponent
    {
        InputHandler input;
        public string lastInput = "";

        public PlayerController(Game game) : base(game)
        {
            input = (InputHandler)game.Services.GetService(typeof(IInputHandler));
            if (input == null)
            {
                input = new InputHandler(game, true);
                game.Components.Add(input);
            }
        }

        public override void Update(GameTime gameTime)
        {
            HandleKeyboard();
            base.Update(gameTime);
        }

        private void HandleKeyboard()
        {
            if (input.KeyboardState.WasKeyPressed(Keys.A) || input.KeyboardState.WasKeyPressed(Keys.Left))
            {
                lastInput = "Player pushed Left";
            }
            if (input.KeyboardState.WasKeyPressed(Keys.D) || input.KeyboardState.WasKeyPressed(Keys.Right))
            {
                lastInput = "Player pushed Right";
            }
            if (input.KeyboardState.WasKeyPressed(Keys.W) || input.KeyboardState.WasKeyPressed(Keys.Up))
            {
                lastInput = "Player pushed Up";
            }
            if (input.KeyboardState.WasKeyPressed(Keys.S) || input.KeyboardState.WasKeyPressed(Keys.Down))
            {
                lastInput = "Player pushed Down";
            }
        }
    }
}
