using UnityEngine;
using Utilities;

namespace Player
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
            var direction = playerModel.Position;
            
            if (_context.InputModel.IsJump)
            {
                playerModel.DirectionY = playerModel.JumpSpeed;
                playerModel.DirectionY -= playerModel.Gravity * Time.deltaTime;
                direction.y = playerModel.DirectionY;
            }

            if (_context.InputModel.IsMove)
            {
                _context.GlobalContainer.PlayerComponent.CharacterController.Move(direction * playerModel.MoveSpeed * Time.deltaTime);
            }
        }
    }
}