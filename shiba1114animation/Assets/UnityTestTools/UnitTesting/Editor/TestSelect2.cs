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
		
		Assert.AreEqual(curveArray[0].height,2);
		
	}


	[TestCase(2f, 2f)]
	public void TestGetRelativeHeightsFromAnimationCurvePattern2 (float time, float value)
	{
		AnimationCurve[] animationCurvePattern = new AnimationCurve[1];
		animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(time, value), new Keyframe(0.5f,3f) ,new Keyframe(1f, 1f));
		
		select2 select2Ref = new select2 ();

		select2.Curve[] curveArray = new select2.Curve[1];
		
		select2Ref.GetRelativeHeightsFromAnimationCurvePattern (animationCurvePattern, curveArray);
		float[] x = {0f,3.0f,1.0f,0f};
		Assert.AreEqual(curveArray[0].keyframeValues,x);
	}

	/*
	AnimationCurve[] animationCurvePattern2 = new AnimationCurve[1];
	animationCurvePattern2[0] =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(time, value), new Keyframe(0.5f,3f) ,new Keyframe(1f, 1f));
	select2.Curve[] curveArray2 = new select2.Curve[1];

	[TestCase(10f,0f,animationCurvePattern2,0,curveArray2)]
	public AnimationCurve GetAdjustedAnimationCurve(float targetPosition,float transformPosition,AnimationCurve[] animationCurvePattern ,int animationNumber ,Curve[] curveArray){
		select2 select2Ref = new select2 ();
		select2Ref.gameObject.transform.position = new Vector3 (0f, 0f, 0f);

		AnimationCurve x = animation


	}
*/

	[TestCase(2f,0,0,1,0)]
	public void TestGetAdjustAnimationCurve(float targetposition,float transposition,AnimationCurve[] animationCurvePattern ,int animationNumber,Curve[] curveArray){

		float[] x = { 3f,2f };

		AnimationCurve curve = new AnimationCurve ();

		select2 select2Ref = new select2 ();

	 	curve = select2Ref.GetAdjustedAnimationCurve(targetposition,transposition,animationCurvePattern,animationNumber,curveArray);

		Assert.AreEqual(curve,x);
	}

}