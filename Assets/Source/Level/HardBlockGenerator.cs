using UnityEngine;
using System.Collections;
using System;

public class HardBlockGenerator : MonoBehaviour
{
	public float mBlockPositionY;

	protected GameObject mHardBlock;
	protected int mCorridorQuantityX;
	protected int mCorridorQuantityZ;
	protected float mBorderStartPointX;
	protected float mBorderStartPointZ;
	protected float mBlockWidth;
	protected float mBlockDepth;
	protected float mBlockWidthDepthDimention;

	// Use this for initialization
	void Start() 
	{
		LevelData levelData = gameObject.transform.parent.GetComponentInParent<LevelData>();

		mCorridorQuantityX = levelData.mCorridorAmountX;
		mCorridorQuantityZ = levelData.mCorridorAmountZ;
		mBorderStartPointX = levelData.mBorderStartPointX;
		mBorderStartPointZ = levelData.mBorderStartPointZ;
		mHardBlock = levelData.mHardBlock;

		Transform blockModelTransform = mHardBlock.transform.Find(GameObjectName.MODEL_3D);

		mBlockWidth = blockModelTransform.transform.localScale.x;
		mBlockDepth = blockModelTransform.transform.localScale.z;
		mBlockWidthDepthDimention = levelData.mBlockWidthDepthDimension;

		CreateHardBlocks();
	}

	protected void CreateHardBlocks()
	{
		int blockQuantityX = Mathf.FloorToInt(mCorridorQuantityX / 2f);
		int blockQuantityZ = Mathf.FloorToInt(mCorridorQuantityZ / 2f);

		float locationX = mBorderStartPointX + (2 * mBlockWidthDepthDimention);
		float locationZ;

		for(int x = 0; x < blockQuantityX; x++)
		{
			locationZ = mBorderStartPointZ - (2 * mBlockWidthDepthDimention);

			for(int z = 0; z < blockQuantityZ; z++)
			{
//				GameObject hardBlock = Instantiate(mHardBlock, new Vector3(locationX, mBlockPositionY, locationZ), Quaternion.identity);
//				hardBlock.transform.parent = transform;

				Instantiate(mHardBlock, new Vector3(locationX, mBlockPositionY, locationZ), Quaternion.identity);
				locationZ -= mBlockDepth * mBlockWidthDepthDimention;
			}

			locationX += mBlockWidth * mBlockWidthDepthDimention;
		}
	}
}