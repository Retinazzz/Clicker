using UnityEngine;
using UnityEngine.UI;

public class HPview : MonoBehaviour
{
    [SerializeField] private Artifact _artifact;
    private Text _Hpview;
    void Awake()
    {
        _Hpview = GetComponent<Text>();
    }


    void Update()
    {
        _Hpview.text = _artifact._currenthp.ToString();
    }
}
