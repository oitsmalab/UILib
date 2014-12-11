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

	 // Vector3 targetP = new Vector3 (1f, 1f, 0f);
	[Test]
	[TestCase(1f,0)]
	public void testmoveanimation3(float p ,int a_Number){
		Vector3 position = new Vector3 (p, p, 0f);
		AnimationCurve[] animationCurvePattern = new AnimationCurve[1];
		animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(1f, 2f),new Keyframe(1.5f,3f), new Keyframe(2f, 1f));
		select2.Curve[] curveArray = new select2.Curve[1];
		select2 select2ref = new select2 ();
		select2ref.animationCurvePatternZoom[0]  = new AnimationCurve(new Keyframe(0f,0f),new Keyframe(1f,1f),new Keyframe(2f,2f));
		AnimationClip move3clip = select2ref.moveAnimation3 (position, a_Number);

		//追加　AnimationClipっからAnimationCurveを取得する　
		AnimationClipCurveData[] allCurves = AnimationUtility.GetAllCurves(move3clip, true);

		//moveanimationメソッド実行
		//以下、比較用パラメータ作成
		AnimationCurve curveZ2 = new AnimationCurve (new Keyframe (0f, 0f), new Keyframe (1f, 1f), new Keyframe (2f, 2f));

		//比較
		Assert.AreEqual (allCurves[2].curve.keys, curveZ2.keys);						//clip3にセットしたcurveZ2と比較
		}

	//結果：moveanimation3が「X」のデバッグログしか出してない
}