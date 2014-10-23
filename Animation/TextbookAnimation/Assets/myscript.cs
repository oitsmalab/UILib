using UnityEngine;
using System.Collections;

public class myscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("GUI Text").guiText.text = "AnimationClip sample";
		AnimationClip clip = new AnimationClip ();
		AnimationCurve curve = AnimationCurve.Linear (0f, 3f, 3f, 3f);
		Keyframe key = new Keyframe (1.5f, 7f);
		curve.AddKey (key);
		clip.SetCurve ("", typeof(Transform), "localPosition.z", curve);
		clip.SetCurve ("", typeof(Transform), "localPosition.y", curve);
		clip.wrapMode = WrapMode.Loop;
		animation.AddClip (clip, "clip1");
		animation.Play ("clip1");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (1f, 1f, 1f);
		if (Input.GetKeyDown (KeyCode.Space)) {
						animation.Stop ();
						GameObject.Find ("GUI Text").guiText.text = "Stopped!!";
				}
				if (Input.GetKeyUp (KeyCode.Space)) {
						animation.Play ("clip1");
				GameObject.Find ("GUI Text").guiText.text = "Animation sample";
				}
	}
}
