using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class CamLook : MonoBehaviour
{

    public float Xsens;
    public float Ysens;

    public Transform CamOrien;


    float xRot;
    float yRot;


    public PlayerInput _playerinput;
    public InputActionReference PlayerLook;

    public CharacterController controller;
    public void Awake()
    {

        controller = gameObject.GetComponent<CharacterController>();


    }

    public void Start()
    {


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    public void OnEnable()
    {
        PlayerLook.action.Enable();
    }

    public void OnDisable()
    {
        PlayerLook.action.Disable();
    }

    private void Update()
    {

        Vector2 mouseInput = PlayerLook.action.ReadValue<Vector2>();
       


        float mouseX = mouseInput.x * Time.deltaTime * Xsens;
        float mouseY = mouseInput.y * Time.deltaTime * Ysens;


        yRot += mouseX;
        xRot -= mouseY;

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        CamOrien.rotation = Quaternion.Euler(0, yRot, 0);
    }

















}
