namespace Utilities
{
    public interface IStep
    {
        void Execute(GameContext context, ControllerCollection controllerCollection, GlobalContainer container);
    }
}