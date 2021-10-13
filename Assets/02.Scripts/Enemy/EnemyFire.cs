using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFire : MonoBehaviour
{
    private AudioSource audio;
    private Animator animator;
    private Transform playerTr;
    private Transform enemyTr;

    private readonly int hashFire = Animator.StringToHash("Fire");
    private readonly int hashReload = Animator.StringToHash("Reload");


    private float nextFire = 0.0f;
    private readonly float fireRate = 0.1f;
    private readonly float damping = 10.0f;

    private readonly float reloadTime = 2.0f;
    private readonly int maxBullet = 10;
    private int currBullet = 10;
    private bool isReload = false;
    private WaitForSeconds wsReload;

    public bool isFire = false;
    public AudioClip fireSfx;

    public AudioClip reloadSfx;

    public GameObject Bullet;

    public Transform firePos;
    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        enemyTr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        wsReload = new WaitForSeconds(reloadTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReload && isFire)
        {
            if (Time.time >= nextFire)
            {
                Fire();
                nextFire = Time.time + fireRate + Random.Range(0.0f, 0.3f);

            }
        }

        Quaternion rot = Quaternion.LookRotation(playerTr.position - enemyTr.position);
        enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation, rot, Time.deltaTime * damping);
    }

    void Fire()
    {
        animator.SetTrigger(hashFire);
        audio.PlayOneShot(fireSfx, 1.0f);

        GameObject _bullet = Instantiate(Bullet, firePos.position, firePos.rotation);
        Destroy(_bullet, 3.0f);

        isReload = (--currBullet % maxBullet == 0);
        if (isReload)
        {
            StartCoroutine(Reloading());
        }
    }

    IEnumerator Reloading()
    {
        animator.SetTrigger(hashReload);
        audio.PlayOneShot(reloadSfx, 1.0f);

        yield return wsReload;

        currBullet = maxBullet;
        isReload = false;
    }
}
