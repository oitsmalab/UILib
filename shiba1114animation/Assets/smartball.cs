using UnityEngine;
using System.Collections;

public class smartball : MonoBehaviour {
 	static public float power = 0f;
	GameObject[] cubes = new GameObject[5];
	Vector3[] moves = new Vector3[5];
	int flag = 0;
	
	void Start () {
		moves [0] = new Vector3 (0f, 1f, 0f);
		moves [1] = new Vector3 (-3f, 1f, 5f);
		moves [2] = new Vector3 (3f, 1f, 5f);
		moves [3] = new Vector3 (-3f, 1f, -3f);
		moves [4] = new Vector3 (3f, 1f, -3f);
		for (int i=0; i<5; i++) {
						cubes [i] = GameObject.Find ("BoardCube" + i);
						Vector3 move = cubes [i].transform.position;
						AnimationClip clip = new AnimationClip ();
						Keyframe[] keysX = new Keyframe[2];
						keysX [0] = new Keyframe (0f, move.x - 3);
						keysX [1] = new Keyframe (i + 1f, move.x + 3);
						AnimationCurve curveX = new AnimationCurve (keysX);
						clip.SetCurve ("", typeof(Transform), "localPosition.x", curveX);
						clip.wrapMode = WrapMode.PingPong;

						Keyframe[] keysY = new Keyframe[2];
						keysY [0] = new Keyframe (0f, move.y);
						keysY [1] = new Keyframe (i + 1f, move.y);
						AnimationCurve curveY = new AnimationCurve (keysY);
						clip.SetCurve ("", typeof(Transform), "localPsition.y", curveY);

						Keyframe[] keysZ = new Keyframe[2];
						keysZ [0] = new Keyframe (0f, move.z);
						keysZ [1] = new Keyframe (i + 1f, move.z);
						AnimationCurve curveZ = new AnimationCurve (keysZ);
						clip.SetCurve ("", typeof(Transform), "localPosition.z", curveZ);

						cubes [i].animation.AddClip (clip, "clip1");
						cubes [i].animation.Play ("clip1");
				}
	}


	void Update () {
		MoveCube ();
		rigidbody.AddForce (0f, 0f, -10f);
		if (Input.GetKey (KeyCode.Space) && flag == 0) {
						power += 0.01f;
						if (power > 1f) {
								power = 1f;
						}
						renderer.material.color = new Color (1f, power, 0f);
				}
		if (Input.GetKeyUp (KeyCode.Space) && flag == 0) {
						rigidbody.AddForce (new Vector3 (0f, 0f, power * 5000f));
						power = 0f;
						flag = 1;
						renderer.material.color = Color.red;
				}
	
	}
	void MoveCube(){
				for (int i=0; i<5; i++) {
						cubes [i].transform.Rotate (new Vector3 (0f, 2.5f, 0f));
				}
		}

}
