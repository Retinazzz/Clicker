using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Artifact))]
[RequireComponent(typeof(SpriteRenderer))]

public class view : MonoBehaviour
{
   // [SerializeField] private Sprite 
    public static Sprite _up,_down;
    private Transform _Fredos;
    private Artifact _artifact;
    private SpriteRenderer _spriteRenderer;
   
    private void Awake()
    {
        _artifact = GetComponent<Artifact>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _Fredos = GetComponent<Transform>();
       // testclcsview = GetComponent<TMP_Text>();
    }
   
    private void OnEnable()
    {
        _artifact.Up += OnUp;
        _artifact.Down += OnDown;
        
    }
    private void OnDisable()
    {
        _artifact.Up -= OnUp;
        _artifact.Down -= OnDown;
        
    }
    private void OnUp()
    {
        _spriteRenderer.sprite = _up;
        _spriteRenderer.color = Color.white;
        //Debug.Log("22");
    }
    private void OnDown()
    {
        //Debug.Log("11");
        _spriteRenderer.sprite = _down;
        _spriteRenderer.color = Color.red;
        
    }
   public void spriteswap(Sprite swapto)
    {
        _up = swapto;
        _down = swapto;
        
    }
   




}
