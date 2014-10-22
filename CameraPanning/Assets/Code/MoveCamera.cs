using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
	public float speed = 10.0f;
	public Transform thisObject;
	public int slice;
	public float distance;
	public float velocity;
	public float waitTime;

	void Start(){
		thisObject = GameObject.Find ("Main Camera").transform;
	}

	void Update () {
		if(Input.GetKeyUp(KeyCode.Space)){
			Debug.Log("Space");
			float nowX = thisObject.position.x;
			float nowY = thisObject.position.y;
			float nowZ = thisObject.position.z;
			Debug.Log("nowY = " + nowY);
			Debug.Log("nowZ = " + nowZ);
			velocity = CalcVelocity(slice,distance);
			StartCoroutine (MoveObject(nowX,nowY,nowZ,slice,distance,waitTime));
		}

		if (Input.GetMouseButtonUp(1)){
 			Debug.Log("右クリック");
		}
		if (Input.GetMouseButtonUp(0)){
			Debug.Log("左クリック");
		}
	}

	float CalcVelocity(int sliceCount,float distance){
		return distance / sliceCount;
	}

	float CalcAcceleration(int sliceCount,float distance){
		return distance / (sliceCount * sliceCount);
	}

	private IEnumerator MoveObject (float nowX,float nowY,float nowZ,int sliceCount,float distance,float waitTime){
		int count = 0;
		while(slice != count){
			nowX += velocity;
			Vector3 v3 = new Vector3(nowX,nowY,nowZ);
			thisObject.position = v3;
			count++;
			Debug.Log("count = " + count);
			yield return new WaitForSeconds(waitTime);
		}
		yield break;
	}


}