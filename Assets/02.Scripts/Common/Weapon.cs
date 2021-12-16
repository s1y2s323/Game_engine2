using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform camRecoil;
    public Vector3 recoilKickback;
    public float recoilAmount;

    public Vector3 original;
    
    
    // Start is called before the first frame update
    void Start()
    {
        original = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        RecoilBack ();
    }
    
    public void Recoil()
    {
        Vector3 recoilVector 
            = new Vector3 (Random.Range (-recoilKickback.x, recoilKickback.x), recoilKickback.y, recoilKickback.z);
        Vector3 recoilCamVector = new Vector3 (-recoilVector.y * 400f, recoilVector.x * 200f, 0);

        transform.localPosition = 
            Vector3.Lerp (transform.localPosition, transform.localPosition + recoilVector, recoilAmount / 2f); // position recoil
        camRecoil.localRotation = 
            Quaternion.Slerp (camRecoil.localRotation, Quaternion.Euler(camRecoil.localEulerAngles + recoilCamVector), recoilAmount); // cam recoil
    }
    
    private void RecoilBack()
    {
        camRecoil.localRotation = 
            Quaternion.Slerp (camRecoil.localRotation, Quaternion.identity, Time.deltaTime * 2f);
        transform.localPosition =
            Vector3.Lerp(transform.localPosition, original, recoilAmount / 2f);
    }
}
