using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	public Camera camera;
	public NavMeshAgent agent;
	private Animator myAnim;
	private float dist;
	RaycastHit hitInfo;
	Quaternion newRotation;
	float rotSpeed = 5f;

	// Use this for initialization
	void Start () {
		agent = GetComponent <NavMeshAgent> ();
		myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Mouse click");
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);

			if(Physics.Raycast(ray, out hitInfo))
				{
					GetComponent<NavMeshAgent>().SetDestination(hitInfo.point);
					myAnim.SetBool ("isRunning", true);
				}
		}

		Vector3 relativePos = hitInfo.point - transform.position;
		newRotation = Quaternion.LookRotation(relativePos, Vector3.up);
			newRotation.x = 0.0f;
			newRotation.z = 0.0f;

		transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, rotSpeed * Time.deltaTime);

		dist = Vector3.Distance (hitInfo.point, transform.position);
	
		if (dist < 1f) {
			myAnim.SetBool ("isRunning", false);
		}
	}
}
