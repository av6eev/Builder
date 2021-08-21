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

            if (_context.GlobalContainer.CameraComponent.LockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
            playerModel.MousePositionY = Mathf.Clamp(playerModel.MousePositionY, -60f, 60f);
            
            _context.GlobalContainer.PlayerComponent.transform.localEulerAngles = new Vector3(0, playerModel.MousePositionX, 0);
            _context.GlobalContainer.CameraComponent.Camera.localEulerAngles = new Vector3(playerModel.MousePositionY, 0, 0);
        }
    }
}