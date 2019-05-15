using System.Collections;
using UnityEngine;

public class PrefabInstantiateDataGenerator : MonoBehaviour
{
	protected virtual void Start()
	{
		HandleAttributes();
		HandlePrefabInstantiation();
	}

	protected virtual void HandleAttributes()
	{
		mLevelData = transform.root.GetComponent<LevelData>();
		mUsedSpaces = mLevelData.UsedSpaces;
	}

	protected void HandlePrefabInstantiation()
	{
		int factorX = Mathf.CeilToInt(mLevelData.mCorridorAmountX / Mathf.Sqrt(mLevelData.mQuadrantAmount));
		int factorZ = Mathf.CeilToInt(mLevelData.mCorridorAmountZ / Mathf.Sqrt(mLevelData.mQuadrantAmount));

		int actualQuadrant = Random.Range(0, mLevelData.mQuadrantAmount);

		for(int i = 0; i < mPrefabInstantiateData.Length; i++)
		{
			for(int j = 0; j < mPrefabInstantiateData[i].mInstantiationAmount; j++)
			{
				CreateDefaultQuadrant(i, actualQuadrant, factorX, factorZ);
				actualQuadrant++;

				if(actualQuadrant >= mLevelData.mQuadrantAmount)
					actualQuadrant = 0;
			}
		}
	}

	protected void CreateDefaultQuadrant(int prefabIndex, int quadrantIndex, int factorX, int factorZ)
	{
		int sqrtQuadrantQuantity = Mathf.RoundToInt(Mathf.Sqrt(mLevelData.mQuadrantAmount));
		int startIndexX = (factorX - 1) * (quadrantIndex % sqrtQuadrantQuantity);
		int startIndexZ = (factorZ - 1) * (quadrantIndex / sqrtQuadrantQuantity);

		int finalIndexX = startIndexX + (factorX - 1);
		int finalIndexZ = startIndexZ + (factorZ - 1);


//		System.Random rnd = new System.Random();
		int indexX;
		int indexZ;

		do
		{
//			indexX = rnd.Next(startIndexX, finalIndexX + 1); // TODO: Change to unity Random.Range
//			indexZ = rnd.Next(startIndexZ, finalIndexZ + 1); // TODO: Change to unity Random.Range

			indexX = Random.Range(startIndexX, finalIndexX + 1);
			indexZ = Random.Range(startIndexZ, finalIndexZ + 1);
		}
		while(mUsedSpaces[indexX, indexZ]);

		Vector3 position = new Vector3(indexX * mLevelData.mBlockWidthDepthDimension, mPrefabPositionY, -indexZ * mLevelData.mBlockWidthDepthDimension);
		HandlePrefabInstantiation(prefabIndex, position);
		mUsedSpaces[indexX, indexZ] = true;
	}

	protected virtual void HandlePrefabInstantiation(int prefabIndex, Vector3 position) {}

	public float mPrefabPositionY;

	protected LevelData mLevelData;
	protected PrefabInstantiateData[] mPrefabInstantiateData;

	protected bool[, ] mUsedSpaces;
}
