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
    public class BrownBlock : Objects
    {
        public int ChangeAble;
        public bool putAble;
        public BrownBlock(Texture2D texture, Rectangle rectangle, Game1 game,bool w,int ChangeAble,bool putAble)
            : base(texture, rectangle, game, w)
        {
            this.putAble = putAble;
            this.ChangeAble = ChangeAble;
        }
        public override void Update(List<Objects> Blockers)
        {

        }
        public void SetTexture(Texture2D Texture)
        {
            texture = Texture;
        }
        public void SetWakable(bool wakable)
        {
            this.wakable = wakable;
        }
        public override void Collsion(Objects player)
        {
            if (!wakable && player is Player)
            {
                player.rectangle.X--;
                ((Player)player).SetPosition(5);
            }
            if (player is MovableObject && Mouse.GetState().LeftButton == ButtonState.Released && !putAble)
            {
                if (player.rectangle.X <= 0)
                    player.rectangle.Y -= 50;
                else
                    player.rectangle.X -= 50;
            }
        }
    }
}
