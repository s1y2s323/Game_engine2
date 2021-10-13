using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class FireCtrl : MonoBehaviour
{
    [SerializeField] private Transform cam;
    
    public GameObject bullet;

    public Transform firePos;

    public ParticleSystem cartridge;

    private ParticleSystem muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    
    void Fire()
    {
        Instantiate(bullet, firePos.position, cam.rotation);
        

      // Vector3 dir = new Vector3(cam.forward.x, cam.forward.y, cam.forward.z);
       // transform.position = dir;
        

       // bullet.transform.position += dir * 1000.0f*Time.deltaTime;
        //bullet.GetComponent<Rigidbody>();
       // bullet.AddComponent<Rigidbody>();
      //  bullet.GetComponent<Rigidbody>().AddForce(transform.forward *1000.0f );
        //GetComponent<Rigidbody>().AddForce(dir *1000.0f);
        //GetComponent<Rigidbody>().AddForce(transform.forward.normalized * speed);

        cartridge.Play();

        muzzleFlash.Play();


    }
}
