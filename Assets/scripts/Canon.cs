using UnityEngine;
using System;
public class Canon : MonoBehaviour
{
    [SerializeField] private AudioClip enterSound; // Звук при входе
    [SerializeField] private Artifact _artifact;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private static float fireRate = 0f;
    [SerializeField] private static int count = 0;
    [SerializeField] private static int maxcount = 10;
    [SerializeField] private Transform Firepoint;
    [SerializeField] private Transform CanonView;
    [SerializeField] private static int cost = 4000;
    [SerializeField] private float bulletForce = 1000f;
    [SerializeField] private float adder = 0.2f;
    [SerializeField] private float volume = 0.5f;
    [SerializeField] private Music sound;

    private Vector3 direction = new Vector3(5, 5,0);
    private static int CoolDown = 10;
    private float nextFireTime;
    private AudioSource audioSource;
    private Vector2 dor2 = new Vector2(5, 5);
    private float volumefix;
    private float fixeddirection;

    public int _cost => cost;
    public float _firerate => fireRate;

    //Vector2 randomDirection2D = UnityEngine.Random.insideUnitCircle.normalized;
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
        volumefix = volume;
    }
    void Update()
    {
        if (sound.isSoundMuted == true)
        {
            volumefix = 0;
        }
        else volumefix = volume;
        if (fireRate > 0.1f)
        {
            CanonView.transform.position = new Vector3(CanonView.transform.position.x, CanonView.transform.position.y, 0);
            if (Time.time >= nextFireTime)
            {
                
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        else
        {
            CanonView.transform.position = new Vector3(CanonView.transform.position.x, CanonView.transform.position.y, 3);
        }
       
    }
    void Shoot()
    {
        PlaySound();
        GameObject _explosion = Instantiate(Explosion, Firepoint.position, Quaternion.identity);
        GameObject Shoot = Instantiate(Bullet, Firepoint.position, Quaternion.identity);
       
    }
    public void Addvalue()
    {
        if ((_artifact.Clicks >= cost)&(count < maxcount))
        {
            fireRate += adder;
            _artifact.DecreaseClicks(cost);
            cost = (int)(cost * 1.5) + 800;
            count++;
        }
        
    }
    
    
     void PlaySound()
    {
        if (enterSound != null)
        {
            audioSource.PlayOneShot(enterSound,volumefix);
        }
        else
        {
            Debug.LogWarning("Не назначен звук в SoundTrigger!");
        }
    }
}

