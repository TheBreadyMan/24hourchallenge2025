using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class PanicMeter : MonoBehaviour
{
    //[SerializeField] private Slider lightning;
    List<GameObject> Goals = new List<GameObject>();
    private int totalGoal;

    void Start()
    {
        //Debug.Log(lightning = GetComponent<Slider>());

        Goals.AddRange(GameObject.FindGameObjectsWithTag("Goal"));
        totalGoal = Goals.Count;

        //lightning.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var goal in Goals.ToList()) // Create a copy of the list to avoid modification during iteration
        {
            if (goal == null)
            {
                Goals.Remove(goal);
            }
        }

        Debug.Log(Goals.Count);
        float destroyedGoals = totalGoal - Goals.Count;

        //lightning.value = destroyedGoals / totalGoal;

        if (Goals.Count == 0)
        {
            SceneManager.LoadScene("YouWin");
        }
    }
}
