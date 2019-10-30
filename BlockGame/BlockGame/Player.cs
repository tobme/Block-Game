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
    public class Player : Objects
    {
        int Direction;
        Texture2D Texture, Texture2, Texture3, Texture4, jumptexture, stucktexture;
        public bool Jumping;
        int JumpingTimer = 49;
        public bool stuck;

        public Player(Texture2D texture, Texture2D texture2, Texture2D texture3, Texture2D texture4, Texture2D jumptexture, Rectangle rectangle, Game1 game, bool w, int D, bool stuck, Texture2D stucktexture)
            : base(texture, rectangle, game, w)
        {
            this.Texture = texture;
            this.Texture2 = texture2;
            this.Texture3 = texture3;
            this.Texture4 = texture4;
            this.jumptexture = jumptexture;
            this.stucktexture = stucktexture;
            this.Direction = D;
            this.stuck = stuck;
            SetDirection();
            this.rectangle = rectangle;
        }
        public override void Update(List<Objects> Blockers)
        {


            if (game.GameON)
            {
                SetDirection();
            }
            if (!Jumping)
            {
                for (int i = 0; i < Blockers.Count(); i++)
                {
                    if (Blockers[i].CheckCollision(this))
                        Blockers[i].Collsion(this);
                }
            }
            if (Jumping)
            {
                texture = jumptexture;
                JumpingTimer--;
            }

            if (JumpingTimer == 0)
            {
                JumpingTimer = 49;
                Jumping = false;
            }
        }
        public void SetPosition(int D)
        {
            this.Direction = D;
        }
        public int GetPosition()
        {
            return Direction;
        }
        private void SetDirection()
        {
            if (stuck)
                texture = stucktexture;
            else
            {
                if (rectangle.X < -10 || rectangle.Y < -10)
                    Direction = 5;
                if (game.CurrentLvl >= 4)
                {
                    if (rectangle.X > 610 || rectangle.Y > 610)

                        Direction = 5;
                }
                else
                    if (rectangle.X > 460 || rectangle.Y > 460)
                        Direction = 5;

                switch (Direction)
                {
                    case 1:
                        texture = Texture;
                        rectangle.Y -= 2;
                        break;
                    case 2:
                        texture = Texture2;
                        rectangle.X += 2;
                        break;
                    case 3:
                        texture = Texture3;
                        rectangle.Y += 2;
                        break;
                    case 4:
                        texture = Texture4;
                        rectangle.X -= 2;
                        break;
                }
            }
        }
    }

}
