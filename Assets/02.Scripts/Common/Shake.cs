using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public bool shakeRotate = false;

    private Vector3 originPos;

    private Quaternion originRot;

    //private Transform Cam;

  //  private Transform Cam;
    // Start is called before the first frame update
    void Start()
    {
       // originPos = transform.localPosition;
      //  originRot = transform.localRotation;
    }

    public IEnumerator ShakeCamera(float duration = 0.05f, float magnitudePos = 0.2f, float magnitudeRot = 0.5f)
    {
        originPos = transform.localPosition;
        originRot = transform.localRotation;
        
        float noise =  Mathf.PerlinNoise(Time.time * magnitudeRot, Time.time * magnitudeRot);
       
         
         
        float passTime = 0.0f;
       // float random = UnityEngine.Random.Range(0, 1);
       while (passTime < duration)
        {
           // Vector3 shakePos = Random.insideUnitSphere;
           // float noise =  Mathf.PerlinNoise(Time.time * magnitudeRot, Time.time * magnitudeRot);

            if (shakeRotate)
            {
                Vector3 shakeRot = new Vector3(noise, noise, 0);
                
              //  Quaternion rotation = Quaternion.identity;
               /// rotation.eulerAngles = new Vector3(0, noise, 0);
               // Vector3 rotation = 
               // rotation.eulerAngles = new Vector3(0, noise, 0);
              // transform.Rotate(rotation);
                //transform.localRotation *= rotation;
                
             //  rotation = Quaternion.identity;
              //  rotation.eulerAngles = new Vector3(0, noise, 0);
               // transform.rotation *= rotation;
               // transform.localRotation = Quaternion.Euler(noise, 0, 0);
             //  transform.localRotation *= Quaternion.Euler();
              // transform.rotation *= Quaternion.Euler(noise,noise,0);
              // Quaternion abc=transform.rotation;
              // abc.z = 0;
               // transform.localRotation *= Quaternion.Lerp()
               //transform.localRotation = (Quaternion.Euler(shakeRot) * originRot);
               // transform.localPosition += shakePos * magnitudePos;
            }
            passTime += Time.deltaTime;
            yield return null;
        }
        //transform.localPosition = originPos;
       // transform.localRotation = originRot;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
