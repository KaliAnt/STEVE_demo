using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitToMenu : MonoBehaviour {

	// Use this for initialization
	public Button quitMenu_;
	public GameObject panel_;
	void Start () {
		Button myBtn = quitMenu_.GetComponent<Button>();
		myBtn.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void TaskOnClick()
	{
		panel_.SetActive (false);
		Application.LoadLevel ("MenuScene");
	}
}
