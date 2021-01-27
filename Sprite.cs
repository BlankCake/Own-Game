using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Dodge
{
    public class Sprite
    {
        public Texture2D _texture;
        public Vector2 Position;
        public Vector2 Velocity;


        public Input Input;

        public int Health = 0;

        public virtual Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }



        public Sprite(Texture2D texture)
        {

            _texture = texture;

        }
        public void Update()
        {

        }
        public void Update(GameTime gameTime)
        {

        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }



    }

}