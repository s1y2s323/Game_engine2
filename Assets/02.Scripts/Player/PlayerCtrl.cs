using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    
    private float h = 0.0f;
    private float v = 0.0f;
    private Vector2 r = new Vector2(0.0f,0.0f);

    private bool is_move = false;

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
       // Cursor.lockState = CursorLockMode.Locked;
        anim = character.GetComponent<Animator>();
        if(anim)
            spine = anim.GetBoneTransform(HumanBodyBones.UpperChest);
        character.forward = cameraRig.forward;
        //cameraRig.rotation.Set(0,0,0,1);
//
    }
    
   
    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();
    }
    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
//
        Vector2 moveInput = new Vector2(h, v);
        is_move = false;
        if (Vector2.zero != moveInput)
        {
            is_move = true;
        }
      // 
       // {
           
            Vector3 lookForward = new Vector3(cameraRig.forward.x, 0f, cameraRig.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraRig.right.x, 0f,cameraRig.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
//
           character.forward = lookForward;
          
          // 
          transform.position += moveDir * Time.deltaTime * moveSpeed;
          
      //  }
        
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
//
    public void LateUpdate()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraRig.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;
      
        spine.rotation = spine.rotation * Quaternion.Euler(0, -x,0) ;
    }


}
