using System.Collections.Generic;
using CameraManager;
using InputManager;
using Player;

namespace Utilities
{
    public class StepCollection : IStep
    {
        private readonly List<IStep> _steps = new List<IStep>();

        public StepCollection()
        {
            Add(new InputStep());
            Add(new PlayerStep());
            Add(new CameraStep());
        }

        public void Execute(GameContext context, ControllerCollection controllerCollection, GlobalContainer container)
        {
            foreach (var step in _steps)
            {
                step.Execute(context, controllerCollection, container);
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