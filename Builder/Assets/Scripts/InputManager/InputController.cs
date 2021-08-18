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
            _actionJump.performed -= OnPlayerJumpStart;
        }

        public void Activate()
        {
            _actionMovement.started += OnPlayerMovement;
            _actionMovement.performed += OnPlayerMovement;
            _actionMovement.canceled += OnPlayerMovement;

            _actionJump.started += OnPlayerJumpStart;
            _actionJump.performed += OnPlayerJumpStart;
        }

        private void OnPlayerJumpStart(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
                _context.GlobalContainer.PlayerComponent.Animator.SetTrigger("IsJump");
        }

        private void OnPlayerMovement(InputAction.CallbackContext context)
        {
            var key = context.control.name;
            var positionInput = context.ReadValue<Vector2>();
            var position = new Vector3(positionInput.x, 0, positionInput.y);

            if (positionInput.y < 0)
            {
                _context.GlobalContainer.PlayerComponent.Animator.SetBool("IsRunBackwards", true);
            }
            else
            {
                _context.GlobalContainer.PlayerComponent.Animator.SetBool("IsRunBackwards", false);
            }
            
            _model.IsMove = positionInput.x != 0 || positionInput.y != 0;
            _context.PlayerModel.UpdatePosition(position);
        }
    }
}