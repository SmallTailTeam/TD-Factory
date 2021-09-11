using SFML.Graphics;
using SFML.System;
using TdFactory.Core.Entities;
using TdFactory.Core.Graphics;
using TdFactory.Core.System;

namespace TdFactory.Core.UI
{
    public class ItemStackRenderer : IRenderer
    {
        public ItemStack Target;

        private int _index;
        private Sprite _background;
        private Sprite _icon;
        private Text _text;

        public ItemStackRenderer(int index)
        {
            _index = index;
            
            _background = new Sprite
            {
                Texture = Shapes.Dot,
                Scale = new Vector2f(80, 80),
                Color = new Color(0, 0, 0, 150)
            };

            _icon = new Sprite();
            
            _text = new Text
            {
                Font = AssetManager.LoadFont("Assets/Fonts/SegoeUI.ttf")
            };
        }

        public void Render(float dt)
        {
            Vector2f leftBottom = Game.Window.MapPixelToCoords(new Vector2i(0, (int) Game.Window.Size.Y));
            Vector2f renderPosition = leftBottom + new Vector2f(90f * _index, -80f);
            
            _background.Position = renderPosition;

            Game.Window.Draw(_background);
            
            if (Target != null)
            {
                _icon.Texture = Target.Item.Texture;
                _icon.Scale = new Vector2f(80f / _icon.Texture.Size.X, 80f / _icon.Texture.Size.Y);
                _icon.Position = renderPosition;
                
                Game.Window.Draw(_icon);
                
                _text.Position = renderPosition + new Vector2f(50f, 45f);
                _text.DisplayedString = $"{Target.Count}";
                
                Game.Window.Draw(_text);
            }
        }
    }
}