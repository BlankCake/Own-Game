using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dodge
{
    class Pipe
    {
        private Random rnd = new Random();
        public Vector2 Position;
        public Vector2 Velocity;
        public int  speed = 1;

        public Rectangle oben = new Rectangle();
        public Rectangle unten = new Rectangle();

        Texture2D _oben;
        Texture2D _unten;

        public Pipe(Texture2D Oben, Texture2D Unten) 
        {
            
            Position.Y = rnd.Next(-350, -150);

            _oben = Oben;
            _unten = Unten;

            oben.X = (int)Global.DisplayWidth;
            oben.Y = (int)Position.Y;
            oben.Width = _oben.Width;
            oben.Height = _oben.Height;

            unten.X = (int)Global.DisplayWidth;
            unten.Y = (int)Position.Y + 480 + 150;
            unten.Width = _oben.Width;
            unten.Height = _oben.Height;

        }




        public void Update()
        {
            oben.X -= speed;
            unten.X -= speed;
        }

        public  void Update(GameTime gameTime, List<Pipe> sprites)
        {

        }


        public  void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_oben, oben, Color.White);
            spriteBatch.Draw(_unten, unten, Color.White);
        }

    }
}   
