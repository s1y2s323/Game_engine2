using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    
    private float h = 0.0f;
    private float v = 0.0f;
    private Vector2 r = new Vector2(0.0f,0.0f);
    Vector3 ChestOffset = new Vector3(0, -40, -100);

    private bool is_move = false;
    
    [SerializeField] 
    public Transform target;


    public Vector3 Dir;

    private Animator anim;
   
    private Transform spine;
    
    
    [SerializeField]
    private Transform cameraRig;
    
    [SerializeField] 
    private Transform character;
    
    public float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = character.GetComponent<Animator>();
        if(anim)
            spine = anim.GetBoneTransform(HumanBodyBones.UpperChest);
       
    }
    
   
    // Update is called once per frame
    void Update()
    {
        Move();
        LookAround();
    }
   
    
   // spine.rotation = spine.rotation * Quaternion.Euler(relativeVec);
    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector2 moveInput = new Vector2(h, v);
        is_move = false;
        
        if (Vector2.zero != moveInput)
        {
            is_move = true;
            Vector3 lookForward = new Vector3(cameraRig.forward.x, 0f, cameraRig.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraRig.right.x, 0f,cameraRig.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            character.forward = lookForward;
            transform.position += moveDir * Time.deltaTime * moveSpeed;
        }
        
        anim.SetBool("Move",is_move);
        anim.SetFloat("DirX",moveInput.x);
        anim.SetFloat("DirZ",moveInput.y);
    }
    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraRig.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;
      
        if (x < 100f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            {
                x = Mathf.Clamp(x, 335f, 361f);
            }
        }
        cameraRig.rotation =UnityEngine.Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }

    public void LateUpdate()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraRig.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;
        if (x < 100f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            {
                x = Mathf.Clamp(x, 335f, 361f);
            }
        }
        spine.rotation = spine.rotation * Quaternion.Euler(-(camAngle.y + mouseDelta.x), -x,0) ;
    }


}
