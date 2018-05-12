using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class About : MonoBehaviour {

	public Button about_;
	public GameObject panel_;
	Transform transform;
	GameObject child_;
	void Start ()
	{
		Button myBtn = about_.GetComponent<Button>();
		myBtn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		panel_.SetActive (true);
	}
}