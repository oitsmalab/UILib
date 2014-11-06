using UnityEngine;
using System.Collections;

public class Moveimage : MonoBehaviour {
	public AnimationCurve curve;//初期の２つのキーフレームを初期化および操作


	// Use this for initialization
	void Start () {
		GameObject.Find ("GUI Text").guiText.text = "moveAnimation sample";
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetMouseButtonUp (0)) {
						Debug.Log ("左クリック");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast (ray,out hit) && gameObject != hit.collider.gameObject){
				moveAnimation2(hit.collider.gameObject.transform.position);
				Debug.Log ("選択移動");
			}
				}
	}

	void moveAnimation2 (Vector3 p2){
		AnimationClip clip2 = new AnimationClip ();//

		//clip2.SetCurve ("", typeof(Transform), "localPosition.y", curve);
		//clip2.SetCurve ("", typeof(Transform), "localPosition.z", curve);
		//curve.keys[0] = new Keyframe (0f,gameObject.transform.position.x);
		Keyframe testKey=new Keyframe (0f,curve.Evaluate (0f)-2);
		curve.MoveKey(0,testKey);
		testKey = curve.keys [1];
		testKey.value = testKey.value - 2;
		curve.MoveKey(1,testKey);
		clip2.SetCurve ("", typeof(Transform), "localPosition.x", curve);
		animation.AddClip (clip2, "moveclip2");
		animation.Play ("moveclip2");
	
	}

	void moveAnimation (Vector3 p) {
		float dx2 = (p.x + gameObject.transform.position.x)/2; 
		float dy2 = (p.y + gameObject.transform.position.y)/2; 
		float dz2 = (p.z + gameObject.transform.position.z)/2; 

				AnimationClip clip = new AnimationClip ();
				AnimationCurve curvex = AnimationCurve.Linear (0f, gameObject.transform.position.x, 1f, p.x);
				AnimationCurve curvey = AnimationCurve.Linear (0f, gameObject.transform.position.y, 1f, p.y);
				AnimationCurve curvez = AnimationCurve.Linear (0f, gameObject.transform.position.z, 1f, p.z);
							//Linear(start_time, start_position, end_time, end_position);

				Keyframe keyx1 = new Keyframe (0.1f, (float)(dx2 + gameObject.transform.position.x)/2);
				curvex.AddKey (keyx1);
				Keyframe keyy1 = new Keyframe (0.1f,(float)(dy2 + gameObject.transform.position.y)/2);
				curvey.AddKey (keyy1);
				Keyframe keyz1 = new Keyframe (0.1f, (float)(dz2 + gameObject.transform.position.z)/2);
				curvez.AddKey (keyz1);

			//	Keyframe keyx2 = new Keyframe (0.5f,(float)dx2);
			//	curvex.AddKey (keyx2);
			//	Keyframe keyy2 = new Keyframe (0.5f, (float)dy2);
			//	curvey.AddKey (keyy2);
			//	Keyframe keyz2 = new Keyframe (0.5f,(float)dz2);
			//	curvez.AddKey (keyz2);

				Keyframe keyx3 = new Keyframe (0.9f, (float)(dx2 + p.x)/2);
				curvex.AddKey (keyx3);
				Keyframe keyy3 = new Keyframe (0.9f, (float)(dy2 + p.y)/2);
				curvey.AddKey (keyy3);
				Keyframe keyz3 = new Keyframe (0.9f, (float)(dz2 + p.z)/2);
				curvez.AddKey (keyz3);

							//↑各軸の指定時間ごとの位置(time , position)
				clip.SetCurve ("", typeof(Transform), "localPosition.x", curvex);
				clip.SetCurve ("", typeof(Transform), "localPosition.y", curvey);
				clip.SetCurve ("", typeof(Transform), "localPosition.z", curvez);
				animation.AddClip (clip, "moveclip");
				animation.Play ("moveclip");
		}


	}

