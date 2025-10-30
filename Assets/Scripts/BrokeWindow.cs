using Unity.VisualScripting;
using UnityEngine;

public class BrokeWindow : MonoBehaviour
{

    #region Audio Section

    public AudioClip ScreamOne;
    public AudioClip ScreamTwo;
    public AudioClip DamnIt;
    public AudioClip WindowSmash;

    public AudioSource AudioLocation;
    public AudioSource WindowSmashLocation;

    public bool DamnMarge;

    public int RandomSound;

    #endregion

    public void Start()
    {

        WindowSmashLocation.clip = WindowSmash;
        WindowSmashLocation.pitch = Random.Range(1, 6);


    }


    public void OnTriggerEnter(Collider other)
    {
        

        if(other.CompareTag("Breakable"))
        {

            WindowSmashLocation.Play();

            if (DamnMarge == true)
            {
                
                    AudioLocation.clip = DamnIt;
                    AudioLocation.Play();
                
            }
            else
            {

                RandomSound = Random.Range(0, 1);

                if (RandomSound == 1)
                {

                    AudioLocation.clip = ScreamTwo;

                    AudioLocation.Play();
                }
                else
                {
                    AudioLocation.clip = ScreamOne;
                    AudioLocation.Play();

                }

            }




        }


    }
}
