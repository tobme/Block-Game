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
    class Spak3 : Objects
    {
        bool Activate = false;
        bool Hitted = false;
        public List<Player> DeactivatedPlayer;
        Texture2D Orgtexture;
        Texture2D texture2;
        public Spak3(Texture2D texture, Texture2D texture2, Rectangle rectangle, Game1 game, List<Player> DeactivatedPlayer)
            : base(texture, rectangle, game, true)
        {
            this.DeactivatedPlayer = DeactivatedPlayer;
            this.Orgtexture = texture;
            this.texture2 = texture2;
        }

        public override void Update(List<Objects> Blockers)
        {
            if (Hitted)
            {
                Hitted = false;
                foreach (Objects i in Blockers)
                {
                    if (i is Player)
                    {
                        foreach (Player p in DeactivatedPlayer)
                        {
                            if (i == p)
                            {
                                ((Player)i).stuck = false;
                            }
                        }
                    }

                }
            }
        }

        public override void Collsion(Objects player)
        {
            if (player is Player)
            {
                Hitted = true;
                if (!Activate)
                {
                    Activate = true;
                    texture = texture2;
                }
                else
                {
                    Activate = false;
                    texture = Orgtexture;
                }
            }
            if (player is MovableObject && Mouse.GetState().LeftButton == ButtonState.Released)
            {
                if (player.rectangle.X <= 0)
                    player.rectangle.Y -= 50;
                else
                    player.rectangle.X -= 50;
            }
        }
    }
}
