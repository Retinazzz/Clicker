using UnityEngine;
using UnityEngine.UI;

public class Buttondisabler : MonoBehaviour
{
    [SerializeField] private Button _myButton;
    [SerializeField] private Artifact _artifact;
    [SerializeField] private homya_deliverer _Hommyak;
    [SerializeField] private Canon _canon;
    [SerializeField] private BulletHomya _bullet;
    [SerializeField] private deaglebullet _deagle_bullet;
    // [SerializeField] private bool _NeededHomyak;
    [SerializeField] private int whichbutton;
    void Start()
    {
        DisableButton();
    }
     void Update()
    {
       
        switch (whichbutton)
        {
            case 1:
                if (_artifact.Clicks >= _artifact.price1st)
                {
                    EnableButton();
                }
                else
                {
                    DisableButton();
                }
                break;

            case 2:
                if (ClonerHomyak.CurrentHomyakks >= ClonerHomyak.maxHomyakks)
                {
                    DisableButton();
                }
                else if (_artifact.Clicks >= ClonerHomyak.Cost1homyak)
                {
                    EnableButton();
                }
                else
                {
                    DisableButton();
                }
                break;

            case 3:
                if (_artifact.Clicks >= _Hommyak._speedcost)
                {
                    EnableButton();
                }
                else
                {
                    DisableButton();
                }
                break;

            case 4:
                if (_artifact.Clicks >= _Hommyak._valueprice)
                {
                    EnableButton();
                }
                else
                {
                    DisableButton();
                }
                break;

            case 5:
                if (_artifact.Clicks >= _artifact._price2nd)
                {
                    EnableButton();
                }
                else
                {
                    DisableButton();
                }
                break;
            case 6:
                if (_artifact.Clicks >= _canon._cost)
                {
                    EnableButton();
                }
                else
                {
                    DisableButton();
                }
                break;
            case 7:
                if (_artifact.Clicks >= _bullet._cost)
                {
                    EnableButton();
                }
                else
                {
                    DisableButton();
                }
                break;
            case 8:
                if (_artifact.Clicks >= _artifact._price3rd)
                {
                    EnableButton();
                }
                else
                {
                    DisableButton();
                }
                break;
            case 9:
                if (_artifact.Clicks >= clonershooter.Cost1shooter)
                {
                    EnableButton();
                }
                else
                {
                    DisableButton();
                }
                break;
            case 10:
                if (_artifact.Clicks >= _deagle_bullet._cost)
                {
                    EnableButton();
                }
                else
                {
                    DisableButton();
                }
                break;
            case 11:
                if (_artifact.Clicks >= _artifact._price2_5)
                {
                    EnableButton();
                }
                else
                {
                    DisableButton();
                }
                break;
        }
    }
    public void DisableButton()
    {         
            _myButton.interactable = false; 
    }

    public void EnableButton()
    {
        _myButton.interactable = true; 
    }
}