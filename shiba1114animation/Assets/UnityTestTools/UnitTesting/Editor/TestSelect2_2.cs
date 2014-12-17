using NUnit.Framework;
using UnityEngine;
using System.Collections;

public class TestSelect2_2 : MonoBehaviour
{
		//GetRelativeHeightsFromAnimationCurvePattern　テスト
	//********************************************************************************************************************************
	struct curve{
		public float height;
		public float[] keyframeValues;
	}


	[TestCase(2f,0f,2)]
	public void TestGetAdjustAnimationCurve(float targetposition,float transposition,int animationNumber){

		select2 select2Ref = new select2 ();

		select2.Curve[] curveArray = new select2.Curve[animation+1];

		curveArray[0].height = 1f;
		curveArray[0].keyframeValues = new float[animationNumber + 1];
		curveArray[0].keyframeValues[0] = 0f;
		curveArray[0].keyframeValues[1] = 0.5f;
		curveArray[0].keyframeValues[2] = 0f;

		AnimationCurve[] animationCurvePattern = new AnimationCurve[4];

		animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f), new Keyframe(2f, 2f));

		AnimationCurve curve1 = new AnimationCurve ();

	 	curve1 = select2Ref.GetAdjustedAnimationCurve(targetposition,transposition,animationCurvePattern,animationNumber,curveArray);

		Assert.AreEqual(curve1.Evaluate(curve1.keys[1].time),1.0f);
	}
}