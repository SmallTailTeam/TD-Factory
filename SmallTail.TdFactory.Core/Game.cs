using System;
using SFML.Graphics;
using SFML.Window;

namespace SmallTail.TdFactory.Core
{
    public class Game
    {
        public RenderWindow Window;
        
        private GameState _state;

        public Game(GameState state)
        {
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
            Window = new RenderWindow(VideoMode.DesktopMode, "TD Factory");

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
        }

        private void Render(float dt)
        {
            _state.Render(dt);
        }
    }
}