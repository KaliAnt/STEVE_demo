using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public GameObject Joystick;
    public GameObject RotateJoystick;
    public Button PauseBttn;
	public GameObject panel_;
	public GameObject panelOptions_;
	public GameObject panelUpgrade_;
	public Color colorPaused_;
	public Color colorActive_;

    
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
			panel_.SetActive (false);
			panelUpgrade_.SetActive (false);
			panelOptions_.SetActive (false);
			PauseBttn.image.color = colorActive_;
            Time.timeScale = 1;
            isPaused = false;

            Joystick.SetActive(true);
            RotateJoystick.SetActive(true);
        } else
        {
			panel_.SetActive (true);
			PauseBttn.image.color = colorPaused_;
            Joystick.SetActive(false);
            RotateJoystick.SetActive(false);

            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
