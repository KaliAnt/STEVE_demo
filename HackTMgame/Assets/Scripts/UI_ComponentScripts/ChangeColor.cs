using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour {

	// Use this for initialization
	public Button button_;
	public Color color_;
	public SpriteRenderer player_;
	void Start () {
		Button btn = button_.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		player_.color = color_;
		//to be continued
		//need implementation for the minions
		//muahahaha
	}
}
