using UnityEngine;


public class homya_deliverer : MonoBehaviour
{
    public Artifact _artifact;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private AudioClip enterSound; // Звук при входе
    [SerializeField] private float volume = 1f;
    [SerializeField] private GameObject hit;

    private float volumefix;
    private AudioSource _audioSource;
    private static int Hommvalue = 5, ValuePrice = 50, speedcost = 30;

    private int maxHomyakks = 8, CurrentHomyakks = 0;


    public CircleCollider2D col;

    
    private Animator animator;

    public Vector3 pointA = new Vector3(-9, -2,10);
    public Vector3 pointB = new Vector3(9, -2,10);

    private static float speed = 2f;
    private bool ismuted = false;
    public float _speed => speed;
    public int _hommvalue => Hommvalue;
    public int _speedcost => speedcost;
    public int _valueprice => ValuePrice;


    public Vector3 target;

    

    private void Start()
    {
        volumefix = volume;    
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
          {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
          }
        
    }
    private void OnEnable()
    {
        target = pointB;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (ismuted == true)
        {
            volumefix = 0;
        }
        else volumefix = volume;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;  // Switch target
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        _artifact.Addclicks(Hommvalue);
        Instantiate(hit);

        animator.SetBool("Trigger", true);
        PlaySound();

    }
    public void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("Trigger", false);
    }
    public void AddHommValue(int Value)
    {
        if (_artifact.Clicks >= ValuePrice)
        {
            Hommvalue += Value;
            _artifact.DecreaseClicks(ValuePrice);
            AddCostForValue();
        }
    }
    public void AddCostForValue()
    {
        ValuePrice = (int)(ValuePrice * 3 + 50);
    }
    public void AddCostForSpeed()
    {
        speedcost = speedcost * 2 + 40;
    }
    public void AddHommSpeed(float Value)
    {
        if (_artifact.Clicks >= speedcost)
        {
            _artifact.DecreaseClicks(speedcost);
            speed += Value;
            AddCostForSpeed();
        }

    }
    void PlaySound()
    {
        
            _audioSource.PlayOneShot(enterSound, volumefix);
        

    }
    public void ToggleSound()
    {
        ismuted = !ismuted;
    }
}
