namespace Utilities
{
    public interface IStep
    {
        void Execute(GameContext context, ControllerEngine controllerEngine, GlobalContainer container);
    }
}