using NUnit.Framework;
using UnityEngine;
using System.Collections;

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
		animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(time, value), new Keyframe(2f, 1f));
		
		select2 select2Ref = new select2 ();
		select2.Curve[] curveArray = new select2.Curve[1];
		select2Ref.GetRelativeHeightsFromAnimationCurvePattern (animationCurvePattern, curveArray);
	
		curve[] curveArray2 = new curve[1]; //比較用配列
		curveArray2[0].height = 1f;
		curveArray2[0].keyframeV = new float[3];
		curveArray2[0].keyframeV[0] = 0f;
		curveArray2[0].keyframeV[1] = 2f;
		curveArray2[0].keyframeV[2] = 0f;
		//予測基準値1f, 予測配列値{0f,2f,0f}

		Assert.AreEqual(curveArray[0].height, curveArray2[0].height);
		Assert.AreEqual(curveArray[0].keyframeValues,curveArray2[0].keyframeV);

	}
}