using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerMoveSystem : ISystem
    {
        private readonly GameContext _context;
        
        private readonly float _speed = 8f;
        private float _currentVelocity = 0f;
        private readonly float _maxVelocity = 8f;

        public PlayerMoveSystem(GameContext context)
        {
            _context = context;
        }

        public void Update(float deltaTime)
        {
            var playerModel = _context.PlayerModel;
            var playerComponent = _context.GlobalContainer.PlayerComponent;

            if (_context.InputModel.IsMove)
            {
                if (_currentVelocity < _maxVelocity)
                {
                    _currentVelocity += _speed * deltaTime;
                }
            }
            else
            {
                if (_currentVelocity > 0)
                {
                    _currentVelocity -= Mathf.Max(0, _speed * 6 * deltaTime);
                }
            }

            playerComponent.Animator.SetFloat("Speed", _currentVelocity);
            playerComponent.transform.position += playerModel.Position * _currentVelocity * deltaTime;
        }
    }
}