using System.Collections;
using UnityEngine;

public class kalashshooter : MonoBehaviour
{
    [SerializeField] private AudioClip enterSound;
    [SerializeField] private Transform Firepoint;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private static float fireRate = 0.5f;
    [SerializeField] private  float ratein3 = 0.1f;
    [SerializeField] private float volume = 0.3f;
    private float volumefix;
    private static bool soundOff = false;

    public float timeBetweenBullets = 0.1f;  // Задержка между пулями в очереди
    public float timeBetweenBursts = 1f;   // Задержка между очередями

    private bool isShooting = true;
    private int bulletsInBurst = 3;  // Количество пуль в очереди
    private int bulletsFired = 0;
    private float nextBulletTime = 0f;
    private float nextBurstTime = 0f;
    private AudioSource audioSource;
    public Animator GunAnimator;
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

        if (soundOff == true)
        {
            volumefix = 0;
        }
        else volumefix = volume;

       if(isShooting == true)
        {
            StartCoroutine(FireBurst());
        }


    }
    void Shoot()
    {
        PlaySound();
        Debug.Log(soundOff);
       // GunAnimator.SetTrigger("Shoot2");

        GameObject _explosion = Instantiate(Explosion, Firepoint.position, Quaternion.identity);
        GameObject Shoot = Instantiate(Bullet, Firepoint.position, Quaternion.identity);
        
    }
    void PlaySound()
    {
        if (enterSound != null)
        {
            audioSource.PlayOneShot(enterSound, volumefix);
        }
        else
        {
            Debug.LogWarning("Не назначен звук в SoundTrigger!");
        }
    }
    public void ToggleSound()
    {
        soundOff = !soundOff;
    }
    
    IEnumerator FireBurst()
    {
        isShooting = false;
        GunAnimator.SetTrigger("Shoot2");
        for (int i = 0; i < bulletsInBurst; i++)
        {
            Shoot();  // Ваш метод выстрела
            GunAnimator.SetTrigger("noshoot");
            yield return new WaitForSeconds(timeBetweenBullets);
        }

        yield return new WaitForSeconds(timeBetweenBursts);
        isShooting = true;
    }
}
