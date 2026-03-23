using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider _silder;

    [SerializeField] private TextMeshProUGUI _silderText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _silder.onValueChanged.AddListener((v) =>
        {
            _silderText.text = v.ToString("0");
        });
    }
}
