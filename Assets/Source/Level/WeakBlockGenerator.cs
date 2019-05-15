using System.Collections;
using UnityEngine;

// TODO: Try to make quadrant quantity mutable.
public class WeakBlockGenerator : MonoBehaviour
{
	void Start ()
	{
		LevelData levelData = gameObject.transform.parent.GetComponentInChildren<LevelData>();
			
		mQuadrantAmount = levelData.mQuadrantAmount;
		mItemWeakBlockAmount = levelData.mWeakBlockAmountPercentage;
		mUsedSpaces = levelData.UsedSpaces;
		mCorridorAmountX = levelData.mCorridorAmountX;
		mCorridorAmountZ = levelData.mCorridorAmountZ;
		mWeakBlock = levelData.mWeakBlock;
		mBlockWidthDepthDimention = levelData.mBlockWidthDepthDimension;
			
		CreateWeakBlocks();
	}

	protected void CreateWeakBlocks()
	{
		int factorX = Mathf.CeilToInt(mCorridorAmountX / Mathf.Sqrt(mQuadrantAmount));
		int factorZ = Mathf.CeilToInt(mCorridorAmountZ / Mathf.Sqrt(mQuadrantAmount));

		for(int x = 0; x < mQuadrantAmount; x++)
			CreateDefaultQuadrant(x, factorX, factorZ);
	}

	protected void CreateDefaultQuadrant(int quadrantIndex, int factorX, int factorZ)
	{
//		int sizeX = factorX;
//		int sizeZ = factorZ;

		int totalBlocks = Mathf.FloorToInt(factorX * factorZ * mItemWeakBlockAmount);

		int sqrtQuadrantQuantity = Mathf.RoundToInt(Mathf.Sqrt(mQuadrantAmount));
		int startIndexX = (factorX - 1) * (quadrantIndex % sqrtQuadrantQuantity);
		int startIndexZ = (factorZ - 1) * (quadrantIndex / sqrtQuadrantQuantity);

		int finalIndexX = startIndexX + (factorX - 1);
		int finalIndexZ = startIndexZ + (factorZ - 1);

		for(int x = 0; x < totalBlocks; x++)
		{
//			System.Random rnd = new System.Random();

			int indexX;
			int indexZ;

			do
			{
//				indexX = rnd.Next(startIndexX, finalIndexX + 1); // TODO: Change to unity Random.Range
//				indexZ = rnd.Next(startIndexZ, finalIndexZ + 1); // TODO: Change to unity Random.Range

				indexX = Random.Range(startIndexX, finalIndexX + 1);
				indexZ = Random.Range(startIndexZ, finalIndexZ + 1);
			}
			while(mUsedSpaces[indexX, indexZ]);

			Vector3 position = new Vector3(indexX * mBlockWidthDepthDimention, mBlockPositionY, -indexZ * mBlockWidthDepthDimention);

//			GameObject weakBlock = Instantiate(mWeakBlock, position, Quaternion.identity);
//			weakBlock.transform.parent = transform;

			Instantiate(mWeakBlock, position, Quaternion.identity);

			mUsedSpaces[indexX, indexZ] = true;
		}
	}

//	[Obsolete]
//	protected void CreateSpecialQuadrant(int factorX, int factorZ)
//	{
//		int fixedIndexX = factorX - 1;
//		int fixedIndexZ = factorZ - 1;
//
//		int totalBlocksX = Mathf.FloorToInt(mCorridorAmountX * mItemWeakBlockAmount);
//
//		for(int x = 0; x < totalBlocksX; x++)
//		{
//			System.Random rnd = new System.Random();
//
//			int indexX;
//
//			do
//			{
//				indexX = rnd.Next(0, mCorridorAmountX);
//			}
//			while(mUsedSpaces[indexX, fixedIndexZ]);
//
//			Vector3 position = new Vector3(indexX * mBlockWidthDepthDimention, mBlockPositionY, -fixedIndexZ * mBlockWidthDepthDimention);
//			Instantiate(mWeakBlock, position, Quaternion.identity);
//			mUsedSpaces[indexX, fixedIndexZ] = true;
//		}
//
//		int totalBlocksZ = Mathf.FloorToInt(mCorridorAmountZ * mItemWeakBlockAmount);
//
//		for(int z = 0; z < totalBlocksZ; z++)
//		{
//			System.Random rnd = new System.Random();
//
//			int indexZ;
//
//			do
//			{
//				indexZ = rnd.Next(0, mCorridorAmountZ);
//			}
//			while(mUsedSpaces[fixedIndexX, indexZ]);
//
//			Vector3 position = new Vector3(fixedIndexX * mBlockWidthDepthDimention, mBlockPositionY, -indexZ * mBlockWidthDepthDimention);
//			Instantiate(mWeakBlock, position, Quaternion.identity);
//			mUsedSpaces[fixedIndexX, fixedIndexZ] = true;
//		}
//	}

	public float mBlockPositionY;

	protected GameObject mWeakBlock;

	protected int mCorridorAmountX;
	protected int mCorridorAmountZ;
	protected int mQuadrantAmount;

	protected float mBlockWidthDepthDimention;
	protected float mItemWeakBlockAmount;

	protected bool[, ] mUsedSpaces;
}


