using UnityEngine;
using System.Collections;

public class BombAmountItemCollision : BaseItemCollision
{
	protected override void HandleCollected(Collider collider)
	{
		MadBomberData madBomberData = collider.GetComponentInParent<MadBomberData>();
		madBomberData.BombAmount++;
		Destroy(gameObject.transform.root.gameObject);
	}
}
