using CameraManager;
using Entities.Base;
using InputManager;
using Player;

namespace Utilities
{
    public class GameContext
    {
        public GlobalContainer GlobalContainer { get; set; }
        public PlayerData PlayerData { get; set; }
        
        public BaseSystemEngine BaseSystemEngine { get; set; }
        public FixedSystemEngine FixedSystemEngine { get; set; }
        public ControllerEngine ControllerEngine { get; set; }
        public EntityCollection EntityCollection { get; } = new EntityCollection();

        public PlayerModel PlayerModel { get; set; }
        public InputModel InputModel { get; set; }
        public CameraModel CameraModel { get; set; }
    }
}