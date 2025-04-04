using UnityEngine;

public class Clonerkalash : MonoBehaviour
{
    public GameObject bro1;
    public GameObject bro2;
    public GameObject bro3;
    [SerializeField] private Artifact artifact;
    [SerializeField] private Transform nextPosition;
    public static int Cost1shooter = 50;

    public static int maxHomyakks = 3;
    public static int CurrentHomyakks = 0;
    public void Clone()
    {


        if ((bro1 != null) & (bro2 != null) & (bro3 != null) & (CurrentHomyakks < maxHomyakks) & (artifact.Clicks >= Cost1shooter))
        {
            switch (CurrentHomyakks) 
            {
                case 0:
                    {
                        Instantiate(bro1, bro1.transform.position, Quaternion.identity);
                        CurrentHomyakks++;
                    }
                    break;
                case 1:
                    {
                        Instantiate(bro2, bro2.transform.position, Quaternion.identity);
                        CurrentHomyakks++;
                    }
                    break;
                case 2:
                    {
                        Instantiate(bro3, bro3.transform.position, Quaternion.identity);
                        CurrentHomyakks++;
                    }
                    break;
            }
            
            
            
        }
        else if (CurrentHomyakks >= maxHomyakks)
        {
            Debug.Log("МНогочета");

        }
        else
        {
            Debug.LogError("Не назначен объект для клонирования!");
        }
           
    }
   
}
