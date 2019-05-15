using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeakBlockCollisionManager : WeakBlockCollisionManager
{
	protected override void HandleDestruction()
	{
		if(mDestructionActivated && Time.time > mDestructionEndTime)
		{
			if(mItemGameObject != null)
			{
				Vector3 itemPosition = transform.position;
				itemPosition.y = mItemPositionY;
				Instantiate(mItemGameObject,itemPosition, Quaternion.identity);
			}
			
			Destroy(gameObject.transform.root.gameObject);
		}
	}

	public float mItemPositionY = 3f;

	[HideInInspector]
	public GameObject mItemGameObject;
}
