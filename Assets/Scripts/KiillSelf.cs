using System.Collections;
using UnityEngine;

public class KiillSelf : MonoBehaviour
{
    public GameObject BrokenSelf;

    //public Transform BrokenCenter;

    //public Rigidbody BrokenBody;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // BrokenBody.AddExplosionForce(10, BrokenSelf.position, 10);

        StartCoroutine(Kill());
    }


    public IEnumerator Kill()
    {

        yield return new WaitForSeconds(5);

        Destroy(BrokenSelf);

    }
    
}
