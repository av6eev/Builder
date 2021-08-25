using UnityEngine;
using Utilities;

namespace Player.Systems
{
    public class PlayerPhysicsSystem : ISystem
    {
        private readonly GameContext _context;
        private readonly PlayerData _playerData;

        public PlayerPhysicsSystem(GameContext context)
        {
            _context = context;
            _playerData = _context.PlayerData;
        }
        
        public void Update(float deltaTime)
        {
            Jump(_context.GlobalContainer.PlayerComponent);
            DragControl(_context.GlobalContainer.PlayerComponent, _playerData.AirDrag, _playerData.GroundDrag);
            
            if (_context.InputModel.IsMove)
            {
                if (_playerData.CurrentVelocity < _playerData.MaxWalkVelocity)
                {
                    _playerData.CurrentVelocity += _playerData.Speed * deltaTime;
                }
                else if (_playerData.CurrentVelocity >= _playerData.MaxWalkVelocity && _playerData.CurrentVelocity < _playerData.MaxRunVelocity && _context.InputModel.IsRun)
                {
                    _playerData.CurrentVelocity += _playerData.Speed * deltaTime;
                } 
                else if (!_context.InputModel.IsRun)
                {
                    while (_playerData.CurrentVelocity > _playerData.MaxWalkVelocity)
                    {
                        _playerData.CurrentVelocity -= _playerData.Speed * deltaTime;
                    }
                }
            }
            else
            {
                if (_playerData.CurrentVelocity > 0)
                {
                    _playerData.CurrentVelocity -= Mathf.Max(0, _playerData.Speed * 8 * deltaTime);
                }
            }
        }

        private void Jump(PlayerComponent playerComponent)
        {
            var isGrounded = _context.PlayerModel.IsGrounded;
            isGrounded = Physics.Raycast(playerComponent.transform.position, Vector3.down, 1 + 0.1f);
            
            if (isGrounded && _context.InputModel.IsJump)
            {
                playerComponent.Rigidbody.AddForce(playerComponent.transform.up * _playerData.JumpForce, ForceMode.Impulse);
                _context.GlobalContainer.PlayerComponent.Animator.SetBool("IsJump", true);
            }
            else
            {
                _context.GlobalContainer.PlayerComponent.Animator.SetBool("IsJump", false);
            }
        }

        private void DragControl(PlayerComponent playerComponent, float airDrag, float groundDrag)
        {
            if (_context.PlayerModel.IsGrounded)
            {
                playerComponent.Rigidbody.drag = groundDrag;
            }
            else
            {
                playerComponent.Rigidbody.drag = airDrag;
            }
        }
    }
}