using UnityEngine;
using System.Collections;

public class TouchMove : MonoBehaviour {

	private float delta=5.0f;
	public GameObject center;
	Vector3 toVector;
	
	
	// Use this for initialization
	void Start () {
		toVector = center.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		moveTo ();
	}

	void moveTo(){
		transform.position = Vector3.MoveTowards (transform.position, toVector, delta);
		}
}
