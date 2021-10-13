using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runL;
    public AnimationClip runR;
}

public class Example : MonoBehaviour
{
    
    private float h = 0.0f;
    private float v = 0.0f;
    private Vector2 r = new Vector2(0.0f,0.0f);
    
    [SerializeField]
    private Transform cameraRig;

    [SerializeField] private Transform character;
    public float moveSpeed = 10.0f;
   

    public PlayerAnim playerAnim;
    public Animation anim;
    void Start()
    {
        //cameraRig = GetComponent<Transform>();

        anim = character.GetComponent<Animation>();
        
        anim.clip = playerAnim.idle;
        anim.Play();
    }
    
    void Update()
    {
        LookAround();
        Move();
        AnimClip();
    }

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
       
        Vector2 moveInput = new Vector2(h, v);
        Vector3 lookForward = new Vector3(cameraRig.forward.x, 0f, cameraRig.forward.z).normalized;
        Vector3 lookRight = new Vector3(cameraRig.right.x, 0f,cameraRig.right.z).normalized;
        Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

        //transform.position += moveDir * Time.deltaTime * 5f;
        character.forward = lookForward;
        transform.position += moveDir * Time.deltaTime * moveSpeed;
        //  cameraRig.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);

        // Debug.DrawRay(cameraRig.position, new Vector3(cameraRig.forward.x, 0f, cameraRig.forward.z).normalized,Color.red);
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

    private void AnimClip()
    {
        if (v >= 0.1f)
        {
            anim.CrossFade(playerAnim.runF.name, 0.3f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade(playerAnim.runB.name, 0.3f);
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade(playerAnim.runR.name, 0.3f);
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade(playerAnim.runL.name, 0.3f);
        }
        else
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f);
        }
    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    
}
