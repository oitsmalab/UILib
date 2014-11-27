using NUnit.Framework;
using UnityEngine;
using System.Collections;

class TestSelect2
{

	public float[] position = {0.3f,0.5f,2.0f};

	[TestCase(1.0f, 2f)]
	public void TestGetRelativeHeightsFromAnimationCurvePattern1 (float time, float value)
	{
		AnimationCurve[] animationCurvePattern = new AnimationCurve[1];
		animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(time, value), new Keyframe(1f, 1f));
		
		select2 select2Ref = new select2 ();
		select2.Curve[] curveArray = new select2.Curve[1];
		
		select2Ref.GetRelativeHeightsFromAnimationCurvePattern (animationCurvePattern, curveArray);
		
		Assert.AreEqual(curveArray[0].height, 1);
	}

	[TestCase(0.5f, 2f)]
	public void TestGetRelativeKeyFlameValuesFromAnimationCurvePattern(float time, float value)
	{
		AnimationCurve[] animationCurvePattern = new AnimationCurve[1];
		animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(time, value), new Keyframe(1f, 1f));
		
		select2 select2Ref = new select2 ();
		select2.Curve[] curveArray = new select2.Curve[2];
		
		select2Ref.GetRelativeHeightsFromAnimationCurvePattern(animationCurvePattern, curveArray);

		float[] x = {0.0f,2.0f,0.0f};
		
		Assert.AreEqual (curveArray [0].keyframeValues, x);
	}

	[TestCase(position,2)]
	public void TestMoveAnimation(Vector3 target,int number){

		GameObject gameObject;
		gameObject.transform.position.x = 0;

		AnimationClip clip = new AnimationClip ();
		AnimationCurve[] animationCurvePattern = new AnimationCurve[1];

		select2 select2Ref = new select2 ();
		select2.Curve[] curveArray = new select2.Curve[2];

		AnimationCurve curveX =
			select2Ref.GetAdjustedAnimationCurve(target.x,gameObject.transform.position.x,animationCurvePattern,number,curveArray);

		Assert.AreEqual(clip.SetCurve("", typeof(Transform), "localPosition.x", curveX) , 1);
	}
	
}