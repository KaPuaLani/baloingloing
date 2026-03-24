using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DIFFSLID : MonoBehaviour
{
    public TextMeshProUGUI targetText; // Drag your TextMeshPro object here
    public Slider mySlider;           // Drag your Slider object here
    public int difficulty = 0;

    void Start()
    {
        // Link the slider to the function below
        mySlider.onValueChanged.AddListener(UpdateWord);
        UpdateWord(mySlider.value); // Set initial word
    }

    public void UpdateWord(float value)
    {
        // Logic to change words based on slider value
        if (value == 1)
        {
            targetText.text = "easy";
            difficulty = 1;
        }
        else if (value == 2)
        {
            targetText.text = "medium";
            difficulty = 2;
        }
        else if (value == 3)
        {
            targetText.text = "hard";
            difficulty = 3;
        }
    }
        public void Easy()
    {
        difficulty = 1;
        Debug.Log("e");
    }
    public void Medium()
    {
        difficulty = 2;
        Debug.Log("m");
    }
    public void Hard()
    {
        difficulty = 3;
        Debug.Log("h");
    }
}
