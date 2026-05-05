using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    public string levelToLoad;
    public Canvas UI;
    public Canvas pUI;
    public Camera UIcam;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Canvas>().enabled = false;
    }
    public void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            //pause the game
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            //show our pause menu canvas
            UI.enabled = true;
            pUI.enabled = false;
            UIcam.enabled = true;
            cam.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if we press the escape key
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            //pause the game
            Time.timeScale = 0;
            //show our pause menu canvas
            GetComponent<Canvas>().enabled = true;
        }*/
    }

    public void ResumeGame()
    {
        //continue playing the game... somehow?
        Time.timeScale = 1;
        UI.enabled = false;
        pUI.enabled = true;
        UIcam.enabled = false;
        cam.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelToLoad);
    }
}
