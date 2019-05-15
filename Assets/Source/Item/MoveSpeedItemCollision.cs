using UnityEngine;
using System.Collections;

public class MoveSpeedItemCollision : BaseItemCollision
{
	protected override void HandleCollected(Collider collider)
	{
		MadBomberData madBomberData = collider.GetComponentInParent<MadBomberData>();
		madBomberData.MoveSpeedFactor++;
		Destroy(gameObject.transform.root.gameObject);
	}
}
