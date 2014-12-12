using UnityEngine;
using System.Collections;

public class select2 : MonoBehaviour {

	public AnimationCurve[] animationCurvePattern = new AnimationCurve[4];//予め設定する値（アニメーションのパターン）0-4で指定
	public  GameObject[] imageArrays = new GameObject[2];//移動先オブジェクト
	public int[] moveAnimationPatterns = new int[4] ;//アニメーションのパターンの順番
	int countObject = -1;//現在のオブジェクトの位置 始めに０番目の地点へ右キーで移動

	public struct Curve{
		public float height;//基準の高さ
		public float[] keyframeValues;//相対高度
	}
	
	Curve[] curveArray = new Curve[4];

	public AnimationCurve[] animationCurvePatternZoom = new AnimationCurve[1];

	void Start () {
		GameObject.Find ("GUI Text").guiText.text = "moveAnimation3 sample";
		GetRelativeHeightsFromAnimationCurvePattern (animationCurvePattern,curveArray);						
		Debug.Log (curveArray [0].height+ " firstheight");
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)){	
			if(countObject < imageArrays.Length-1){
				countObject ++;
				moveAnimation3(imageArrays[countObject].transform.position,moveAnimationPatterns[countObject],gameObject.transform.position,animationCurvePattern,curveArray);
				Debug.Log (1 +" cnt_"+countObject);
			}
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			if(countObject > 0){
				countObject --;
				moveAnimation3(imageArrays[countObject].transform.position,moveAnimationPatterns[countObject],gameObject.transform.position,animationCurvePattern,curveArray);
				Debug.Log (2+" cnt_"+countObject);
			}
		}
	}

	
	public void GetRelativeHeightsFromAnimationCurvePattern(AnimationCurve[] animationCurvePattern, Curve[] curveArray){
		for (int a=0; a<animationCurvePattern.Length; a++) {
			curveArray [a].keyframeValues = new float[animationCurvePattern [a].length];
		}//長さ確定　インスタンス化
		
		for (int k=0; k<animationCurvePattern.Length; k++) {
			curveArray [k].height = 
				animationCurvePattern [k].Evaluate (animationCurvePattern [k].keys[animationCurvePattern [k].length- 1].time) 
					- animationCurvePattern [k].Evaluate (animationCurvePattern [k].keys[0].time);
			for (int i=1; i<animationCurvePattern[k].length-1; i++) {
				curveArray [k].keyframeValues [i] = animationCurvePattern [k].Evaluate (animationCurvePattern [k].keys[i].time)
					- animationCurvePattern [k].Evaluate (animationCurvePattern [k].keys[0].time);
			}//配列１番目からn-1番目を相対高度へ変換
		}//配列curveの各要素の値確定
	}


	public AnimationClip moveAnimation3 (Vector3 targetPosition ,int animationNumber,Vector3 gameObjectPosition,AnimationCurve[] animationCurvePattern,Curve[] curveArray){
		Debug.Log("X");
		/*Debug.Log ("1: " + targetPosition);
		Debug.Log ("2: " + animationNumber);
		Debug.Log ("3: " + gameObjectPosition);
		Debug.Log ("4: " + animationCurvePattern);
		Debug.Log ("5: " + curveArray);
		*/
		AnimationCurve curveX = GetAdjustedAnimationCurve(targetPosition.x,gameObjectPosition.x,animationCurvePattern,animationNumber,curveArray);

		Debug.Log("Y");
		AnimationCurve curveY =
			GetAdjustedAnimationCurve(targetPosition.y,gameObjectPosition.y,animationCurvePattern,animationNumber,curveArray);

		Debug.Log ("Z");
		AnimationCurve curveZ = animationCurvePatternZoom [0];

		AnimationClip clip3 = new AnimationClip ();
		clip3.SetCurve ("", typeof(Transform), "localPosition.z", curveZ);
	
		Debug.Log("Curvechanged");
		clip3.SetCurve ("", typeof(Transform), "localPosition.x", curveX);
		clip3.SetCurve ("", typeof(Transform), "localPosition.y", curveY);
		//animation.AddClip (clip3, "moveclip3");
		//animation.Play ("moveclip3");  //引数としてclip3を返す場合は記述出来ない,テスト用のためにコメント化している

		Debug.Log("moveAnimation3END");
		return clip3;
	}

	public AnimationCurve GetAdjustedAnimationCurve(float targetPosition,float transformPosition,AnimationCurve[] animationCurvePattern ,int animationNumber ,Curve[] curveArray){

		AnimationCurve curve = new AnimationCurve ();
			curve.keys = animationCurvePattern[animationNumber].keys;

		float distanceToGo = targetPosition - transformPosition;
		float distanceToGoAdjusted = distanceToGo / curveArray [animationNumber].height; //元の幅と変更後の幅の比率

		curve.MoveKey (0,new Keyframe (curve.keys[0].time, transformPosition));//配列0ばんめのキーフレーム変更
		curve.MoveKey (curve.length - 1, new Keyframe (curve.keys[curve.length - 1].time, targetPosition) );//終端キーフレーム変更

		for (int i=1; i<animationCurvePattern[animationNumber].length-1; i++) {
			curve.MoveKey (i, new Keyframe (curve.keys[i].time, (curve.Evaluate (curve.keys[0].time) + curveArray [animationNumber].keyframeValues [i] * distanceToGoAdjusted)  )  );

			Debug.Log(curve.keys[i].time + "time  " + "number "+i);
			Debug.Log(animationCurvePattern[animationNumber].Evaluate(animationCurvePattern[animationNumber].keys[i].time) +" firstkey"+i +" anime"+animationNumber);
			Debug.Log(curve.Evaluate (curve.keys[i].time) + " cangedkey"+i);

		}//中間のキーフレーム置き換え

		Debug.Log (transformPosition+" c.P " +targetPosition+" t.P");
		Debug.Log(distanceToGoAdjusted + " changeheight");

		return curve;
	}
		

}