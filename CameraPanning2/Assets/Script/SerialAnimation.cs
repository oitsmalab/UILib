using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SerialAnimation : MonoBehaviour {

	public AnimationCurve[] AnimationPatterns = new AnimationCurve[4];
    public int[] MoveAnimationPatterns = new int[] { 0,1,2,3 };
	public GameObject[] ImageArrays;// 
	public int currentObject = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space) && currentObject != 4) {

			moveAnimation2(ImageArrays[currentObject].transform.position);
			//this.transform.position = new Vector3(ImageArrays[currentObject].transform.position.x,
			//                                      ImageArrays[currentObject].transform.position.y,ImageArrays[currentObject].transform.position.z-2 );
			currentObject++;
		}
	
	}


	void moveAnimation2 (Vector3 p2){

		List<Keyframe> newKeysX = new List<Keyframe>();
		List<Keyframe> newKeysY = new List<Keyframe>();
		List<Keyframe> newKeysZ = new List<Keyframe>();

		p2.z = p2.z - 2;

		Vector3 p1 = this.transform.position;

		Debug.Log ("Camera Position)" + p1.x);
		Debug.Log ("Destination Position)" + p2.x);

		Keyframe[] oldKeys = AnimationPatterns [MoveAnimationPatterns [currentObject]].keys;

		float endPos = oldKeys [oldKeys.Length-1].value;
		float endTime = oldKeys [oldKeys.Length-1].time;

		float ampX = (p2.x - p1.x) / endPos;
		float ampY = (p2.y - p1.y) / endPos;
		float ampZ = (p2.z - p1.z) / endPos;

		foreach (Keyframe k in  AnimationPatterns[MoveAnimationPatterns[currentObject]].keys) 
		{
			newKeysX.Add (new Keyframe (k.time, p1.x + k.value*ampX));
			newKeysY.Add (new Keyframe (k.time, p1.y + k.value*ampY));
			newKeysZ.Add (new Keyframe (k.time, p1.z + k.value*ampZ));
		}

		AnimationClip clip2 = new AnimationClip ();
		AnimationCurve curve2x = new AnimationCurve (newKeysX.ToArray());
		AnimationCurve curve2y = new AnimationCurve (newKeysY.ToArray());
		AnimationCurve curve2z = new AnimationCurve (newKeysZ.ToArray());


		clip2.SetCurve ("", typeof(Transform), "localPosition.x", curve2x);
		clip2.SetCurve ("", typeof(Transform), "localPosition.y", curve2y);
		clip2.SetCurve ("", typeof(Transform), "localPosition.z", curve2z);

		animation.AddClip (clip2, "moveclip2");
		animation.Play ("moveclip2");	

	}


}
