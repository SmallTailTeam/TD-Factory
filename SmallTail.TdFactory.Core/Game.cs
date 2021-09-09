using System;
using SFML.Graphics;
using SFML.Window;
using TdFactory.Core.Graphics;

namespace TdFactory.Core
{
    public class Game
    {
        public RenderWindow Window;
        
        private GameState _state;

        public Game(GameState state)
        {
            Window = new RenderWindow(VideoMode.DesktopMode, "TD Factory");
            Camera.Current = Window.GetView();
            
            ChangeState(state);
            
            Run();
        }
        
        public void ChangeState(GameState state)
        {
            state.Initialize(this);
            _state = state;
        }
        
        private void Run()
        {
            Window.Closed += (_, _) =>
            {
                Window.Close();
            };

            DateTime lastUpdate = DateTime.Now;

            while (Window.IsOpen)
            {
                TimeSpan dt = DateTime.Now - lastUpdate;
                lastUpdate = DateTime.Now;

                float castedDt = (float) dt.TotalSeconds;
                
                Update(castedDt);
                    
                Window.Clear(Color.Black);
                Render(castedDt);

                Window.Display();
                Window.DispatchEvents();
            }
        }

        
        private void Update(float dt)
        {
            _state.Update(dt);
            Window.SetView(Camera.Current);
        }

        private void Render(float dt)
        {
            _state.Render(dt);
        }
    }
}