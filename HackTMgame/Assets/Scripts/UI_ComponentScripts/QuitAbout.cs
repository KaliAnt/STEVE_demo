using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitAbout : MonoBehaviour {

	public Button quit_;
	public GameObject panel_;
	void Start ()
	{
		Button myBtn = quit_.GetComponent<Button>();
		myBtn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		panel_.SetActive (false);			
	}
}
