using UnityEngine;
using System;
public class clicker_score : MonoBehaviour
{
    [SerializeField] private Artifact _artifact;
    [SerializeField] private BoxCollider2D _1stAdder;

    //private int  countvalue = 1 ;

    private DateTime _lastTimeCredit;

    public void Awake()
    {
        
        if (PlayerPrefs.HasKey(nameof(_lastTimeCredit)))
        {
            _lastTimeCredit = DateTime.Parse(PlayerPrefs.GetString(nameof(_lastTimeCredit)));
        }
        else
            _lastTimeCredit = DateTime.Now;
    }
    public void Update()
    {
        double lastSecond = (DateTime.Now - _lastTimeCredit).TotalSeconds;
        int spans = (int)lastSecond / 3;
        if (spans > 0)
        {
            for (int i = 0; i <spans; i++)
            {
                //CreditClicks();
            }
            _lastTimeCredit = DateTime.Now;
            PlayerPrefs.SetString(nameof(_lastTimeCredit), _lastTimeCredit.ToString());
        }
    }

    
    private void CreditClicks()
    {
         _artifact.Addclicks(3);
    }
}
