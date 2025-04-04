using UnityEngine;

public class buttonbuy : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
        }
    }
   public void PlaySound()
    {
        _audioSource.PlayOneShot(sound);
    }
    
}
