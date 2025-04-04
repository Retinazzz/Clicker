using UnityEngine;

public class Deagle : MonoBehaviour
{
    [SerializeField] private AudioClip enterSound;
    [SerializeField] private Transform Firepoint;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private static float fireRate = 0.5f;
    [SerializeField] private Music sound;
    [SerializeField] private float volume = 0.3f;
    private float volumefix;
    private static bool soundOff = false;
    private float nextFireTime;
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

            if (Time.time >= nextFireTime)
            {

                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        
    }
    void Shoot()
    {
        PlaySound();
        Debug.Log(soundOff);
        GunAnimator.SetTrigger("Shoot");
        
        GameObject _explosion = Instantiate(Explosion, Firepoint.position, Quaternion.identity);
        GameObject Shoot = Instantiate(Bullet, Firepoint.position, Quaternion.identity);
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
    public void ToggleSound()
    {
        soundOff = !soundOff;
    }
}
