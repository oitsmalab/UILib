using NUnit.Framework;
using UnityEngine;
using System.Collections;

class TestSelect2
{
	[TestCase(2f, 2f)]
	public void TestGetRelativeHeightsFromAnimationCurvePattern1 (float time, float value)
	{
		AnimationCurve[] animationCurvePattern = new AnimationCurve[1];
		animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(time, value),new Keyframe(0.5f,3f), new Keyframe(1f, 1f));
		
		select2 select2Ref = new select2 ();
		select2.Curve[] curveArray = new select2.Curve[1];
		
		select2Ref.GetRelativeHeightsFromAnimationCurvePattern (animationCurvePattern, curveArray);
		
		Assert.AreEqual(curveArray[0].height,1);
	}

	[TestCase(2f, 2f)]
	public void TestGetRelativeHeightsFromAnimationCurvePattern2 (float time, float value)
	{
		AnimationCurve[] animationCurvePattern = new AnimationCurve[1];
		animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(time, value), new Keyframe(0.5f,3f) ,new Keyframe(1f, 1f));
		
		select2 select2Ref = new select2 ();
		select2.Curve[] curveArray = new select2.Curve[1];
		
		select2Ref.GetRelativeHeightsFromAnimationCurvePattern (animationCurvePattern, curveArray);
		float[] x = {0f,1.5f,0.5f,0f};
		Assert.AreEqual(curveArray[0].keyframeValues,1);
	}


}