using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeJoyStick : MonoBehaviour {

	public Text text_;
	public Button change_;
	public GameObject joyStick_;
	public GameObject rotate_;

	bool isRight = true;
	Transform transform_;


	void Start () {
		Button myBtn = change_.GetComponent<Button>();
		myBtn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		if (isRight)
		{
			text_.text = "Left hand";
			isRight = !isRight;
		
			var tmp = rotate_.transform.position;
			rotate_.transform.position = joyStick_.transform.position;
			joyStick_.transform.position = tmp;
			//change positions ...
		} 
		else 
		{
			text_.text = "Right hand";
			isRight = !isRight;

			var tmp = rotate_.transform.position;
			rotate_.transform.position = joyStick_.transform.position;
			joyStick_.transform.position = tmp;
			//change positions
		}
	}
}
