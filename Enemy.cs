using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dodge
{
    class Enemy : Sprite
    {
        private Vector2 VSpeed;
        private int Count = 0;
        private Random rnd = new Random();

        public Enemy(Texture2D texture) : base(texture)
        {
            Position.X = rnd.Next(200,Global.DisplayWidth - texture.Width);
            Position.Y = rnd.Next(0,Global.DisplayHeight - texture.Height);
            VSpeed.X = rnd.Next(1, 5);
            VSpeed.Y = rnd.Next(1, 5);
            Health = 10;
            _texture = texture;

        }



        new public void Update()
        {
            MoveEnemy();
            base.Update();
        }
        private void MoveEnemy()
        {
            Position = Position + VSpeed;

            if (Position.X + _texture.Width > Global.DisplayWidth)

            {
                VSpeed.X = -VSpeed.X;
                Count = Count + 1;

            }
            if (Position.X < 0)

            {
                VSpeed.X = -VSpeed.X;

            }
            if (Position.Y + _texture.Height > Global.DisplayHeight)
            {
                VSpeed.Y = -VSpeed.Y;

            }
            if (Position.Y < 0)
            {
                VSpeed.Y = -VSpeed.Y;

            }
        }

    }
}
