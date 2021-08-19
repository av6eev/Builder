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
        private readonly InputAction _actionShift;

        public InputController(GameContext context, InputModel model, InputActionAsset asset)
        {
            _context = context;
            _model = model;
            _asset = asset;

            _actionMovement = _asset.FindAction(InputFields.Movement);
            _actionJump = _asset.FindAction(InputFields.Jump);
            _actionShift = _asset.FindAction(InputFields.Shift);

            _asset.Enable();
        }

        public void Deactivate()
        {
            _actionMovement.started -= OnPlayerMovement;
            _actionMovement.performed -= OnPlayerMovement;
            _actionMovement.canceled -= OnPlayerMovement;

            _actionJump.started -= OnPlayerJump;

            _actionShift.started -= OnPlayerShift;
            _actionShift.canceled -= OnPlayerShift;
        }

        public void Activate()
        {
            _actionMovement.started += OnPlayerMovement;
            _actionMovement.performed += OnPlayerMovement;
            _actionMovement.canceled += OnPlayerMovement;

            _actionJump.started += OnPlayerJump;
            
            _actionShift.started += OnPlayerShift;
            _actionShift.canceled += OnPlayerShift;
        }

        private void OnPlayerShift(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                _context.GlobalContainer.PlayerComponent.Animator.SetBool("IsShiftEnable", true);
                _model.IsRun = true;
            }
            else
            {
                _context.GlobalContainer.PlayerComponent.Animator.SetBool("IsShiftEnable", false);
                _model.IsRun = false;
            }
        }

        private void OnPlayerJump(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
                _context.GlobalContainer.PlayerComponent.Animator.SetTrigger("IsJump");
        }

        private void OnPlayerMovement(InputAction.CallbackContext context)
        {
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