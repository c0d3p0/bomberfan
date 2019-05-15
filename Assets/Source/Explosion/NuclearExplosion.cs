using UnityEngine;
using System.Collections;
using System;

public class NuclearExplosion: MonoBehaviour
{
	void Start()
	{
		mCollider = GetComponent<SphereCollider>();
		mBomb = GetComponentInParent<Bomb>();
		mBlockWidthDepthDimension = GameObject.FindGameObjectWithTag(TagName.LEVEL_MANAGER).GetComponentInChildren<LevelData>().mBlockWidthDepthDimension;
		mCollider.radius = mBeginExplosionRadius;
	}

	void Update()
	{
		HandleAttributes();
		HandleExplosionEnded();
		HandleGrowingExplosion(Time.deltaTime);
		//		HandleErasingFlame(flameEnding, actualFlameSize);
	}

	protected void HandleAttributes()
	{
		if(mBomb.ExplosionStarted)
		{
			mExplosionEnded = Time.time > mBomb.ExplosionEndTime;
			mExplosionSize = mBomb.mExplosionSizeFactor * (mBlockWidthDepthDimension / 2f);
			mExplosionSize = Mathf.Clamp(mExplosionSize, mMinExplosionRadiusSize, mExplosionSize);
		}
	}

	protected void HandleGrowingExplosion(float deltaTime)
	{
		if(!mExplosionEnded && mActualExplosionSize < mExplosionSize)
		{
			float endRadius = mBomb.mExplosionSizeFactor * (mBlockWidthDepthDimension / 2f); 
			float growRadius = Mathf.SmoothDamp(mCollider.radius, endRadius, ref mExplosionGrowSpeed,
					mBomb.mExplosionDuration * mExplosionSize * mExplosionGrowSpeed);
			
			growRadius = Mathf.Clamp(growRadius, mMinExplosionRadiusSize, mExplosionSize) + mBeginExplosionRadius;
			mCollider.radius = growRadius;
		}
	}

//	protected void HandleErasingFlame(bool flameEnding, float actualFlameSize)
//	{
//		if(flameEnding && !mExplosionOff)
//		{
//			transform.localScale -= mAbsFlameDirection / 10f;
//			transform.position += mAbsFlameDirection / 10f;
//		}
//	}

	protected void HandleExplosionEnded()
	{
		if(mExplosionEnded)
			mCollider.enabled = false;
	}

	public float mExplosionGrowSpeed = 1f;

	public float mBeginExplosionRadius = 0.5f;

	protected Bomb mBomb;

	protected SphereCollider mCollider;

	protected bool mExplosionEnded;

	protected float mMinExplosionRadiusSize = 2f;
	protected float mMaxExplosionRadiusSize = 15f;

	protected float mExplosionSize;
	protected float mActualExplosionSize;
	protected float mBlockWidthDepthDimension;
}

