using CameraManager;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Utilities
{
    public class GlobalContainer : MonoBehaviour
    {
        public InputActionAsset InputActionAsset;

        public PlayerComponent PlayerComponent;
        public CameraComponent CameraComponent;
    }
}