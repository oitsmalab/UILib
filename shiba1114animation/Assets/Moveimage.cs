using UnityEngine;
using System.Collections;

public class Moveimage : MonoBehaviour {
	public AnimationCurve curve;//ここで３軸すべてのカーブの形を決める
	float M0;
	float[] Eva;
	// Use this for initialization
	void Start () {
		GameObject.Find ("GUI Text").guiText.text = "moveAnimation sample";
		Eva = new float[curve.length];
		M0 = curve.Evaluate(curve.length - 1) - curve.Evaluate(0);
		for(int i=1; i<curve.length-1; i++){
			Eva[i] = curve.Evaluate (i) - curve.Evaluate (0);
		}//相対高度へ変換
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
		AnimationCurve curvex = new AnimationCurve();
		curvex.keys = curve.keys;

		float X, X1;
		//x軸
		X1 = p2.x - gameObject.gameObject.transform.position.x;
		X = X1 / M0; //元の幅と変更後の幅の比率
		Keyframe x1 = new Keyframe (0,gameObject.transform.position.x);//配列0ばんめのキーフレーム変更
		Keyframe x2 = new Keyframe (curve.length-1,p2.x);//終端キーフレーム変更

		curvex.MoveKey (0,x1);
		curvex.MoveKey(curvex.length-1, x2);//両端キーフレーム置き換え

	for (int i=1; i<curve.length-1; i++) {
			Debug.Log (i);
		curvex.MoveKey (i,new Keyframe(i,curvex.Evaluate(0) + Eva[i]* X)  );
		}//中間のキーフレーム置き換え


		//y
	 AnimationCurve curvey = new AnimationCurve();
	 curvey.keys = curve.keys;
		float Y, Y1;
		Y1 = p2.y - gameObject.gameObject.transform.position.y;
		Y = Y1 / M0; //元の幅と変更後の幅の比率
		Keyframe y1 = new Keyframe (0,gameObject.transform.position.y);//配列0ばんめのキーフレーム変更
		Keyframe y2 = new Keyframe (curve.length-1,p2.y);//終端キーフレーム変更
		
		curvey.MoveKey (0,y1);
		curvey.MoveKey(curvey.length-1, y2);//両端キーフレーム置き換え
		
		for (int i=1; i<curve.length-1; i++) {
			Debug.Log (i);
			curvey.MoveKey (i,new Keyframe(i,curvey.Evaluate(0) +  Eva[i] * Y)  );
		}//中間のキーフレーム置き換え


		//z
		AnimationCurve curvez = new AnimationCurve();
		curvez.keys = curve.keys;
		float Z, Z1;
		Z1 = p2.z - gameObject.gameObject.transform.position.z;
		Z = Z1 / M0; //元の幅と変更後の幅の比率
		Keyframe z1 = new Keyframe (0,gameObject.transform.position.z);//配列0ばんめのキーフレーム変更
		Keyframe z2 = new Keyframe (curve.length-1,p2.z);//終端キーフレーム変更
		
		curvez.MoveKey (0,z1);
		curvez.MoveKey(curvez.length-1, z2);//両端キーフレーム置き換え
		
		for (int i=1; i<curve.length-1; i++) {
			Debug.Log (i);
			curvez.MoveKey (i,new Keyframe(i,curvez.Evaluate(0) +  Eva[i] * Z)  );
		}//中間のキーフレーム置き換え


		AnimationClip clip2 = new AnimationClip ();
		clip2.SetCurve ("", typeof(Transform), "localPosition.x", curvex);
		clip2.SetCurve ("", typeof(Transform), "localPosition.y", curvey);
		clip2.SetCurve ("", typeof(Transform), "localPosition.z", curvez);
		animation.AddClip (clip2, "moveclip2");
		animation.Play ("moveclip2");
	
	}
	
	}

