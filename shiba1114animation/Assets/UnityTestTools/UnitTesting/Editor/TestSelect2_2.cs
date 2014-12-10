using NUnit.Framework;
using UnityEngine;
using System.Collections;

public class TestSelect2_2 : MonoBehaviour
{
		//GetRelativeHeightsFromAnimationCurvePattern　テスト
	//********************************************************************************************************************************
	struct curve{
		public float height;
		public float[] keyframeV;
	}


	[TestCase(2f,0,0,1,0)]
	public void TestGetAdjustAnimationCurve(float targetposition,float transposition,AnimationCurve[] animationCurvePattern ,int animationNumber,Curve[] curveArray){

		float[] x = { 3f,2f };

		AnimationCurve curve = new AnimationCurve ();

		select2 select2Ref = new select2 ();

	 	curve = select2Ref.GetAdjustedAnimationCurve(targetposition,transposition,animationCurvePattern,animationNumber,curveArray);

		Assert.AreEqual(curve,x);
	}
}