using Utilities;

namespace Player
{
    public class PlayerStep : IStep
    {
        public void Execute(GameContext context, ControllerEngine controllerEngine, GlobalContainer container)
        {
            var model = new PlayerModel();
            context.PlayerModel = model;
            
            var controller = new PlayerController(model, container.PlayerComponent, context);
            controllerEngine.Add(controller);
        }
    }
}