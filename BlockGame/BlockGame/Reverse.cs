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
    public class Reverse : MovableObject
    {
        public Reverse(Texture2D texture, Rectangle rectangle, Game1 game, bool w)
            : base(texture, rectangle, game, w,true)
        {

        }
        public override void Collsion(Objects player)
        {
            if (player is Player)
            {
                int PlayerPos = ((Player)player).GetPosition();

                if (PlayerPos < 3)
                {
                    ((Player)player).SetPosition((PlayerPos + 2));
                }
                else
                {
                    ((Player)player).SetPosition((PlayerPos - 2));
                }
            }
        }
    }
}
