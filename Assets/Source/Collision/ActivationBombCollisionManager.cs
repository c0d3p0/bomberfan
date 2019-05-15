using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationBombCollisionManager : BaseHitBoxCollisionManager
{
	void Start()
	{
		mBomb = GetComponentInParent<ActivationBomb>();
	}

//	void OnTriggerEnter(Collider collider)
//	{
//		HandleTriggerCollision(collider);
//	}

	protected override void HandleCollision()
	{
		if(mBomb.Activated)
		{
			if(LayerMaskUtil.ContainsLayer(mCollisionMask, mCollider.gameObject.layer))
				mBomb.mDetonationActivated = true;
		}
	}

//	protected void HandleTriggerCollision(Collider collider)
//	{
//		if(mBomb.Activated)
//		{
//			if(LayerMaskUtil.ContainsLayer(mCollisionMask, collider.gameObject.layer))
//				mBomb.mDetonationActivated = true;
//		}
//	}
		
	protected ActivationBomb mBomb;
}
