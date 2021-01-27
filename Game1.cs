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
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Enemy> enemies = new List<Enemy>();
        private List<Pipe> pipe = new List<Pipe>();
        private List<Boss> boss = new List<Boss>();
        private Player player;
        Texture2D texPipeUnten;
        Texture2D texPipeOben;
        Texture2D texBoss;
        Texture2D texBullet;

        bool content2 = false;
        bool content3 = false;


        Vector2 SpriteMoveVogel = new Vector2(100, 100);

        public float Speedgravity = 0f;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            Global.DisplayWidth = _graphics.GraphicsDevice.Viewport.Width;
            Global.DisplayHeight = _graphics.GraphicsDevice.Viewport.Height;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            var texPlayer = Content.Load<Texture2D>("Image/BlackCubeDodge");
            var texEnemy = Content.Load<Texture2D>("Image/RedCubeDodge");
            texPipeUnten = Content.Load<Texture2D>("Image/PipeUnten");
            texPipeOben = Content.Load<Texture2D>("Image/PipeOben");
            texBoss = Content.Load<Texture2D>("Image/Boss");
            texBullet = Content.Load<Texture2D>("Image/Bullet");

            player = new Player(texPlayer);
            player.texBullet = texBullet;
            player.Position = new Vector2(100, 200);
            player.Input = new Input()
            {
                Left = Keys.A,
                Right = Keys.D,
                Up = Keys.W,
                Down = Keys.S,
                Jump = Keys.Space,
                Shoot = Keys.Space,
                Cheat = Keys.C,
            };

            


            enemies.Add(new Enemy(texEnemy));
            enemies.Add(new Enemy(texEnemy));
            enemies.Add(new Enemy(texEnemy));
            enemies.Add(new Enemy(texEnemy));
            enemies.Add(new Enemy(texEnemy));
            enemies.Add(new Enemy(texEnemy));
            enemies.Add(new Enemy(texEnemy));
            enemies.Add(new Enemy(texEnemy));

        }

        protected override void Update(GameTime gameTime)
        {
            


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            if (player.Position.Y > Global.DisplayHeight - 50)
            {
                Exit();
            }

            if (player.Position.Y < 0)
            {
                Exit();
            }

            if (player.Position.X > Global.DisplayWidth)
            {
                Exit();
            }

            if (player.Position.X < 0)
            {
                Exit();
            }

            player.Update();
            if (enemies.Count > 0)
            {
                foreach (Enemy e in enemies)
                {
                    e.Update();
                    if (e.Rectangle.Intersects(player.Rectangle))
                    {
                        Exit(); 
                    }

                }
            }

            if (gameTime.TotalGameTime.Seconds == 60)
            {
                enemies.Clear();
                Global.lv1 = false;
                Global.lv2 = true;
            }

            if (gameTime.TotalGameTime.Seconds == 120)
            {
                pipe.Clear();
                Global.lv2 = false;
                Global.lv3 = true;
            }

            if (Global.lv2 == true && content2 == false) 
            {
                pipe.Add(new Pipe(texPipeOben, texPipeUnten));
                content2 = true;
            }

            if (Global.lv3 == true && content3 == false)
            {
                boss.Add(new Boss(texBoss));
                boss[0].texBullet = texBullet;
                content3 = true;
            }

            if (Global.lv3 == true && boss.Count > 0)
            {
                boss[0].Update(gameTime);
            }
            

            if (pipe.Count > 0)
            {
                foreach (Pipe p in pipe.ToList())
                {
                    if (p.oben.Location.X == 600){
                        pipe.Add(new Pipe(texPipeOben, texPipeUnten));
                    }

                    if (p.oben.Location.X + p.oben.Width < 0) {
                        pipe.RemoveAt(0);
                    }

                    p.Update();
                    if (p.oben.Intersects(player.Rectangle) || p.unten.Intersects(player.Rectangle))
                    {
                        Exit();
                    }

                }


            }


            if (boss.Count > 0)
            {
                foreach (Bullet b in boss[0].bullet.ToList())
                {
                    b.Update();
                    if (b.bullet.Intersects(player.Rectangle))
                    {
                        Exit();
                    }

                }
            }

            if (boss.Count > 0)
            {
                foreach (Bullet b in player.bullet.ToList())
                {
                    b.Update();
                    if (b.bullet.Intersects(boss[0].Rectangle))
                    {
                        boss[0].Health -= 1;
                        player.bullet.RemoveAt(0);
                    }

                }

                if(boss[0].Health <=0)
                {
                    boss.RemoveAt(0);
                }
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            if (Global.lv1 == true)
            {
                foreach (Enemy e in enemies)
                {
                    e.Draw(_spriteBatch);
                }

            }

            player.Draw(_spriteBatch);

            if (Global.lv2 == true)
            {
                foreach (Pipe e in pipe)
                {
                    e.Draw(_spriteBatch);
                }

            }

            if (Global.lv3 == true && boss.Count > 0)
            {
                boss[0].Draw(_spriteBatch);    
            }




            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
