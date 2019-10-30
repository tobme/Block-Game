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
    public class Arrow : MovableObject
    {
        public int Direction;
        float Rotation = 0;
        int Wait = 30;
        bool Multi;
        public bool Movable;
        public Arrow(Texture2D texture, Rectangle rectangle, Game1 game, int D, bool Multi,bool Movable)
            : base(texture, rectangle, game, true, Movable)
        {
            this.Movable = Movable;
            this.Multi = Multi;
            this.Direction = D;
        }
        public override void Update(List<Objects> List)
        {
            if (Mouse.GetState().X >= rectangle.X && Mouse.GetState().X <= rectangle.X + 50 && Mouse.GetState().Y >= rectangle.Y && Mouse.GetState().Y <= rectangle.Y + 50 && Mouse.GetState().RightButton == ButtonState.Pressed && Wait == 0 && !game.GameON && Movable)
            {
                if (Direction == 4)
                    Direction = 0;
                else
                    Direction++;

                Wait = 30;
            }
            else if (Wait == 0)
                Wait = 30;
            else
                Wait--;


            base.Update(List);
        }

        public override void Collsion(Objects player)
        {
            if (player is Player && game.GameON)
                ((Player)player).SetPosition(Direction);
            if (Multi && game.GameON && player is Player)
            {
                if (Direction == 4)
                    Direction = 1;
                else
                    Direction++;
            }
            base.Collsion(player);
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            Rotation = (float)((Direction * Math.PI / 2) - (Math.PI / 2));
            spritebatch.Draw(texture, new Vector2(rectangle.X + 25, rectangle.Y + 25), null, Color.White, Rotation, new Vector2(25, 25), 1, SpriteEffects.None, 0);
        }
        
    }
}
