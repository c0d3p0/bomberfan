using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModelAnimationManager : MonoBehaviour
{
	void Start()
	{
		transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);	
	}

	void Update()
	{
		HandleRotation(Time.deltaTime);
		HandleGrow(Time.deltaTime);
	}

	protected void HandleRotation(float deltaTime)
	{
		mRotation.Set(0f, deltaTime * mRotationSpeed, 0f);
		transform.Rotate(mRotation);
	}

	protected void HandleGrow(float deltaTime)
	{
		if(!mFinalSize)
		{
			mScale = transform.localScale * Mathf.Lerp(mScale.x, mMaxSize, mGrowDuration); 

			if(mScale.x >= mMaxSize)
			{
				transform.localScale = new Vector3(mMaxSize, mMaxSize, mMaxSize);
				mFinalSize = true;
			}
			else
				transform.localScale = mScale;
		}
	}

	public float mGrowDuration = 1.3f;
	public float mMaxSize = 1.6f;
	public float mRotationSpeed = 100f;

	protected Vector3 mRotation;
	protected Vector3 mScale;

	protected float mGrowVelocity;
	protected bool mFinalSize;
}
