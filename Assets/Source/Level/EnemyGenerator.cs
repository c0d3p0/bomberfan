using System.Collections;
using UnityEngine;

public class EnemyGenerator : PrefabInstantiateDataGenerator
{	
	protected override void HandleAttributes()
	{
		base.HandleAttributes();
		mPrefabInstantiateData = mLevelData.mEnemiesToGenerateData;
	}

	protected override void HandlePrefabInstantiation(int prefabIndex, Vector3 position) 
	{
		GameObject enemyGameObject = Instantiate(mPrefabInstantiateData[prefabIndex].mPrefab, position, Quaternion.identity);
		mLevelData.mActiveEnemies.Add(enemyGameObject);
	}
}

