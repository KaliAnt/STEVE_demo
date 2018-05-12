using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackOptions : MonoBehaviour {

	public GameObject panelBack_;
	public GameObject panelThis_;
	public Button back_;
	// Use this for initialization
	void Start () {
		Button btn = back_.GetComponent<Button> ();
		btn.onClick.AddListener(OnClickTask);
	}
	
	// Update is called once per frame
	void OnClickTask () {
		panelThis_.SetActive (false);
		panelBack_.SetActive (true);
	}
}
