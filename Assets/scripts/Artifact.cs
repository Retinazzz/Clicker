using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class Artifact : MonoBehaviour
{
    
    
    public event Action Down, Up, ClicksChanged, FirstPrice, FirstPTS; //AddCountValue, AddCountPerSecondsValue;
    [SerializeField] private Image hpBarFill;
    [SerializeField] private Text Price, Value;
    [SerializeField] private Sprite[] alternativeSprites;
    [SerializeField] private float MaxRange, MinRange, growSpeed, shrinkAmount;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip click;
    
    public GameObject Korm;
    
    private Vector3 _originalScale;
    private Vector3 _targetScale;

    public string Current_Clicks_fixed;

    private AudioSource _audioSource;
    

    private static int _clicks;
    private static int  adder = 1;
    private static int _CountValue = 1;
    private int _CountPerSecondsValue = 3;
    private static int FullHP = 100;
    private static int CurrentHP;
    private static int price2_5 = 1000;
    private static int price3rd = 100000;
    public int _fullhp => FullHP;
    public int _currenthp => CurrentHP;
    public int Clicks => _clicks;
    public int countvalue => _CountValue;
    public int CountPerSecondValue => _CountPerSecondsValue;

    private static int price1st = 1;
    public int _price1st => price1st;
    private static int price2nd = 200;
    public int _price2nd => price2nd;
    public int _price2_5 => price2_5;
    public int _price3rd => price3rd;
    private void Start()
    {
        _originalScale = transform.localScale;
        _targetScale = _originalScale;
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
        }
        LoadScore();
        price1st = PlayerPrefs.GetInt("1adder", price1st);
        price2nd = PlayerPrefs.GetInt("2adder", price2nd);
        price3rd = PlayerPrefs.GetInt("3adder", price3rd);
        price2_5 = PlayerPrefs.GetInt("2.5adder", price2_5);
        FullHP = PlayerPrefs.GetInt("HP", FullHP);
    }
    public void Addclicks(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));
        _clicks += count;
       
        adddmgtofreddy(count);
        
        
        ClicksChanged?.Invoke();
        Debug.Log(count);
        
        
    }
    
    public void DecreaseClicks(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));
        _clicks -= count;
        
    }
   private void OnMouseDown()
    {
        Down?.Invoke();
        transform.localScale *= shrinkAmount;
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        KeshaShower(clickPosition);
        _audioSource.clip = click;
        _audioSource.enabled = true;
        _audioSource.Play();
    }

    private void OnMouseUp()
    {
        Up?.Invoke();
        Addclicks(countvalue);
        DeleteScore();
        SaveScore();
    }
    private void Update()
    {
        float newScale = Mathf.Min(transform.localScale.x + growSpeed * Time.deltaTime, MaxRange);
        if (newScale < MinRange)
        {
            newScale = MinRange;
        }
        transform.localScale = Vector3.one * newScale;

        if (CurrentHP<1)
        {
            SwapFreddos();
            FullHP = (int)(FullHP * 1.5);
            CurrentHP = FullHP;
            PlayerPrefs.SetInt("HP", FullHP);
        }
       
        
            
    }
    public void AddCountValue(int CountValueAdd)
    {
        
        if (_clicks >= price1st)
        {

            _CountValue += CountValueAdd;
            

                DecreaseClicks(price1st);

                adder = (int )(adder*1.1 + 5) ;
                Debug.Log(adder);
                price1st = adder;
            PlayerPrefs.SetInt("1adder", price1st);
        }
    }
    public void SwapFreddos()
    {
        if (alternativeSprites.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, alternativeSprites.Length);
            spriteRenderer.sprite = alternativeSprites[randomIndex];
            view._up = spriteRenderer.sprite;
            view._down = spriteRenderer.sprite;
        }      
    }
    public void adddmgtofreddy(int dmg)
    {
        CurrentHP -= dmg;       
    }
    public void addCount2(int CountValueAdd)
    {
        if (_clicks >= price2nd)
        {
            _CountValue += CountValueAdd;
            DecreaseClicks(price2nd);
            price2nd = (int)(price2nd * 1.1 + 50);
            if (countvalue >= 50)
            {
                _CountValue += countvalue / 25;
            }
        }
        PlayerPrefs.SetInt("2adder", price2nd);
    }
    public void AddCount3(int CountValueAdd)
    {
        if (_clicks >= price3rd)
        {
            _CountValue += CountValueAdd;
            DecreaseClicks(price3rd);
            price3rd = (int)(price3rd * 1.2);           
        }
        PlayerPrefs.SetInt("3adder", price3rd);
    }
    public void Addcount2_5(int CountValueAdd)
    {
        if (_clicks >= price2_5)
        {
            _CountValue += CountValueAdd;
            DecreaseClicks(price2_5);
            price2_5 = (int)(price2_5 * 1.2);
        }
        PlayerPrefs.SetInt("2.5adder", price2_5);
    }
    public void KeshaShower(Vector3 pos)
    {
        
        Instantiate(Korm,pos,Quaternion.identity);
    }
    public static void SaveScore()
    {
        PlayerPrefs.SetInt("Score", _clicks);
        PlayerPrefs.Save(); // Важно вызывать Save()!
    }

    // Загружаем значение
    public static void LoadScore()
    {
        _clicks = PlayerPrefs.GetInt("Score", 0); // 0 — значение по умолчанию
    }

    // Удаляем сохранение (если нужно)
    public static void DeleteScore()
    {
        PlayerPrefs.DeleteKey("Score");
    }



}
   
   

   

