using NUnit.Framework;
using UnityEngine;
using System.Collections;
using UnityEditor;
public class TestSelect2 : MonoBehaviour
{
		//GetRelativeHeightsFromAnimationCurvePattern　テスト
	//********************************************************************************************************************************
	struct curve{
		public float height;
		public float[] keyframeV;
	}

	[TestCase(1.0f, 2f)]
	public void TestGetRelativeHeightsFromAnimationCurvePattern (float time, float value)
	{
	 	AnimationCurve[] animationCurvePattern = new AnimationCurve[1];
		animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(time, value),new Keyframe(1.5f,3f), new Keyframe(2f, 1f));
		
		select2 select2Ref = new select2 ();
		select2.Curve[] curveArray = new select2.Curve[1];
		select2Ref.GetRelativeHeightsFromAnimationCurvePattern (animationCurvePattern, curveArray);
	
		 curve[] curveArray2 = new curve[1]; //比較用配列
		curveArray2[0].height = 1f;
		curveArray2[0].keyframeV = new float[4];
		curveArray2[0].keyframeV[0] = 0f;
		curveArray2[0].keyframeV[1] = 2f;
		curveArray2[0].keyframeV[2] = 3f;
		curveArray2[0].keyframeV[3] = 0f;
		//予測基準値1f, 予測配列値{0f,2f,3f,0f}

		Assert.AreEqual(curveArray[0].height, curveArray2[0].height);
		Assert.AreEqual(curveArray[0].keyframeValues,curveArray2[0].keyframeV);

	}

	//***************************************************************************************************************************

	//***********************************moveAnimation3テスト*******************************************************************
	[Test]
	[TestCase(1f,0)]
	public void testmoveanimation3(float p ,int a_Number){
		Debug.Log("A");
		Vector3 targetP = new Vector3 (p, p, 0f);
		Vector3 gameobjectP = new Vector3 (0f, 0f, 0f);
		Debug.Log("B");
		select2 select2ref = new select2 ();
		//ここまで正常
		select2.Curve[] curveArray2 = new select2.Curve[1]; //比較用配列
		curveArray2[0].height = 1f; 
		curveArray2[0].keyframeValues = new float[4];
		curveArray2[0].keyframeValues[0] = 0f;
		curveArray2[0].keyframeValues[1] = 2f;
		curveArray2[0].keyframeValues[2] = 3f;
		curveArray2[0].keyframeValues[3] = 0f;

		select2ref.animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 2f),new Keyframe(1.5f,3f), new Keyframe(2f, 1f));
		select2ref.animationCurvePatternZoom[0]  = new AnimationCurve(new Keyframe(0f,0f),new Keyframe(1f,2f),new Keyframe(1.5f,1.5f),new Keyframe(2f,2f));
		Debug.Log ("moveanimation");
		AnimationClip move3clip = select2ref.moveAnimation3 (targetP, a_Number, gameobjectP, select2ref.animationCurvePattern,curveArray2);
		Debug.Log("end");

		//追加　AnimationClipっからAnimationCurveを取得する　
		AnimationClipCurveData[] allCurves = AnimationUtility.GetAllCurves(move3clip, true);

		//moveanimationメソッド実行
		//以下、比較用パラメータ作成 ,targetP= (1f,1f,0f) ,gameobjectP = (0f,0f,0f) 変換倍率 = 1-0 / 1 = 1 変換後基準高 = 0 ,1 
		AnimationCurve curveZ2 = new AnimationCurve (new Keyframe (0f, 0f), new Keyframe (1f, 2f),new Keyframe(1.5f,1.5f) ,new Keyframe (2f, 2f));
		AnimationCurve curveX2 = new AnimationCurve (new Keyframe (0f, 0f), new Keyframe (1f, 2f), new Keyframe (1.5f, 3f), new Keyframe (2f, 1f));

		//比較
		Assert.AreEqual (allCurves[2].curve.keys, curveZ2.keys);	//clip3にセットしたcurveZ2と比較
		Assert.AreEqual (allCurves [0].curve.keys, curveX2.keys);	//clip3のcurveXとcurveX2の比較
		}

	//****************************************************************************************************************************************
	//AnimationClipにはsetCurveの実行順に関係なく,x軸は[0],y軸は[1],z軸は[2]となる
}