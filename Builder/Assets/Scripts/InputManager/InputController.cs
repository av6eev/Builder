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

        private readonly InputAction _movement;
        private readonly InputAction _jump;
        private readonly InputAction _shift;
        private readonly InputAction _mouseDelta;

        public InputController(GameContext context, InputModel model, InputActionAsset asset)
        {
            _context = context;
            _model = model;
            _asset = asset;

            _movement = _asset.FindAction(InputFields.Movement);
            _jump = _asset.FindAction(InputFields.Jump);
            _shift = _asset.FindAction(InputFields.Shift);
            _mouseDelta = _asset.FindAction(InputFields.MouseDelta);

            _asset.Enable();
        }

        public void Deactivate()
        {
            _movement.started -= OnPlayerMovement;
            _movement.performed -= OnPlayerMovement;
            _movement.canceled -= OnPlayerMovement;

            _jump.started -= OnPlayerJump;
            
            _shift.started -= OnPlayerShift;
            _shift.canceled -= OnPlayerShift;

            _mouseDelta.performed -= OnMouseMove;
        }

        public void Activate()
        {
            _movement.started += OnPlayerMovement;
            _movement.performed += OnPlayerMovement;
            _movement.canceled += OnPlayerMovement;

            _jump.started += OnPlayerJump;

            _shift.started += OnPlayerShift;
            _shift.canceled += OnPlayerShift;

            _mouseDelta.performed += OnMouseMove;
        }

        private void OnMouseMove(InputAction.CallbackContext context)
        {
            var positionInput = context.ReadValue<Vector2>();
            var sensitivityX = .2f;
            var sensitivityY = .3f;
            
            _context.PlayerModel.MousePositionX += positionInput.x * sensitivityX;
            _context.PlayerModel.MousePositionY -= positionInput.y * sensitivityY;
            
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
            {
                _context.GlobalContainer.PlayerComponent.Animator.SetTrigger("IsJump");
                _model.IsJump = true;
            }
            else
            {
                _model.IsJump = false;
            }
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