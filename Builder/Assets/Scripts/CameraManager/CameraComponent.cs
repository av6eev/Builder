using UnityEngine;

namespace CameraManager
{
    public class CameraComponent : MonoBehaviour
    {
        [SerializeField] public bool LockCursor = true;
        public Transform Camera;
    }
}