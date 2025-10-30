using UnityEngine;

public class SmasherObjects : MonoBehaviour
{

    #region Sounds

    public AudioClip HitSound;
    public AudioSource HitSource;

    #endregion





    void Start()
    {

        HitSource.clip = HitSound;

    }



    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Breakable"))
        {

            HitSource.Play();

        }

    }


}
