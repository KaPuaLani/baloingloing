using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public TextMeshProUGUI targetText; // Drag your TextMeshPro object here
    public Slider mySlider;           // Drag your Slider object here
    public int SoundV = 0;

    void Start()
    {
        // Link the slider to the function below
        mySlider.onValueChanged.AddListener(valuestt);
        valuestt(mySlider.value); // Set initial word
    }

    public void valuestt(float value)
    {
        // Logic to change words based on slider value
        targetText.text = value.ToString("...");
            {
                SoundV = Mathf.RoundToInt(value);
            }
        }
}