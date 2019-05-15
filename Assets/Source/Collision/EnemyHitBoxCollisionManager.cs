using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBoxCollisionManager : BaseHitBoxCollisionManager
{
	protected void Start()
	{
		mHitTakenController = GetComponentInParent<EnemyHitTakenController>();
	}

	protected override void HandleCollision()
	{
		if(mCollider != null)
		{
			if(LayerMaskUtil.ContainsLayer(mCollisionMask, mCollider.gameObject.layer))
				mHitTakenController.ApplyHit();
		}
	}

	protected EnemyHitTakenController mHitTakenController;
}
