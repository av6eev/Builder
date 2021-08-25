using System;
using CameraManager;
using CameraManager.Systems;
using Player;
using Player.Systems;
using UnityEngine;
using Utilities;

public class StartController : MonoBehaviour
{
    [SerializeField] private GlobalContainer _container;
    [SerializeField] private PlayerData _playerData;
    private readonly GameContext _context = new GameContext();
    
    private readonly ControllerEngine _controllerEngine = new ControllerEngine();
    private readonly BaseSystemEngine _baseSystemEngine = new BaseSystemEngine();
    private readonly FixedSystemEngine _fixedSystemEngine = new FixedSystemEngine();
    private readonly StepEngine _stepEngine = new StepEngine();

    private void Start()
    {
        _context.GlobalContainer = _container;
        _context.PlayerData = _playerData;

        _stepEngine.Execute(_context, _controllerEngine, _context.GlobalContainer);

        _baseSystemEngine.Add(SystemTypes.PlayerMovementSystem, new PlayerMovementSystem(_context));
        
        _fixedSystemEngine.Add(SystemTypes.CameraMovementSystem, new CameraMovementSystem(_context));
        _fixedSystemEngine.Add(SystemTypes.PlayerPhysicsSystem, new PlayerPhysicsSystem(_context));

        _controllerEngine.Activate();    
    }

    private void Update()
    {
        _baseSystemEngine.Update(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _fixedSystemEngine.Update(Time.deltaTime);
    }
}
