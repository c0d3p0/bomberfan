using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollisionManager : BaseHitBoxCollisionManager
{
	void Start()
	{
		mBomb = GetComponentInParent<Bomb>();
	}

	protected override void HandleCollision()
	{
		if(LayerMaskUtil.ContainsLayer(mCollisionMask, mCollider.gameObject.layer))
			mBomb.mDetonationActivated = true;
	}

	protected void HandleTriggerCollision(Collider collider)
	{
		if(LayerMaskUtil.ContainsLayer(mCollisionMask, collider.gameObject.layer))
			mBomb.mDetonationActivated = true;
	}

	protected Bomb mBomb;
}
