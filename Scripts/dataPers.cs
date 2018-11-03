using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataPers : MonoBehaviour {



	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("health")) {
			Debug.Log ("Vrijednost: " + PlayerPrefs.GetInt ("health"));
		} else {
			Debug.Log ("Nema vrijednosti of ranije.");
			PlayerPrefs.SetInt ("health", 100);
		}
		Debug.Log ("End of Start");
	}
	
	void OnGUI() {
		GUILayout.Label("Vrijednost: " + PlayerPrefs.GetInt ("health"));
	}
}
