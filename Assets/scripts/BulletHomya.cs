using UnityEngine;

public class BulletHomya : MonoBehaviour
{
    [SerializeField] private GameObject Explosion;
    [SerializeField] private Artifact _artifact;
    [SerializeField] private float minrange, maxrange;
    

    public Vector2 target = new Vector2(9, 0);
    public int speed = 10;
    private static int Explosionvalue = 1000;
    private static int cost = 20000;
    public int _explosionValue => Explosionvalue;
    public int _cost => cost;
    
   
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject explosion = Instantiate(Explosion,transform.position,Quaternion.identity);
        _artifact.Addclicks(Explosionvalue);
        Destroy(gameObject);
    }
    private void Update()
    {
        Vector2 fixtarget = new Vector2(target.x * Random.Range(minrange,maxrange), target.x * Random.Range(minrange,maxrange));
        transform.position = Vector2.MoveTowards(transform.position, fixtarget, speed * Time.deltaTime);
    }
    public void AddValue(int value)
    {
        if (_artifact.Clicks >= cost)
        { 
            _artifact.DecreaseClicks(cost);
            Explosionvalue += value;
            cost = (int)(cost * 1.5) + 2000;
        }
        
    }
    
}
