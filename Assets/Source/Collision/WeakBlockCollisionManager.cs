using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakBlockCollisionManager : BaseHitBoxCollisionManager
{
	void Update()
	{
		HandleDestructionEffect();
		HandleDestruction();
	}

	protected override void HandleCollision()
	{
		if(mCollider != null)
		{
			if(LayerMaskUtil.ContainsLayer(mCollisionMask, mCollider.gameObject.layer))
			{
				mDestructionActivated = true;
				mCollisionEnabled = false;
			}
		}
		else
			CleanCollision();
	}

	protected void HandleDestructionEffect()
	{
		if(!mDestructionStarted && mDestructionActivated)
		{
			Transform root = transform.root;

			for(int i = 0; i < root.childCount; i++)
			{
				Transform childTransform = root.GetChild(i);

				if(childTransform.tag.Equals(TagName.MODEL_3D_FRAGMENTS))
				{
					childTransform.gameObject.SetActive(true);
					continue;
				}

				if(childTransform.tag.Equals(TagName.HIT_BOX))
				{
					childTransform.gameObject.SetActive(true);
					continue;
				}

				childTransform.gameObject.SetActive(false);

				mDestructionStarted = true;
				mDestructionEndTime = Time.time + mDestructionDuration;
			}
		}
	}

	protected virtual void HandleDestruction()
	{
		if(mDestructionActivated && Time.time > mDestructionEndTime)
			Destroy(gameObject.transform.root.gameObject);
	}
		
	public float mDestructionDuration = 1f;

	protected float mDestructionEndTime;
	protected bool mDestructionActivated;

	protected bool mDestructionStarted;
}
