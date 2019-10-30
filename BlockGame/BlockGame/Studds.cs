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
    public class Studds : MovableObject
    {
        bool Movable;
        public Studds(Texture2D texture, Rectangle rectangle, Game1 game, bool w,bool Movable)
            : base(texture, rectangle, game, w, Movable)
        {
            this.Movable = Movable;
        }
        public override void Collsion(Objects player)
        {
            if (player is Player && game.GameON)
                ((Player)player).Jumping = true;

            base.Collsion(player);
        }
    }
}
