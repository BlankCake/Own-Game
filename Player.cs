using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dodge
{
    class Player : Sprite
    {
        public float Speed = 5f;
        bool hasShoot = false;
        public float Speedgravity = 0f;

        public List<Bullet> bullet = new List<Bullet>();

        public Rectangle player = new Rectangle();

        public Texture2D texBullet;

        public Player(Texture2D texture) : base(texture)
        {
            _texture = texture;
            Health = 10;
        }



        new public void Update()
        {
            Move();
            Global.PlayerX = Position.X;
            Global.PlayerY = Position.Y;
            base.Update();

            foreach( Bullet b in bullet){
                b.Update();
            }

        }

        private void Move()
        {
            if (Global.lv1 == true)
            {
                

            if (Input == null)
                return;

            if (Keyboard.GetState().IsKeyDown((Keys)Input.Left))
            {
                Position.X -= Speed;
            }
            if (Keyboard.GetState().IsKeyDown((Keys)Input.Right))
            {
                Position.X += Speed;
            }
            if (Keyboard.GetState().IsKeyDown((Keys)Input.Up))
            {
                Position.Y -= Speed;
            }
            if (Keyboard.GetState().IsKeyDown((Keys)Input.Down))
            {
                Position.Y += Speed;
            }

            }


            if (Global.lv2 == true)
            {    
                Speed = 0;
                Position.X = 400;

                if (Keyboard.GetState().IsKeyDown((Keys)Input.Jump))
                {
                    Position.Y -= 3;
                    Speedgravity = 0;
                }


                if (Position.Y > -500)
                {
                    Position.Y += Speedgravity;
                }

                if (Position.Y > -500)

                    Speedgravity = Speedgravity + 0.2f;
            }

            if (Global.lv3 == true)
            {
                Speed = 5f;

                Position.X = 0f;

                if (Keyboard.GetState().IsKeyDown((Keys)Input.Shoot) && hasShoot == false)
                {
                    bullet.Add(new Bullet(texBullet, Position));
                    hasShoot = true;

                }

                if (Keyboard.GetState().IsKeyUp((Keys)Input.Shoot)) 
                {
                    hasShoot = false;
                }


                if (Keyboard.GetState().IsKeyDown((Keys)Input.Left))
                {
                    Position.X -= 0;
                }
                if (Keyboard.GetState().IsKeyDown((Keys)Input.Right))
                {
                    Position.X += 0;
                }
                if (Keyboard.GetState().IsKeyDown((Keys)Input.Up))
                {
                    Position.Y -= Speed;
                }
                if (Keyboard.GetState().IsKeyDown((Keys)Input.Down))
                {
                    Position.Y += Speed;
                }

                //cheat
                if (Keyboard.GetState().IsKeyDown((Keys)Input.Cheat))
                {
                    bullet.Add(new Bullet(texBullet, Position));
                }




                    foreach (Bullet b in bullet.ToList()) { 
                    if(b.bullet.X > Global.DisplayWidth)
                    {
                        bullet.RemoveAt(0);
                    }
                }

            }
            


        }

        public void Draw(SpriteBatch spriteBatch) {

            foreach (Bullet e in bullet) {
                e.Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }


    }
}
