using Utilities;

namespace Player
{
    public class PlayerStep : IStep
    {
        public void Execute(GameContext context, ControllerCollection controllerCollection, GlobalContainer container)
        {
            var model = new PlayerModel();
            context.PlayerModel = model;
            
            var controller = new PlayerController(model, container.PlayerComponent, context);
            controllerCollection.Add(controller);
        }
    }
}