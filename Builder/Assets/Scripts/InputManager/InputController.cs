using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

namespace InputManager
{
    public class InputController : IController
    {
        private readonly GameContext _context;
        private readonly InputModel _model;
        private readonly InputActionAsset _asset;

        private readonly InputAction _actionMovement;
        private readonly InputAction _actionJump;

        public InputController(GameContext context, InputModel model, InputActionAsset asset)
        {
            _context = context;
            _model = model;
            _asset = asset;
            
            _actionMovement = _asset.FindAction(InputFields.Movement);
            _actionJump = _asset.FindAction(InputFields.Jump);
            
            _asset.Enable();
        }
        
        public void Deactivate()
        {
            _actionMovement.started -= OnPlayerMovement;
            _actionMovement.performed -= OnPlayerMovement;
            _actionMovement.canceled -= OnPlayerMovement;

            _actionJump.started -= OnPlayerJumpStart;
            // _actionJump.performed -= OnPlayerJumpStart;
            // _actionJump.canceled -= OnPlayerJumpStart;
        }
        
        public void Activate()
        {
            _actionMovement.started += OnPlayerMovement;
            _actionMovement.performed += OnPlayerMovement;
            _actionMovement.canceled += OnPlayerMovement;
            
            // _actionJump.started += OnPlayerJumpStart;
            _actionJump.performed += OnPlayerJumpStart;
            // _actionJump.canceled += OnPlayerJumpStart;
        }

        private void OnPlayerJumpStart(InputAction.CallbackContext context)
        {
            Debug.Log(_model.IsJump = context.ReadValueAsButton());
        }

        private void OnPlayerMovement(InputAction.CallbackContext context)
        {
            var currentMovementInput = context.ReadValue<Vector2>();
            var currentMovement = new Vector3(currentMovementInput.x, 0 , currentMovementInput.y);

            _model.IsMove = currentMovementInput.x != 0 || currentMovementInput.y != 0;

            if (_model.IsMove)
                _context.PlayerModel.UpdatePosition(currentMovement);
        }
    }
}