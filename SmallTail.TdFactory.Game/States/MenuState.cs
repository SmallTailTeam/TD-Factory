namespace SmallTail.TdFactory.Game.States
{
    public class MenuState : GameState
    {
        public override void Initialize(GameCore game)
        {
            game.SetState(new GameplayState());
        }
    }
}