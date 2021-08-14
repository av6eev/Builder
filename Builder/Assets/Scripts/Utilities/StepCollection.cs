using System.Collections.Generic;

namespace Utilities
{
    public class StepCollection : IStep
    {
        private readonly List<IStep> _steps = new List<IStep>();

        public void Execute(GameContext context, ControllerCollection controllerCollection, GlobalContainer container)
        {
            foreach (var step in _steps)
            {
                step.Execute(context, controllerCollection, container);
            }
        }

        public void Add(IStep step)
        {
            _steps.Add(step);
        }
    }
}