using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeakBlockGenerator : PrefabInstantiateDataGenerator
{
	protected override void HandleAttributes()
	{
		base.HandleAttributes();
		mPrefabInstantiateData = mLevelData.mItemsToGenerateData;
	}

	protected override void HandlePrefabInstantiation(int prefabIndex, Vector3 position) 
	{
		GameObject itemWeakBlock = Instantiate(mLevelData.mItemWeakBlock, position, Quaternion.identity);
		itemWeakBlock.GetComponentInChildren<ItemWeakBlockCollisionManager>().mItemGameObject = mPrefabInstantiateData[prefabIndex].mPrefab;
//		itemWeakBlock.transform.parent = transform;
	}
}
