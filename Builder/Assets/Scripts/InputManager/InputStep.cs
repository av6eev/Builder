using Utilities;

namespace InputManager
{
    public class InputStep : IStep
    {
        public void Execute(GameContext context, ControllerCollection controllerCollection, GlobalContainer container)
        {
            var model = new InputModel();
            context.InputModel = model;
            var controller = new InputController(context, model, container.InputActionAsset);
            controllerCollection.Add(controller);
        }
    }
}