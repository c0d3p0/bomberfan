using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAmountItemCollision : BaseItemCollision
{
	protected override void HandleCollected(Collider collider)
	{
		PlayerManager playerManager = collider.GetComponentInParent<PlayerManager>();
		playerManager.mLifeAmount++;
		Destroy(gameObject.transform.root.gameObject);
	}
}
