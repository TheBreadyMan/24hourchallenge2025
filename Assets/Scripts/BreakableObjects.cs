using UnityEngine;

public class BreakableObjects : MonoBehaviour
{

    public GameObject BrokenForm;
    public GameObject BrokenVfx;








    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 5)
        {

            

        }
            
                
                
                
     }




}
