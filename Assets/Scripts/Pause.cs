using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public PlayerInput _playerInput;
    private InputAction PlayerPause;

    public GameObject PauseScreen;
    public GameObject OptionScreen;
    public GameObject PlayerUI;

    public void Awake()
    {

        _playerInput = GetComponent<PlayerInput>();
        PlayerPause = _playerInput.actions["Pause"];
        


    }
    void Start()
    {

        PauseScreen.SetActive(false);
        PlayerUI.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(PlayerPause.IsPressed())
        {
            PlayerUI.SetActive(false);
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


        }


    }


    public void Resume()
    {

        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        PlayerUI.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void OptionsMenu()
    {

        PauseScreen.SetActive(false);
        OptionScreen.SetActive(true);

    }

   public void BackToMenu()
    {

        Time.timeScale = 1;

        PlayerUI.SetActive(true);

        SceneManager.LoadScene("MainMenu");


    }

   public void Quit()
    {

        Application.Quit();

    }

}
