using UnityEngine;
using UnityEngine.InputSystem;

public class DebugScript : MonoBehaviour
{


    public PanicMeter panic;

    public PlayerInput _playerInput;
    public InputAction PlayerDebug;

    public void Start()
    {

        _playerInput = GetComponent<PlayerInput>();
        PlayerDebug = _playerInput.actions["Debug"];

    }


    // Update is called once per frame
    void Update()
    {



        
    }
}
