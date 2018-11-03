using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CollectiblesController: MonoBehaviour {

	public CollectiblesData[] cd;

	void Awake(){

		DontDestroyOnLoad (gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
	}

	void Update () {
		if (Input.GetKeyDown ("l")) {
			Debug.Log ("Loading Data...");
			LoadData ();
		} else if (Input.GetKeyDown("s")) {
			Debug.Log ("Saving data...");
			SaveData ();
		}
	}

	public void IncrementCount(GameObject go){
		if (go.name.Contains ("apple")) {
			cd [0].collectibleNum++;
		} else if (go.name.Contains ("5 Side Diamond")) {
			cd [1].collectibleNum++;
		} else if (go.name.Contains ("pumpkin")) {
			cd [2].collectibleNum++;
		} else if (go.name.Contains ("Crystal_Light_Blue_01")) {
			cd [3].collectibleNum++;
		}
		OutputCounts ();
	}

	void OutputCounts()
	{
		Debug.Log ("You've Collected: ");
		Debug.Log ("Apple = " + cd[0].collectibleNum);
		Debug.Log ("5 Side Diamond = " + cd[1].collectibleNum);
		Debug.Log ("Pumpkin = " + cd[2].collectibleNum);
		Debug.Log ("Crystal = " + cd [3].collectibleNum);
	}

	public void SaveData()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/gameData.dat");
		bf.Serialize (fs, cd);
		fs.Close ();
		Debug.Log ("Saved Data");
	}

	public void LoadData()
	{
		if (File.Exists (Application.persistentDataPath + "/gameData.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open (Application.persistentDataPath + "/gameData.dat", FileMode.Open);
			cd = (CollectiblesData[])bf.Deserialize (fs);
			fs.Close ();
			Debug.Log ("Loaded Data");
		} else {
			Debug.LogError ("File you are trying to load from is missing");
		}
	}
}
