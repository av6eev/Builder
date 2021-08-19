using Utilities;

namespace Player.Systems
{
    public class PlayerMoveSystem : ISystem
    {
        private readonly GameContext _context;
        
        public PlayerMoveSystem(GameContext context)
        {
            _context = context;
        }

        public void Update(float deltaTime)
        {
            var playerModel = _context.PlayerModel;
            var playerComponent = _context.GlobalContainer.PlayerComponent;

            playerComponent.Animator.SetFloat("Speed", playerModel.CurrentVelocity);
            playerComponent.transform.position += playerModel.Position * playerModel.CurrentVelocity * deltaTime;
        }
    }
}