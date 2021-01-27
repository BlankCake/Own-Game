using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;


namespace Dodge
{
    class Bullet
    {
        public int speed = 10;
        public Vector2 Position;

        public Rectangle bullet = new Rectangle();

        Texture2D _bullet;

 
        public Bullet(Texture2D texBullet, Vector2 Pos)
        {
            _bullet = texBullet;
            bullet.Width = _bullet.Width;
            bullet.Height = _bullet.Height;
            bullet.X = (int)Pos.X;
            bullet.Y = (int)Pos.Y+15;
        }

        public void Update()
        {
            bullet.X += speed;
        }

        public void Update(GameTime gameTime, List<Bullet> sprites)
        {

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_bullet, bullet, Color.White);
        }
    }
}
