using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField] private Transform cam;
    
    public float damage = 20.0f;
    public float speed = 1000.0f;

    private Transform tr;

    private Rigidbody rb;

    private TrailRenderer trail;

    void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
    }

    void OnEnable()
    {
        rb.AddForce(transform.forward *speed);
    }

    void OnDisable()
    {
        trail.Clear();
        tr.position = Vector3.zero;
        tr.rotation = Quaternion.identity;
        rb.Sleep();
    }
    // Start is called before the first frame update
    void Start()
    {
       // transform.forward = cam.forward;
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
