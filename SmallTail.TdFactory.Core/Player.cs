using SFML.Graphics;
using SFML.System;
using SFML.Window;
using TdFactory.Core.Mathematics;
using TdFactory.Core.Graphics;

namespace TdFactory.Core
{
    public class Player
    {
        public Sprite Sprite;
        public float Speed = 450f;

        public Player()
        {
            Sprite = new Sprite
            {
                Texture = Shapes.Square(128, 128, Color.Magenta)
            };
        }
        
        public void Update(float dt)
        {
            Move(dt);
            
            Camera.Current.Center = Sprite.Position;
        }

        private void Move(float dt)
        {
            Vector2f movement = new ();

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                movement.Y -= 1f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                movement.Y += 1f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                movement.X += 1f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                movement.X -= 1f;
            }

            if (movement.NonZero())
            {
                movement = movement.Normalized();

                Sprite.Position += movement * dt * Speed;
            }
        }
    }
}