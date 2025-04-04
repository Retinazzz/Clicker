using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MiniDescription4Button : MonoBehaviour
{
    [SerializeField] private deaglebullet _deaglebullet;
    [SerializeField] private Artifact _artifact;
    [SerializeField] private homya_deliverer _Hommyak;
    [SerializeField] private Canon _canon;
    [SerializeField] private BulletHomya _bullet;
    [SerializeField] private string AddedDescription;
    [SerializeField] private int WhichButton;
    [SerializeField] private bool IsPrice;
    
    //[SerializeField] private ClonerHomyak Homyak;

    private Text Description;
    void Awake()
    {
        Description = GetComponent<Text>();

    }


    void Update()
    {
        switch (WhichButton)
        {
            case 1:
                Description.text = (IsPrice ? NumberFormatter.FormatNumber(_artifact.price1st) : NumberFormatter.FormatNumber(_artifact.countvalue)) + AddedDescription;
                break;

            case 2:
                Description.text = (IsPrice ? NumberFormatter.FormatNumber(ClonerHomyak.Cost1homyak) : ClonerHomyak.CurrentHomyakks) + AddedDescription;
                break;

            case 3:
                Description.text = (IsPrice ? NumberFormatter.FormatNumber(_Hommyak._speedcost) : _Hommyak._speed) + AddedDescription;
                break;

            case 4:
                Description.text = (IsPrice ? NumberFormatter.FormatNumber(_Hommyak._valueprice) : _Hommyak._hommvalue) + AddedDescription;
                break;

            case 5:
                Description.text = (IsPrice ? NumberFormatter.FormatNumber(_artifact._price2nd) : NumberFormatter.FormatNumber(_artifact.countvalue)) + AddedDescription;
                break;

            case 6:
                Description.text = (IsPrice ? NumberFormatter.FormatNumber(_canon._cost) : _canon._firerate.ToString()) + AddedDescription;
                break;
            case 7:
                Description.text = (IsPrice ? NumberFormatter.FormatNumber(_bullet._cost) : NumberFormatter.FormatNumber(_bullet._explosionValue)) + AddedDescription;
                break;
            case 8:
                Description.text = (IsPrice ? NumberFormatter.FormatNumber(_artifact._price3rd) : NumberFormatter.FormatNumber(_artifact.countvalue)) + AddedDescription;
                break;
            case 9:
                Description.text = (IsPrice ? NumberFormatter.FormatNumber(clonershooter.Cost1shooter) : clonershooter.CurrentHomyakks.ToString()) + AddedDescription;
                break;
            case 10:
                Description.text = (IsPrice ? NumberFormatter.FormatNumber(_deaglebullet._cost) : NumberFormatter.FormatNumber(_deaglebullet._value)) + AddedDescription;
                break;
            case 11:
                Description.text = (IsPrice ? NumberFormatter.FormatNumber(_artifact._price2_5) : NumberFormatter.FormatNumber(_artifact.countvalue)) + AddedDescription;
                break;
        }
    }
}
