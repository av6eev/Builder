using UnityEngine;
using Utilities;

namespace Player.Systems
{
    public class PlayerPhysicsSystem : ISystem
    {
        private readonly GameContext _context;

        public PlayerPhysicsSystem(GameContext context)
        {
            _context = context;
        }
        
        public void Update(float deltaTime)
        {
            var playerModel = _context.PlayerModel;
            
            if (_context.InputModel.IsMove)
            {
                if (playerModel.CurrentVelocity < playerModel.MaxWalkVelocity)
                {
                    playerModel.CurrentVelocity += playerModel.Speed * deltaTime;
                }
                else if (playerModel.CurrentVelocity >= playerModel.MaxWalkVelocity && playerModel.CurrentVelocity < playerModel.MaxRunVelocity && _context.InputModel.IsRun)
                {
                    playerModel.CurrentVelocity += playerModel.Speed * deltaTime;
                } 
                else if (!_context.InputModel.IsRun)
                {
                    while (playerModel.CurrentVelocity > playerModel.MaxWalkVelocity)
                    {
                        playerModel.CurrentVelocity -= playerModel.Speed * deltaTime;
                    }
                }
            }
            else
            {
                if (playerModel.CurrentVelocity > 0)
                {
                    playerModel.CurrentVelocity -= Mathf.Max(0, playerModel.Speed * 8 * deltaTime);
                }
            }
        }
    }
}