using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class scoreview : MonoBehaviour
{
    [SerializeField] private Artifact _artifact;
    private TMP_Text _scoreview;
    void Awake()
    {
        _scoreview = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreview.text = NumberFormatter.FormatNumber(_artifact.Clicks);
    }
    
}
