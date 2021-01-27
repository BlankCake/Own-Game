using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;



namespace Dodge
{
    class Boss : Sprite
    {

        public int speed = 3;
        private Vector2 VSpeed;
        private int Count = 0;
        public Rectangle boss = new Rectangle();
        private Random rnd = new Random();

        public List<Bullet> bullet = new List<Bullet>();
        public Texture2D texBullet;

        public Boss(Texture2D texture) : base(texture)
        {
            _texture = texture;
            Health = 100;

            Position.X = Global.DisplayWidth - 80;
        }

        new public void Update(GameTime gameTime)
        {
            Move(gameTime);
            base.Update();

            foreach (Bullet b in bullet)
            {
                b.Update();
            }

        }

        private void Move(GameTime gameTime)
        {


            if (Global.lv3 == true)
            {

                if (Position.Y < Global.PlayerY)
                {
                    Position.Y += 3f;
                }
                else if (Position.Y >= Global.PlayerY) {
                    Position.Y -= 3f;
                }

                if (Math.Abs(Position.Y - Global.PlayerY) < 50 && gameTime.TotalGameTime.TotalSeconds % 2 < 1) {
                    bullet.Add(new Bullet(texBullet, Position));
                    
                }

                foreach (Bullet b in bullet.ToList())
                {
                    b.speed = -10;
                    if (b.bullet.X > Global.DisplayWidth)
                    {
                        bullet.RemoveAt(0);
                    }
                }

            }



        }

        public void Draw(SpriteBatch spriteBatch)
        {

            foreach (Bullet e in bullet)
            {
                e.Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }

    }
}
