using Utilities;

namespace CameraManager
{
    public class CameraStep : IStep
    {
        public void Execute(GameContext context, ControllerEngine controllerEngine, GlobalContainer container)
        {
            var model = new CameraModel();
            context.CameraModel = model;
            
            var controller = new CameraController(context, model, container.CameraComponent);
            controllerEngine.Add(controller);
        }
    }
}