using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCtrl : MonoBehaviour
{
    private Transform playerTr;
    private Vector3 bulletDir;
    private Vector3 offset;

    public float speed = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
       // playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();

       // offset = new Vector3(0, 1.5f, 0);
//
       // bulletDir = playerTr.position - transform.position + offset;
       // bulletDir.Normalize();

       // GetComponent<Rigidbody>().AddForce(bulletDir * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
