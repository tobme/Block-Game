using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BlockGame
{
    public class RestartButton : Objects
    {
        int waiter = 10;
          public RestartButton(Texture2D texture, Rectangle rectangle, Game1 game,bool w)
            : base(texture, rectangle, game, w)

        {
        }
        public override void Update(List<Objects> Blockers)
        {
            if (Mouse.GetState().X >= 450 && Mouse.GetState().X <= 500 && Mouse.GetState().Y >= 50 && Mouse.GetState().Y <= 100 && Mouse.GetState().LeftButton == ButtonState.Pressed && waiter == 0)
            {
                game.GameON = false;
                Lvls.MakeLevers(game, Blockers);
                Lvls.MakePlayers(game, Blockers);
                waiter = 10;
            }
            else if (waiter == 0)
                waiter = 10;
            else
                waiter--;

        }
    }
}
