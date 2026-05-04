using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CH : MonoBehaviour
{
    public TextMeshProUGUI targetText; // Drag your TextMeshPro object here
    public Slider mySlider;           // Drag your Slider object here
    public int CrossHair = 0;

    void Start()
    {
        // Link the slider to the function below
        mySlider.onValueChanged.AddListener(UpdateWord);
        UpdateWord(mySlider.value); // Set initial word
    }

    public void UpdateWord(float value)
    {
        // Logic to change words based on slider value
        if (value == 0)
        {
            targetText.text = "none";
            CrossHair = 0;
        }
        if (value == 1)
        {
            targetText.text = "v1"; // ch 1
            CrossHair = 1;
        }
        else if (value == 2)
        {
            targetText.text = "v2"; //ch 2
            CrossHair = 2;
        }
        else if (value == 3)
        {
            targetText.text = "v3"; // ch 3
            CrossHair = 3;
        }
        if (value == 4)
        {
            targetText.text = "v4"; //ch 1&2
            CrossHair = 4;
        }
        else if (value == 5)
        {
            targetText.text = "v5"; // ch 1&3
            CrossHair = 5;
        }
        else if (value == 6)
        {
            targetText.text = "v6"; //ch 2&3
            CrossHair = 6;
        }
    }
    public void chno()
    {
        CrossHair = 0;
        Debug.Log("none");
    }
    public void ch1()
    {
        CrossHair = 1;
        Debug.Log("1");
    }
    public void ch2()
    {
        CrossHair = 2;
        Debug.Log("2");
    }
    public void ch3()
    {
        CrossHair = 3;
        Debug.Log("3");
    }
    public void ch4()
    {
        CrossHair = 4;
        Debug.Log("4");
    }
    public void ch5()
    {
        CrossHair = 52;
        Debug.Log("5");
    }
    public void ch6()
    {
        CrossHair = 6;
        Debug.Log("6");
    }
}
