using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCtrl : MonoBehaviour
{

    public GameObject expEffect;

    private int hitCount = 0;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                ExpSphere();
            }
        }
    }

    void ExpSphere()
    {
        GameObject effect =Instantiate(expEffect, transform.position, Quaternion.identity);

        rb.mass = 1.0f; 
        rb.AddForce(Vector3.up * 1000.0f);

        Destroy(effect, 2.0f);
    }

   
    
}
