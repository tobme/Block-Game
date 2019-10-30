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
    class Spak : Objects
    {
        bool Activate = false;
        bool Hitted = true;
        int ChangeGrass = 1;
        int ChangeFloor = 2;
        public List<Objects> Changers = new List<Objects>();
        Texture2D Orgtexture;
        Texture2D texture2;
        Texture2D Floor, Grass;
        public Spak(Texture2D texture, Texture2D texture2, Texture2D Grass, Texture2D Floor, Rectangle rectangle, Game1 game, List<Objects> Changers)
            : base(texture, rectangle, game, true)
        {
            this.Grass = Grass;
            this.Floor = Floor;
            this.Orgtexture = texture;
            this.texture2 = texture2;
            this.Changers = Changers;
        }
        public override void Update(List<Objects> Blockers)
        {
                foreach (Objects i in Blockers)
                {
                    if (i is BrownBlock)
                    {
                        foreach (Objects j in Changers)
                        {
                            if (i == j)
                            {

                                if (((BrownBlock)i).ChangeAble == ChangeFloor)
                                {
                                    if (Mouse.GetState().X >= this.rectangle.X && Mouse.GetState().Y >= this.rectangle.Y && Mouse.GetState().Y <= this.rectangle.Y + 50 && Mouse.GetState().X <= this.rectangle.X + 50 && !game.GameON && Mouse.GetState().RightButton==ButtonState.Pressed)
                                    {
                                        ((BrownBlock)i).SetTexture(Grass);
                                    }
                                    else if (Hitted)
                                    {
                                        ((BrownBlock)i).SetTexture(Floor);
                                        ((BrownBlock)i).SetWakable(true);
                                    }
                                    else if (!game.GameON)
                                        ((BrownBlock)i).SetTexture(Floor);
                                }
                                else if (((BrownBlock)i).ChangeAble == ChangeGrass)
                                {
                                    if (Mouse.GetState().X >= this.rectangle.X && Mouse.GetState().Y >= this.rectangle.Y && Mouse.GetState().Y <= this.rectangle.Y + 50 && Mouse.GetState().X <= this.rectangle.X + 50 && !game.GameON && Mouse.GetState().RightButton == ButtonState.Pressed)
                                    {
                                        ((BrownBlock)i).SetTexture(Floor);
                                    }
                                    else if (Hitted)
                                    {
                                        ((BrownBlock)i).SetTexture(Grass);
                                        ((BrownBlock)i).SetWakable(false);
                                    }
                                    else if (!game.GameON)
                                        ((BrownBlock)i).SetTexture(Grass);
                                }  
                        }
                    }

                }
            }
                if (Hitted)
                    Hitted = false;

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
                    ChangeFloor = 1;
                    ChangeGrass = 2;
                }
                else
                {
                    Activate = false;
                    texture = Orgtexture;
                    ChangeFloor = 2;
                    ChangeGrass = 1;
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
