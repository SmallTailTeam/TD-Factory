using System;
using SFML.Graphics;
using SFML.Window;
using TdFactory.Core.Graphics;

namespace TdFactory.Core.System
{
    public class Game
    {
        public static RenderWindow Window;
        
        private GameState _state;

        public Game(GameState state)
        {
            Window = new RenderWindow(VideoMode.DesktopMode, "TD Factory");
            Camera.Current = Window.GetView();
            Window.SetFramerateLimit(144);

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

            const float computeRate = 1f / 50f;
            float computeTimer = 0f;

            while (Window.IsOpen)
            {
                TimeSpan dt = DateTime.Now - lastUpdate;
                lastUpdate = DateTime.Now;

                float castedDt = (float) dt.TotalSeconds;
                
                computeTimer += castedDt;

                if (computeTimer >= computeRate)
                {
                    Compute(castedDt, computeRate);
                    computeTimer = 0f;
                }
                
                Update(castedDt);
                    
                Window.Clear(Color.Black);
                Render(castedDt);

                Window.Display();
                Window.DispatchEvents();
            }
        }

        private void Compute(float dt, float fixedDt)
        {
            _state.Compute(dt, fixedDt);
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