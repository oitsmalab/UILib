using NUnit.Framework;
using UnityEngine;
using System.Collections;

class TestSelect2
{
	[TestCase(1, 1)]
	public void TestGetRelativeHeightsFromAnimationCurvePattern1 (float time, float value)
	{

		AnimationCurve[] animationCurvePattern = new AnimationCurve[1];
		animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(time, value));

		select2 select2Ref = new select2 ();
		select2.Curve[] curveArray = new select2.Curve[1];

		select2Ref.GetRelativeHeightsFromAnimationCurvePattern (animationCurvePattern, curveArray);

		Assert.AreEqual(curveArray[0].height, 1);
	}

}