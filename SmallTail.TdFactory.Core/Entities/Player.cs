using SFML.Graphics;
using SFML.System;
using SFML.Window;
using TdFactory.Core.Mathematics;
using TdFactory.Core.Graphics;
using TdFactory.Core.System;
using TdFactory.Core.World;
using TdFactory.Core.World.Tiles;

namespace TdFactory.Core.Entities
{
    public class Player : IComputer, IUpdater
    {
        public Inventory Inventory = new(20);
        public Sprite Sprite;
        public float Speed = 450f;

        public Player()
        {
            Sprite = new Sprite
            {
                Texture = Shapes.Square(60, 60, Color.Magenta)
            };
        }

        public void Compute(float dt, float fixedDt)
        {
            
        }
        
        public void Update(float dt)
        {
            Move(dt);
            Interact();
            
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

        private void Interact()
        {
            Vector2i mousePos = Mouse.GetPosition(Game.Window);
            Vector2f worldPos = Game.Window.MapPixelToCoords(mousePos);

            Tile tile = Universe.Tilemap.GetTile(worldPos);

            if (Mouse.IsButtonPressed(Mouse.Button.Left) && (tile.Floor.Sprite.Position - Sprite.Position).Length() < 200f)
            {
                tile.Main?.Interact(this);
            }
        }
    }
}