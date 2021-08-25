using UnityEngine;
using Utilities;

namespace Player.Systems
{
    public class PlayerMovementSystem : ISystem
    {
        private readonly GameContext _context;
        private readonly PlayerData _playerData;

        public PlayerMovementSystem(GameContext context)
        {
            _context = context;
            _playerData = _context.PlayerData;
        }

        public void Update(float deltaTime)
        {
            var playerModel = _context.PlayerModel;
            var playerComponent = _context.GlobalContainer.PlayerComponent;

            playerComponent.Animator.SetFloat("Speed", _playerData.CurrentVelocity);
            playerComponent.transform.localEulerAngles = new Vector3(0, playerModel.MousePositionX, 0);

            var moveDirection = _context.GlobalContainer.CameraComponent.Forward * playerModel.Position.z + _context.GlobalContainer.CameraComponent.Right * playerModel.Position.x;

            if (playerModel.IsGrounded)
            {
                playerComponent.Rigidbody.AddForce(moveDirection.normalized * _playerData.CurrentVelocity * _playerData.MovementMultiplier, ForceMode.Acceleration);
            }
            else if (!playerModel.IsGrounded)
            {
                playerComponent.Rigidbody.AddForce(moveDirection.normalized * _playerData.CurrentVelocity * _playerData.MovementMultiplier * _playerData.AirMultiplier, ForceMode.Acceleration);
            }
        }
    }
}