using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class adderdescriprion : MonoBehaviour
{
    [SerializeField] private Artifact _artifact;
    [SerializeField] private string AddedDescription;
    private static int adder = 0;
    private Text Description;
    void Awake()
    {
        Description = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (_artifact.countvalue >= 50)
        {
           adder = _artifact.countvalue / 25;
           Description.text = "+ " + (9 + adder ).ToString() + AddedDescription;
        }
        else
        {
            Description.text = ("+10") + AddedDescription;
        }    
        
    }
}
