using UnityEngine;
using Utilities;

namespace Player.Systems
{
    public class PlayerMovementSystem : ISystem
    {
        private readonly GameContext _context;
        
        public PlayerMovementSystem(GameContext context)
        {
            _context = context;
        }

        public void Update(float deltaTime)
        {
            var playerModel = _context.PlayerModel;
            var playerComponent = _context.GlobalContainer.PlayerComponent;
            
            playerComponent.Animator.SetFloat("Speed", playerModel.CurrentVelocity);
            playerComponent.transform.localEulerAngles = new Vector3(0, playerModel.MousePositionX, 0);
            playerComponent.transform.position += (_context.GlobalContainer.CameraComponent.Forward * playerModel.Position.z + _context.GlobalContainer.CameraComponent.Right * playerModel.Position.x) * playerModel.CurrentVelocity * deltaTime;
        }
    }
}