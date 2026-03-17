using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuOptions : MonoBehaviour
{
    //Create an empty game object and attach this script to it
    //create a tag called GameOptions and apply it to this object
    // public bool mobile = false;
    public int mobile = 0;
    public int difficulty = 0;
    public int hid = 0;
    //Create a toggle on a canvas, and assign it to this public field
    //On the toggle OnValueChanged field, set it to MainMenuOptions.SetMobile
    public Toggle toggle;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameOptions");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            Debug.Log("foo");
        }

        DontDestroyOnLoad(this.gameObject);
        Debug.Log("don't destroy me");
    }
    public void Easy()
    {
        difficulty = 0;
        Debug.Log("e");
    }
    public void Medium()
    {
        difficulty = 1;
        Debug.Log("m");
    }
    public void Hard()
    {
        difficulty = 2;
        Debug.Log("h");
    }

    public void PC()
    {
        mobile = 2;
        hid = 1;
        Debug.Log("pc");
    }

    public void MB()
    {
        mobile = 1;
        hid = 0;
        Debug.Log("mb");
    }

    public void HIDE()
    {
        hid = 1;
        Debug.Log("hidden");
    }
    public void show()
    {
        hid = 0;
        Debug.Log("reveal");
    }
    // public void SetMobile()
    // {
    //   mobile = toggle.isOn;
    // }
}
