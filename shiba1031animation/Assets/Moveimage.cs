using UnityEngine;
using System.Collections;

public class Moveimage : MonoBehaviour {
	//public float tspeed;


	// Use this for initialization
	void Start () {
		GameObject.Find ("GUI Text").guiText.text = "moveAnimation sample";
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetMouseButtonUp (0)) {
						Debug.Log ("左クリック");//オブジェクト指定するためにマウスのざひょうしゅとくしたい
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast (ray,out hit) && gameObject != hit.collider.gameObject){
				moveAnimation(hit.collider.gameObject.transform.position);
				Debug.Log ("選択移動");
			}
				}
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

