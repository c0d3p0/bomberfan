using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayExplosion : MonoBehaviour
{
	void Start()
	{
		LevelData levelData = GameObject.FindGameObjectWithTag(TagName.LEVEL_MANAGER).GetComponentInChildren<LevelData>();

		mBomb = GetComponentInParent<Bomb>();
		mCollider = GetComponent<BoxCollider>();
		mCollider.enabled = true;
		mAbsExplosionDirection = Vector3.Scale(mExplosionDirection, mExplosionDirection);
		mBlockWidthDepthDimension = levelData.mBlockWidthDepthDimension;
		mSmallerBlockSize = levelData.mSmallerBlockSize;
		mCollider.size = mBeginExplosionSize;

		if(mExplosionDirection.x != 0)
			mMaxExplosionSize = (mBomb.mExplosionSizeFactor * mBlockWidthDepthDimension) + mCollider.size.x;

		if(mExplosionDirection.z != 0)
			mMaxExplosionSize = (mBomb.mExplosionSizeFactor * mBlockWidthDepthDimension) + mCollider.size.z;

		mCanGrow = true;
	}

	void Update()
	{
		HandleAttributes();
		HandleGrowingExplosion(Time.deltaTime);
//		HandleExplosionEnded();
//		HandleErasingFlame(flameEnding, actualFlameSize);
	}

	protected void HandleAttributes()
	{
		if(mExplosionDirection.x != 0)
			mActualExplosionSize = mCollider.size.x;

		if(mExplosionDirection.z != 0)
			mActualExplosionSize = mCollider.size.z;
	}

	protected void HandleGrowingExplosion(float deltaTime)
	{
//		if(!mExplosionEnded && (mActualExplosionSize < mMaxExplosionSize) && !CollidesWithExplosionBlockerObject())
		if(!mExplosionEnded && (mActualExplosionSize < mMaxExplosionSize) && mCanGrow)
		{
			if(mExplosionDirection.x != 0)
			{
				float endSizeX = mBeginExplosionSize.x + (mBomb.mExplosionSizeFactor * mBlockWidthDepthDimension); 
				float smoothTime = mBomb.mExplosionDuration * mMaxExplosionSize * (mExplosionGrowInterval / 1000f);
				float growX = Mathf.SmoothDamp(mCollider.size.x, endSizeX, ref mExplosionGrowInterval, smoothTime);

				if(GetCollisionPointOfGrowFactor(growX, ref mBlockExplosionCollisionPoint))
				{
					growX = transform.root.position.x - (mExplosionDirection.x * mBeginExplosionSize.x / 2f) - mBlockExplosionCollisionPoint.x;
					growX = Mathf.Abs(growX) + mExplosionCollisionExtraSize;
					mCanGrow = false;
				}

				if(growX > mMaxExplosionSize)
				{
					growX = mMaxExplosionSize;
					mCanGrow = false;
				}

				float positionX = (growX - mBeginExplosionSize.x) / 2f * mExplosionDirection.x;
//				float positionX = transform.root.position + (growX / 2f * mExplosionDirection.x;
				mCollider.size = new Vector3(growX, mBeginExplosionSize.y, mBeginExplosionSize.z);
				transform.localPosition = new Vector3(positionX, transform.localPosition.y, transform.localPosition.z);
			}

			if(mExplosionDirection.z != 0)
			{
				float endSizeZ = mBeginExplosionSize.z + (mBomb.mExplosionSizeFactor * mBlockWidthDepthDimension);
				float smoothTime = mBomb.mExplosionDuration * mMaxExplosionSize * (mExplosionGrowInterval / 1000f);
				float growZ = Mathf.SmoothDamp(mCollider.size.z, endSizeZ, ref mExplosionGrowInterval, smoothTime);

				if(GetCollisionPointOfGrowFactor(growZ, ref mBlockExplosionCollisionPoint))
				{
					growZ = transform.root.position.z - (mExplosionDirection.z * mBeginExplosionSize.z / 2f) - mBlockExplosionCollisionPoint.z;
					growZ = Mathf.Abs(growZ) + mExplosionCollisionExtraSize;
					mCanGrow = false;
				}

				if(growZ > mMaxExplosionSize)
				{
					growZ = mMaxExplosionSize;
					mCanGrow = false;
				}

				float positionZ = (growZ - mBeginExplosionSize.z) / 2f * mExplosionDirection.z;

				mCollider.size = new Vector3(mBeginExplosionSize.x, mBeginExplosionSize.y, growZ);
				transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, positionZ);
			}
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

	protected bool GetCollisionPointOfGrowFactor(float growFactor, ref Vector3 collisionPoint)
	{
//		Vector3 startPosition = transform.position;
//		startPosition.x += (mExplosionDirection.x * growFactor);
//		startPosition.y = mSmallerBlockSize / 2f;
//		startPosition.z = (mExplosionDirection.z * growFactor);

//		float rayDistance = 0.1f;

		// Calculates the distance ray have to travel
//		if(mExplosionDirection.x != 0)
//			rayDistance = (mCollider.size.x - (mBeginExplosionSize.x / 2f));

		// Calculates the distance ray have to travel
//		if(mExplosionDirection.z != 0)
//			rayDistance = (mCollider.size.z - (mBeginExplosionSize.z / 2f));
//		return Physics.Raycast(startPosition, mExplosionDirection, rayDistance, mBlockExplosionLayerMask);

		Vector3 startPosition = transform.position;
		startPosition.y = mSmallerBlockSize / 2f;
		RaycastHit[] raycastHits = Physics.RaycastAll(startPosition, mExplosionDirection, growFactor + 0.1f, mBlockExplosionLayerMask);

		if(raycastHits.Length > 0)
		{
			collisionPoint = raycastHits[0].point;
			return true;
		}
		else
			return false;
	}

	protected bool CollidesWithExplosionBlockerObject(float hitBoxWidthOrDepth)
	{
		Vector3 startPosition = transform.position;
		startPosition.x += (mExplosionDirection.x * hitBoxWidthOrDepth);
		startPosition.y = mSmallerBlockSize / 2f;
		startPosition.z = (mExplosionDirection.z * hitBoxWidthOrDepth);

//		float rayDistance = 0.1f;

		// Calculates the distance ray have to travel
//		if(mExplosionDirection.x != 0)
//			rayDistance = (mCollider.size.x - (mBeginExplosionSize.x / 2f));

		// Calculates the distance ray have to travel
//		if(mExplosionDirection.z != 0)
//			rayDistance = (mCollider.size.z - (mBeginExplosionSize.z / 2f));

		return Physics.Raycast(transform.position, mExplosionDirection, hitBoxWidthOrDepth + 0.1f, mBlockExplosionLayerMask);
//		return Physics.Raycast(startPosition, mExplosionDirection, rayDistance, mBlockExplosionLayerMask);
	}

	public LayerMask mBlockExplosionLayerMask;

	public Vector3 mExplosionDirection;
	public Vector3 mBeginExplosionSize = new Vector3(1.8f, 4f, 1.8f);

	public float mExplosionGrowInterval = 2f;
	public float mExplosionCollisionExtraSize = 0.02f;

	protected Bomb mBomb;
	protected BoxCollider mCollider;
	protected Vector3 mAbsExplosionDirection;
	protected Vector3 mBlockExplosionCollisionPoint;

	protected bool mExplosionEnded;
	protected bool mCanGrow;

	protected float mMaxExplosionSize;
	protected float mActualExplosionSize;
	protected float mSmallerBlockSize;
	protected float mBlockWidthDepthDimension;
}
