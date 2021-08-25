using System.Collections.Generic;
using CameraManager;
using InputManager;
using Player;

namespace Utilities
{
    public class StepEngine : IStep
    {
        private readonly List<IStep> _steps = new List<IStep>();

        public StepEngine()
        {
            Add(new InputStep());
            Add(new PlayerStep());
            Add(new CameraStep());
        }

        public void Execute(GameContext context, ControllerEngine controllerEngine, GlobalContainer container)
        {
            foreach (var step in _steps)
            {
                step.Execute(context, controllerEngine, container);
            }
        }

        private void Add(IStep step)
        {
            _steps.Add(step);
        }

        public void Clear()
        {
            _steps.Clear();
        }
    }
}