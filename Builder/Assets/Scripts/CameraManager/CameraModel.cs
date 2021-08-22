using System.Collections.Generic;

namespace CameraManager
{
    public class CameraModel
    {
        public Dictionary<CameraTypes, BaseCamera> Cameras = new Dictionary<CameraTypes, BaseCamera>();
    }
}