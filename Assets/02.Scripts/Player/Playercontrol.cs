using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    [SerializeField] 
    private Transform character;
    [SerializeField]
    private Transform cameraRig;
    
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;
    
    private Animator anim;
    private Transform spine;
    
    private bool is_move = false;

    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        anim = character.GetComponent<Animator>();
        if(anim)
            spine = anim.GetBoneTransform(HumanBodyBones.UpperChest);
    }

    void Update()
    {
        is_move = false;
       // isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector2 moveInput = new Vector2(x, z);

        Vector3 move = transform.right * x + transform.forward * z;
        if (Vector2.zero != moveInput)
        {
            is_move = true;
            controller.Move(move * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        anim.SetBool("Move",is_move);
        anim.SetFloat("DirX",moveInput.x);
        anim.SetFloat("DirZ",moveInput.y);
    }
    
    public void LateUpdate()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraRig.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;
       
        spine.rotation = spine.rotation * Quaternion.Euler(0, -x,0) ;
    }
}
