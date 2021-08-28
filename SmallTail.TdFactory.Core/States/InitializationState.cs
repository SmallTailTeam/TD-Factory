using SmallTail.TdFactory.Core.States;

namespace SmallTail.TdFactory.Core
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