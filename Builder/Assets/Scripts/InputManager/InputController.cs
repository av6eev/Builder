using System.Collections.Generic;
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
        private readonly Dictionary<string, InputAction> _actions = new Dictionary<string, InputAction>();
        
        private static readonly int IsShiftEnable = Animator.StringToHash("IsShiftEnable");
        private static readonly int IsRunBackwards = Animator.StringToHash("IsRunBackwards");

        public InputController(GameContext context, InputModel model, InputActionAsset asset)
        {
            _context = context;
            _model = model;
            _asset = asset;

            foreach (var actionMap in _asset.actionMaps)
            {
                actionMap.Enable();
                
                foreach (var action in actionMap.actions)
                {
                    AddAction(action.name, action);    
                }
            }
        }

        private void AddAction(string name, InputAction action)
        {
            _actions.Add(name, action);
        }

        private InputAction Get(string field)
        {
            return _actions[field];
        }
        
        public void Deactivate()
        {
            var movement = Get(InputFields.Movement);
            movement.started -= OnPlayerMovement;
            movement.performed -= OnPlayerMovement;
            movement.canceled -= OnPlayerMovement;

            var jump = Get(InputFields.Jump);
            jump.started -= OnPlayerJump;
            jump.performed -= OnPlayerJump;
            jump.canceled -= OnPlayerJump;

            var shift = Get(InputFields.Shift);
            shift.started -= OnPlayerShift;
            shift.performed -= OnPlayerShift;
            shift.canceled -= OnPlayerShift;

            var mouseDelta = Get(InputFields.MouseDelta);
            mouseDelta.started -= OnMouseMove;
            mouseDelta.performed -= OnMouseMove;
            mouseDelta.canceled -= OnMouseMove;
        }

        public void Activate()
        {
            var movement = Get(InputFields.Movement);
            movement.started += OnPlayerMovement;
            movement.performed += OnPlayerMovement;
            movement.canceled += OnPlayerMovement;

            var jump = Get(InputFields.Jump);
            jump.started += OnPlayerJump;
            jump.performed += OnPlayerJump;
            jump.canceled += OnPlayerJump;

            var shift = Get(InputFields.Shift);
            shift.started += OnPlayerShift;
            shift.performed += OnPlayerShift;
            shift.canceled += OnPlayerShift;

            var mouseDelta = Get(InputFields.MouseDelta);
            mouseDelta.started += OnMouseMove;
            mouseDelta.performed += OnMouseMove;
            mouseDelta.canceled += OnMouseMove;
        }

        private void OnMouseMove(InputAction.CallbackContext context)
        {
            var positionInput = context.ReadValue<Vector2>();
            const float sensitivityX = 0.05f;
            const float sensitivityY = 0.1f;
            
            _context.PlayerModel.MousePositionX += positionInput.x * sensitivityX;
            _context.PlayerModel.MousePositionY += positionInput.y * sensitivityY;
        }

        private void OnPlayerShift(InputAction.CallbackContext context)
        {
            if (Get(InputFields.Shift).triggered)
            {
                _context.GlobalContainer.PlayerComponent.Animator.SetBool(IsShiftEnable, true);
                _model.IsRun = true;
            }
            else
            {
                _context.GlobalContainer.PlayerComponent.Animator.SetBool(IsShiftEnable, false);
                _model.IsRun = false;
            }
        }

        private void OnPlayerJump(InputAction.CallbackContext context)
        {
            _model.IsJump = Get(InputFields.Jump).triggered;
        }

        private void OnPlayerMovement(InputAction.CallbackContext context)
        {
            var positionInput = context.ReadValue<Vector2>();
            var position = new Vector3(positionInput.x, 0, positionInput.y);

            _context.GlobalContainer.PlayerComponent.Animator.SetBool(IsRunBackwards, positionInput.y < 0);

            _model.IsMove = positionInput.x != 0 || positionInput.y != 0;
            _context.PlayerModel.UpdatePosition(position);
        }
    }
}