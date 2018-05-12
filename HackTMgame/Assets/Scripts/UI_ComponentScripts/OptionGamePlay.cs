using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionGamePlay : MonoBehaviour {

	// Use this for initialization
	public GameObject panelOption_;
	public GameObject panelThis_;
	public Button options_;

	void Start () {
		Button btn = options_.GetComponent<Button> ();
		btn.onClick.AddListener(OnClickTask);
	}
	
	void OnClickTask()
	{
		panelThis_.SetActive (false);
		panelOption_.SetActive (true);
	}
}
