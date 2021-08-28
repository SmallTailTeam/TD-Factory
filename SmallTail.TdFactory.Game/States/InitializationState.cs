using SmallTail.TdFactory.Game.States;

namespace SmallTail.TdFactory.Game
{
    public class InitializationState : GameState
    {
        public override void Initialize(GameCore game)
        {
            // TODO: Initialize
            
            
            
            game.SetState(new MenuState());
        }
    }
}