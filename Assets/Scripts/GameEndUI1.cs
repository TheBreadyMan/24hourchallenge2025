using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUI1 : MonoBehaviour
{

    public GameObject Menu;


    public void Start()
    {

        StartCoroutine(WaitForSpeach());
        Menu.SetActive(false);

    }

    public IEnumerator WaitForSpeach()
    {

        yield return new WaitForSeconds(55);
        Menu.SetActive(true);

    }

    public void Return()
    {

        SceneManager.LoadScene("MainMenu");


    }

    public void QuitG()
    {

        Application.Quit();

    }





}
