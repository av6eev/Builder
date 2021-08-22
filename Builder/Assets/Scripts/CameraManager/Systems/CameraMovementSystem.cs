using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

namespace CameraManager
{
    public class CameraMovementSystem : ISystem
    {
        private readonly GameContext _context;
        
        public CameraMovementSystem(GameContext context)
        {
            _context = context;
        }

        public void Update(float deltaTime)
        {
            var playerModel = _context.PlayerModel;
            var cameraComponent = _context.GlobalContainer.CameraComponent;
            var camForward = cameraComponent.Camera.forward;
            var camRight = cameraComponent.Camera.right;
            
            if (_context.GlobalContainer.CameraComponent.LockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
            camForward.y = 0;
            camRight.y = 0;
            camForward = camForward.normalized;
            camRight = camRight.normalized;
            cameraComponent.Forward = camForward;
            cameraComponent.Right = camRight;
            
            playerModel.MousePositionY = Mathf.Clamp(playerModel.MousePositionY, -60f, 60f);
            
            _context.GlobalContainer.CameraComponent.Camera.localEulerAngles = new Vector3(playerModel.MousePositionY, 0, 0);
        }
    }
}