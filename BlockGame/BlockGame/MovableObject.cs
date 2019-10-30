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
    public class MovableObject : Objects
    {
        bool Move = false;
        bool DontPick = false;
        bool Movable;
        public MovableObject(Texture2D texture, Rectangle rectangle, Game1 game, bool w,bool Movable)
            : base(texture, rectangle, game, w)
        {
            this.Movable = Movable;
        }
        public override void Update(List<Objects> List)
        {
            if (!game.GameON)
            {
                if (Mouse.GetState().X >= rectangle.X && Mouse.GetState().X <= rectangle.X + 50 && Mouse.GetState().Y >= rectangle.Y && Mouse.GetState().Y <= rectangle.Y + 50 && Mouse.GetState().LeftButton == ButtonState.Pressed && CheckMove(List) && DontPick && Movable)
                {

                        Move = true;
                        rectangle.X = Mouse.GetState().X - 25;
                        rectangle.Y = Mouse.GetState().Y - 25;
                        DontPick = true;
                }
                else if (Move)
                {
                    int stateX = Mouse.GetState().X;
                    int stateY = Mouse.GetState().Y;

                    while (stateX % 50 != 0)
                    {
                        stateX--;
                    }
                    while (stateY % 50 != 0)
                    {
                        stateY--;
                    }

                    rectangle.X = stateX;
                    rectangle.Y = stateY;
                    Move = false;
                    DontPick = false;
                }
                for (int i = 0; i < List.Count; i++)
                {
                    if (List[i].CheckCollision(this))
                    {
                        List[i].Collsion(this);
                    }
                }
            }
        }
        private bool CheckMove(List<Objects> List)
        {
            int Counter = 0;
            foreach (Objects i in List)
            {
                if (i is MovableObject && ((MovableObject)i).DontPick)
                {
                    Counter++;
                }
            }

            if (Counter <= 1 && Movable)
            {
                if (Counter < 1)
                    DontPick = true;
                return true;
            }
            else
                return false;
        }
        public override void Collsion(Objects player)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Released && player is MovableObject)
            {
                if (this is Arrow)
                {
                    if (((Arrow)this).DontPick)
                        return;
                }
                if (this is Studds)
                {
                    if (((Studds)this).DontPick)
                        return;
                }
                if (player.rectangle.X <= 0)
                    player.rectangle.Y -= 50;
                else
                      player.rectangle.X -= 50;
            }
        }
    }
}
