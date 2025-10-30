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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 5)
        {
            var pos = gameObject.transform.position;
            var rot = gameObject.transform.rotation;
            Instantiate(BrokenForm, pos, rot);
            //BreakSource.Play();
            //Instantiate(BrokenVfx);
            //panicScore.PanicValue = panicScore.PanicValue + 10;
            //panicScore.UpdatePanic(); 

            Destroy(gameObject);
        }
     }
}
