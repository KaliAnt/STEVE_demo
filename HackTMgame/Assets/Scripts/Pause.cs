using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public GameObject Joystick;
    public GameObject RotateJoystick;
    public Button PauseBttn;

    
    private bool isPaused = false;

    void Start()
    {
        Button btn = PauseBttn.GetComponent<Button>();
        btn.onClick.AddListener(PauseGame);
    }
    public void PauseGame()
    {
        
        if(isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;

            Joystick.SetActive(true);
            RotateJoystick.SetActive(true);
        } else
        {
            Joystick.SetActive(false);
            RotateJoystick.SetActive(false);

            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
