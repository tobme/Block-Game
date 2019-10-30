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
    public class Objects
    {
        public Texture2D texture;
        public Rectangle rectangle;
        public Game1 game;
        public bool wakable;
        public Objects(Texture2D texture, Rectangle rectangle, Game1 game, bool w)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.game = game;
            this.wakable = w;
        }
        public virtual bool iswakable()
        {
            return wakable;
        }
        public virtual void Update(List<Objects> List)
        {

        }
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, rectangle, Color.White);
        }
        public virtual bool CheckCollision(Objects player)
        {
            if (this == player)
                return false;
            if (rectangle.X == player.rectangle.X && rectangle.Y == player.rectangle.Y)
            {
                return true;
            }
            return false;
        }
        public virtual void Collsion(Objects player)
        {

        }
    }
}
