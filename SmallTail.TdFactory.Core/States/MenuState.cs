namespace SmallTail.TdFactory.Core.States
{
    public class MenuState : GameState
    {
        public override void Initialize(GameCore game)
        {
            game.SetState(new ScenarioState());
        }
    }
}