using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;
using UnityEngine.UI;

[System.Serializable]
public struct PlayerSfx
{
    public AudioClip[] fire;
    public AudioClip[] reload;
}


    

public class FireCtrl : MonoBehaviour
{
    public enum WeaponType
    {
        RIFLE=0,
        SHOTGUN
    }
    public WeaponType currWeapon = WeaponType.RIFLE;
    
    [SerializeField] private Transform cam;
    
    public GameObject bullet;

    public Transform firePos;

    public ParticleSystem cartridge;

    private ParticleSystem muzzleFlash;
    private AudioSource _audio;

    public PlayerSfx playerSfx;

    private Shake shake;

    private Weapon weapon;


    public Image magazineImg;
    public Text magazineText;

    public int maxBullet = 10;
    public int remainingBullet = 10;

    public float reloadTime = 2.0f;
    private bool isReloading = false;
    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        shake = GameObject.Find("CameraRig").GetComponent<Shake>();
        weapon = GameObject.Find("w_rifle01").GetComponent<Weapon>();
        _audio = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(firePos.position, firePos.forward *20.0f , Color.green);

        if (Input.GetMouseButtonDown(0) && !isReloading)
        {
            --remainingBullet;
            Fire();

            if (remainingBullet == 0)
            {
                StartCoroutine(Reloading());
            }
        }
    }
    
    void Fire()
    {
        var _bullet = GameManager.instance.GetBullet();
        if (_bullet != null)
        {
            _bullet.transform.position = firePos.position;
            _bullet.transform.rotation = cam.rotation;
            _bullet.SetActive(true);
        }

        
        //Instantiate(bullet, firePos.position, cam.rotation);
      //  StartCoroutine(shake.ShakeCamera());
       // StartCoroutine(weapon.Recoil());
        weapon.Recoil();

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

        FireSfx();

        magazineImg.fillAmount = (float) remainingBullet / (float) maxBullet;
        UpdateBulletText();
    }

   IEnumerator Reloading()
   {
      isReloading = true;
      _audio.PlayOneShot(playerSfx.reload[(int)currWeapon],1.0f);

      yield return new WaitForSeconds(playerSfx.reload[(int) currWeapon].length + 0.3f);

      isReloading = false;
      magazineImg.fillAmount = 1.0f;
      remainingBullet = maxBullet;
      UpdateBulletText();
   }

    void UpdateBulletText()
    {
       magazineText.text = string.Format("<color = #ff0000>{0}</color>/{1}", remainingBullet, maxBullet);
    }

    void FireSfx()
    {
        var _sfx = playerSfx.fire[(int) currWeapon];
        _audio.PlayOneShot(_sfx, 1.0f);
    }
}
