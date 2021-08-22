using UnityEngine;

namespace CameraManager
{
    public class BaseCamera
    {
        public CameraTypes Type;
        public Vector3 OffsetPosition;
        public Space OffsetPositionSpace;
        public bool IsLookAt;
    }
}