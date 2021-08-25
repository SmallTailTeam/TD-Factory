using Serilog;
using SmallTail.TdFactory.Core;
using SmallTail.TdFactory.Core.Modding;

namespace SmallTail.TdFactory.Game
{
    public class GameMod : Mod
    {
        public override void Loaded(GameHeart game)
        {
            Log.Information("Game loaded");
            
            game.SetState(new TestingGameState());
        }
    }
}