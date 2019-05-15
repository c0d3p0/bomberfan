using UnityEngine;
using System.Collections;

public class ExplosionSizeItemCollision : BaseItemCollision
{
	protected override void HandleCollected(Collider collider)
	{
		MadBomberData madBomberData = collider.GetComponentInParent<MadBomberData>();
		madBomberData.ExplosionSizeFactor++;
		Destroy(gameObject.transform.parent.gameObject);
	}
}
