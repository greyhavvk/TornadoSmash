using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    #pragma warning disable 0649

    [Header("References")]
    
    [SerializeField] private Slider _filledBar;
    [SerializeField] private Transform _LvlDesign;

    #pragma warning restore 0649

    private float _currentDistance;
    private float _finalDistance;

    private void Start()
    {
        _finalDistance = _LvlDesign.childCount;
    }

    void Update()
    {
        OpenProgressBar();
    }
    private void OpenProgressBar()
    {
        _currentDistance = _LvlDesign.childCount;
        _filledBar.value = (_finalDistance - _currentDistance) / _finalDistance;
    }
}