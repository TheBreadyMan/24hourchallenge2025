using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public PlayerInput _playerInput;
    private InputAction PlayerPause;

    public GameObject PauseScreen;
    public GameObject OptionScreen;

    public void Awake()
    {

        _playerInput = GetComponent<PlayerInput>();
        PlayerPause = _playerInput.actions["Pause"];


    }
    void Start()
    {

        PauseScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(PlayerPause.IsPressed())
        {

            PauseScreen.SetActive(true);
            Time.timeScale = 0;


        }


    }


    void Resume()
    {

        Time.timeScale = 1;
        PauseScreen.SetActive(false);

    }

    void OptionsMenu()
    {

        PauseScreen.SetActive(false);
        OptionScreen.SetActive(true);

    }

    void BackToMenu()
    {

        Time.timeScale = 1;

        SceneManager.LoadScene("MainMenu");


    }

   void Quit()
    {

        Application.Quit();

    }

}
