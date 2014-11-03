using UnityEngine;
using System.Collections;
using UnityEditor;

public class EvaluateKeys : MonoBehaviour {


	// Use this for initialization
	void Start () {

		Animation anim = GetComponent<Animation> ();
		anim.Play ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
