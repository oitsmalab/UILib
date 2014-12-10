using NUnit.Framework;
using UnityEngine;
using System.Collections;

public class TestSelect2 : MonoBehaviour
{
<<<<<<< HEAD
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
=======





	[TestCase(2f, 2f)]
	public void TestGetRelativeHeightsFromAnimationCurvePattern1 (float time, float value)
	{
		AnimationCurve[] animationCurvePattern = new AnimationCurve[1];
		animationCurvePattern[0] =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(time, value),new Keyframe(0.5f,3f), new Keyframe(1f, 1f));
>>>>>>> 19e5f430fc784868db20f8029c104df9e2a2da2b
		
		select2 select2Ref = new select2 ();
		select2.Curve[] curveArray = new select2.Curve[1];
		select2Ref.GetRelativeHeightsFromAnimationCurvePattern (animationCurvePattern, curveArray);
<<<<<<< HEAD
	
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

	//*********************************************************************************************************************************


	/* Vector3 Position = new Vector3(1f,1f,1f);
	 	[TestCase(Position,2)]
	public void TestMoveAnimation(Vector3 target,int number){
=======
		
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
>>>>>>> 19e5f430fc784868db20f8029c104df9e2a2da2b

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
<<<<<<< HEAD
	*/
=======

>>>>>>> 19e5f430fc784868db20f8029c104df9e2a2da2b
}