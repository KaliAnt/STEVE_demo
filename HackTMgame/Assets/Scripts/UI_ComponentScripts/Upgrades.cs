using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

	public GameObject panelUpgrade_;
	public GameObject panelThis_;
	public Button upgrades_;
	// Use this for initialization
	void Start () {
		Button btn = upgrades_.GetComponent<Button> ();
		btn.onClick.AddListener(OnClickTask);
	}

	void OnClickTask()
	{
		panelThis_.SetActive (false);
		panelUpgrade_.SetActive (true);
	}

}
