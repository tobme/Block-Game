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
    class Spak2 : Objects
    {
        bool Activate = false;
        bool Hitted = false;
        List<Objects> Changers = new List<Objects>();
        List<int> NewDirections = new List<int>();
        List<int> CurrentDirections = new List<int>();
        Texture2D Orgtexture;
        Texture2D texture2;

        public Spak2(Texture2D texture, Texture2D texture2, Rectangle rectangle, Game1 game, List<Objects> Changers,List<int> NewDirections,List<int> CurrentPos)
            : base(texture, rectangle, game, true)
        {
            this.CurrentDirections = CurrentPos;
            this.NewDirections = NewDirections;
            this.Orgtexture = texture;
            this.texture2 = texture2;
            this.Changers = Changers;
        }

         public override void Update(List<Objects> Blockers)
        {
                foreach (Objects i in Blockers)
                {
                    if (i is Arrow)
                    {
                        for (int j = 0; j < Changers.Count; j++)
                        {
                            if (i == Changers[j])
                            {
                                if (Mouse.GetState().X >= this.rectangle.X && Mouse.GetState().Y >= this.rectangle.Y && Mouse.GetState().Y <= this.rectangle.Y + 50 && Mouse.GetState().X <= this.rectangle.X + 50 && !game.GameON && Mouse.GetState().RightButton == ButtonState.Pressed)
                                {
                                    ((Arrow)i).Direction = NewDirections[j];
                                }
                                else if (Hitted && !((Arrow)i).Movable)
                                {
                                    ((Arrow)i).Direction = NewDirections[j];
                                    Hitted = false;
                                }
                                else if (!game.GameON)
                                    ((Arrow)i).Direction = CurrentDirections[j];
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
