using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour
{
    


    public void Return()
    {

        SceneManager.LoadScene("MainMenu");


    }

    public void QuitG()
    {

        Application.Quit();

    }





}
