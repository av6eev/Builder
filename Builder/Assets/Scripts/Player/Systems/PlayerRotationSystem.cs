using UnityEngine;
using Utilities;

namespace Player.Systems
{
    public class PlayerRotationSystem : ISystem
    {
        private readonly GameContext _context;
        private const float _rotationSpeed = 6f;

        public PlayerRotationSystem(GameContext context)
        {
            _context = context;
        }
        
        public void Update(float deltaTime)
        {
            var playerModel = _context.PlayerModel;
            var playerComponent = _context.GlobalContainer.PlayerComponent;
            
            if (playerModel.Position.z > 0)
                playerComponent.transform.rotation = Quaternion.Slerp(playerComponent.transform.rotation, Quaternion.LookRotation(Vector3.forward), _rotationSpeed * deltaTime);
            else if (playerModel.Position.z < 0)
                playerComponent.transform.rotation = Quaternion.Slerp(playerComponent.transform.rotation, Quaternion.LookRotation(Vector3.forward), _rotationSpeed * deltaTime);
        }
    }
}