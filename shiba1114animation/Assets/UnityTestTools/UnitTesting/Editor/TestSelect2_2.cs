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


	[TestCase(2f,0f,0)]
	public void TestGetAdjustAnimationCurve(float targetposition,float transposition,int animationNumber){

		select2 select2Ref = new select2 ();

		select2.Curve[] curveArray = new select2.Curve[animationNumber];

		curveArray[animationNumber].height = 1f;
		curveArray[animationNumber].keyframeValues = new float[3];
		curveArray[animationNumber].keyframeValues[0] = 0f;
		curveArray[animationNumber].keyframeValues[1] = 0.5f;
		curveArray[animationNumber].keyframeValues[2] = 0f;

		AnimationCurve[] animationCurvePattern = new AnimationCurve[animationNumber];

		animationCurvePattern[animationNumber] =  new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f), new Keyframe(2f, 2f));

		AnimationCurve curve = new AnimationCurve ();

		curve.keys = animationCurvePattern[animationNumber].keys;

	 	curve = select2Ref.GetAdjustedAnimationCurve(targetposition,transposition,animationCurvePattern,animationNumber,curveArray);

		Assert.AreEqual(curve.Evaluate(curve.keys[animationNumber].time),1f);
	}
}