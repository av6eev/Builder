using Utilities;

namespace CameraManager
{
    public class CameraController : IController
    {
        private readonly GameContext _context;
        private readonly CameraModel _model;
        private readonly CameraComponent _component;

        public CameraController(GameContext context, CameraModel model, CameraComponent component)
        {
            _context = context;
            _model = model;
            _component = component;
        }        
        
        public void Deactivate()
        {
        }

        public void Activate()
        {
        }
    }
}