using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxCollisionHandler : BaseHitBoxCollisionManager
{
	protected void Start()
	{
		mHitTakenController = GetComponentInParent<PlayerHitTakenController>();
	}
		
	protected override void HandleCollision()
	{
		if(mCollider != null)
		{
			if(LayerMaskUtil.ContainsLayer(mCollisionMask, mCollider.gameObject.layer))
				mHitTakenController.ApplyHit();
		}
	}

	protected PlayerHitTakenController mHitTakenController;
}
