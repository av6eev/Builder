using Utilities;

namespace CameraManager
{
    public class CameraStep : IStep
    {
        public void Execute(GameContext context, ControllerCollection controllerCollection, GlobalContainer container)
        {
            var model = new CameraModel();
            context.CameraModel = model;
            
            var controller = new CameraController(context, model, container.CameraComponent);
            controllerCollection.Add(controller);
        }
    }
}