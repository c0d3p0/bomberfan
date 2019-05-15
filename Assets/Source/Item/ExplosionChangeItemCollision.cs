using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionChangeItemCollision : BaseItemCollision
{
	protected override void HandleCollected(Collider collider)
	{
		MadBomberData madBomberData = collider.GetComponentInParent<MadBomberData>();
		Bomb actualBomb = madBomberData.mBombSlots[1].GetComponent<Bomb>();
		LevelData levelData = GameObject.FindGameObjectWithTag(TagName.LEVEL_MANAGER).GetComponent<LevelData>();
		GameObject newBombGameObject = levelData.GetBombGameObject(actualBomb.mBombType, mExplosionType);
		madBomberData.mBombSlots[1] = newBombGameObject;
		Destroy(gameObject.transform.root.gameObject);
	}

	public ExplosionType mExplosionType;
}
