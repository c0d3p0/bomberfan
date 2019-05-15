using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHitBoxCollisionManager : MonoBehaviour
{
	void LateUpdate()
	{
		CheckAndHandleCollision();
	}

	protected void OnTriggerEnter(Collider collider)
	{
		AddCollision(collider);
	}

	public void AddCollision(Collider collider)
	{
		if(LayerMaskUtil.ContainsLayer(mCollisionMask, collider.gameObject.layer))
		{
//			if(mCollisionEnabled && collider != null && mStrikeBoxCollider == null)
			if(!mHasCollision && mCollisionEnabled)
			{
				mHasCollision = true;
				mCollider = collider;
//				mCollisionEnabled = false;
			}
		}
	}

	protected void CheckAndHandleCollision()
	{		
//		if(mHasCollision && mCollisionEnabled)
		if(mHasCollision && mCollisionEnabled)
		{
			HandleCollision();
			CleanCollision();

//			mCollisionEnabled = true;
		}
	}

	protected void CleanCollision()
	{
		mHasCollision = false;
		mCollider = null;
	}

	public LayerMask mCollisionMask;

	protected abstract void HandleCollision();

	protected Collider mCollider;

	protected bool mCollisionEnabled = true;
	protected bool mHasCollision;
}
