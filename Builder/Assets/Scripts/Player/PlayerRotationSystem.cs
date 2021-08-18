using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerRotationSystem : ISystem
    {
        private readonly GameContext _context;
        private readonly float _rotationSpeed = 5f;

        public PlayerRotationSystem(GameContext context)
        {
            _context = context;
        }
        
        public void Update(float deltaTime)
        {
            var playerModel = _context.PlayerModel;
            var playerComponent = _context.GlobalContainer.PlayerComponent;
            
            if (playerModel.Position.x > 0)
                playerComponent.transform.rotation = Quaternion.Slerp(playerComponent.transform.rotation, Quaternion.LookRotation(Vector3.right), _rotationSpeed * deltaTime);
            else if (playerModel.Position.x < 0)
                playerComponent.transform.rotation = Quaternion.Slerp(playerComponent.transform.rotation, Quaternion.LookRotation(Vector3.left), _rotationSpeed * deltaTime);
            
            if (playerModel.Position.z > 0)
                playerComponent.transform.rotation = Quaternion.Slerp(playerComponent.transform.rotation, Quaternion.LookRotation(Vector3.forward), _rotationSpeed * deltaTime);
            else if (playerModel.Position.z < 0)
                playerComponent.transform.rotation = Quaternion.Slerp(playerComponent.transform.rotation, Quaternion.LookRotation(Vector3.forward), _rotationSpeed * deltaTime);
        }
    }
}