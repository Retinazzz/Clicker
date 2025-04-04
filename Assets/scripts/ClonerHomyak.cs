using UnityEngine;


public class ClonerHomyak : MonoBehaviour
{
    public GameObject objectToClone; // Объект, который будем клонировать
    [SerializeField] private Artifact artifact;
    public static int Cost1homyak = 50;
    
    public static int maxHomyakks = 8;
    public static int CurrentHomyakks = 0;
    private void Start()
    {
        homya_deliverer[] Hommyaks = FindObjectsOfType<homya_deliverer>();
        
        foreach (var Hommyak in Hommyaks )
        {
           
        }
    }
    public void Clone() 
    {
        
        
        if ((objectToClone != null)&(CurrentHomyakks<maxHomyakks)&(artifact.Clicks>=Cost1homyak))
        {
            Instantiate(objectToClone);
            CurrentHomyakks++;

            artifact.DecreaseClicks(Cost1homyak);
            Cost1homyak = 4* Cost1homyak + 50;
        }
        else if (CurrentHomyakks>=maxHomyakks)
        {
            Debug.Log("МНогочета");
           
        }
        else
        {
            Debug.LogError("Не назначен объект для клонирования!");
        }
        


    }
}
