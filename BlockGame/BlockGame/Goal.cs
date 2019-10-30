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
    public class Goal : Objects
    {
        public Goal(Texture2D texture, Rectangle rectangle, Game1 game)
            : base(texture, rectangle, game, true)
        {
        }
        
        public override void Collsion(Objects player)
        {
            if (player is Player)
            {
                player.rectangle.X = -1000;
                game.CurrentLvl++;
                game.Restart();
            }
        }

    }
}
