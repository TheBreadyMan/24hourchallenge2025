using UnityEngine;

public class BreakableObjects : MonoBehaviour
{

    #region GameObjects

    public GameObject BrokenForm;
    public GameObject Self;
    public GameObject BrokenVfx;


    public PanicMeter panicScore;

    #endregion

    #region Audio


    public AudioClip BreakSound;
    public AudioSource BreakSource;



    #endregion

    private void Start()
    {
        
        


    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 5)
        {

            Instantiate(BrokenForm, Self.transform);
            BreakSource.Play();
            //Instantiate(BrokenVfx);

            // panicScore.PanicValue = panicScore.PanicValue + 10;
            //  panicScore.UpdatePanic(); 



            KillYourSelf();


        }
            
                
                
                
     }




    public void KillYourSelf()
    {

        Destroy(gameObject.transform.parent.gameObject);

    }




}
