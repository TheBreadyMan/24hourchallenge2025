using UnityEngine;

public class BreakableObjects : MonoBehaviour
{

    #region GameObjects

    public GameObject BrokenForm;
    public GameObject Self;
    public GameObject BrokenVfx;

    #endregion

    #region Audio


    public AudioClip BreakSound;
    public AudioSource BreakSource;



    #endregion




    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 5)
        {

            Instantiate(BrokenForm);
            BreakSource.Play();
            Instantiate(BrokenVfx);

            Destroy(Self);




        }
            
                
                
                
     }




}
