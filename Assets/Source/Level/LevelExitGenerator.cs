using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExitGenerator : PrefabInstantiateDataGenerator
{
	protected override void Start()
	{
		HandleAttributes();
	}

	protected override void HandleAttributes()
	{
		base.HandleAttributes();
		mPrefabInstantiateData = mLevelData.mExitAreas;
	}

	protected void Update()
	{
		if(!mExitGenerated)
		{
			if(mLevelData.mActiveEnemies.Count <= 0)
			{
				HandlePrefabInstantiation();
				mExitGenerated = true;
			}
		}
	}

	protected override void HandlePrefabInstantiation(int prefabIndex, Vector3 position) 
	{
//		GameObject exitAreaGameObject = Instantiate(mPrefabInstantiateData[prefabIndex].mPrefab, position, Quaternion.identity, transform);
		Instantiate(mPrefabInstantiateData[prefabIndex].mPrefab, position, Quaternion.identity, transform);
	}

//	void Start()
//	{
//		mLevelData = GetComponentInParent<LevelData>();
//		mUsedSpaces = mLevelData.UsedSpaces;
//	}
//
//	void Update ()
//	{
//		if(!mExitGenerated)
//		{
//			if(mLevelData.mActiveEnemies.Count <= 0)
//			{
//				int indexX;
//				int indexZ;
//
//				do
//				{
//					indexX = Random.Range(0, mLevelData.mCorridorAmountZ);
//					indexZ = Random.Range(0, mLevelData.mCorridorAmountX);
//				}
//				while(!mUsedSpaces[indexX, indexZ]);
//
//				Vector3 position = new Vector3(indexX * mLevelData.mBlockWidthDepthDimension, mExitAreaPositionY, 
//						-indexZ * mLevelData.mBlockWidthDepthDimension);
//				
//				GameObject exitAreaGameObject = Instantiate(mExitArea, position, Quaternion.identity);
//				exitAreaGameObject.transform.parent = transform;
//
//				mExitGenerated = true;
//			}
//		}
//	}

//	public GameObject mExitArea;
//	public float mExitAreaPositionY = 0f;

//	protected LevelData mLevelData;
//	protected bool[, ] mUsedSpaces;
	protected bool mExitGenerated;
}
