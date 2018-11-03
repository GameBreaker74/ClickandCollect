using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesCollider : MonoBehaviour {

	CollectiblesController cc;

	void Start() {
		GameObject ccgo = GameObject.Find ("CollectiblesController");
		cc = ccgo.GetComponent<CollectiblesController> ();
	}

	private AudioSource source;
	[SerializeField] private AudioClip clip;

	void OnTriggerEnter(Collider col) {
		Debug.Log ("You've hit the " + gameObject.name);
		source = col.GetComponent<AudioSource> ();
		source.PlayOneShot (clip, 1.0f);
		cc.IncrementCount (gameObject);
		Destroy (gameObject);

	}
}
