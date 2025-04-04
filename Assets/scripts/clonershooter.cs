using UnityEngine;

public class clonershooter : MonoBehaviour
{
    public GameObject objectToClone; // Объект, который будем клонировать
    [SerializeField] private Artifact artifact;
    [SerializeField] private  Transform nextPosition;
    public static int Cost1shooter = 50;

    public static int maxHomyakks = 5;
    public static int CurrentHomyakks = 0;

    

    private void Awake()
    {
        
    }
    public void Clone()
    {


        if ((objectToClone != null) & (CurrentHomyakks < maxHomyakks) & (artifact.Clicks >= Cost1shooter))
        {
            NextPos();
            Instantiate(objectToClone,nextPosition.position,Quaternion.identity);            
            CurrentHomyakks++;
            artifact.DecreaseClicks(Cost1shooter);
            Cost1shooter = 4 * Cost1shooter + 50;
        }
        else if (CurrentHomyakks >= maxHomyakks)
        {
            Debug.Log("МНогочета");

        }
        else
        {
            Debug.LogError("Не назначен объект для клонирования!");
        }

        void NextPos()
        {
            switch (CurrentHomyakks)
            {
                case 0:
                    {
                        nextPosition.position = new Vector3(-16f, -0.33f, -1.3f);
                    }
                    break;
                case 1:
                    {
                        nextPosition.position = new Vector3(-13.8f, -1.3f, -1.4f);
                    }
                    break;
                case 2:
                    {
                        nextPosition.position = new Vector3(-16f, -2.26f, -1.5f);
                    }
                    break;
                case 3:
                    {
                        nextPosition.position = new Vector3(-13.8f, -3.35f, -1.6f);
                    }
                    break;
                case 4:
                    {
                        nextPosition.position = new Vector3(-16f, -4.3f, -1.7f);
                    }
                    break;
            }
            
        }
        
        
       
        
       

    }
}

