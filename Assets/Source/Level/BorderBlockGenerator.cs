using UnityEngine;
using System.Collections;
using System;

public class BorderBlockGenerator : MonoBehaviour
{
	void Start()
	{
		LevelData levelData = gameObject.transform.parent.GetComponentInChildren<LevelData>();
			
		mCorridorQuantityX = levelData.mCorridorAmountX;
		mCorridorQuantityZ = levelData.mCorridorAmountZ;
		mBorderStartPointX = levelData.mBorderStartPointX - mMarginX;
		mBorderStartPointZ = levelData.mBorderStartPointZ + mMarginZ;
		mBorderEndPointX = levelData.BorderEndPointX + mMarginX;
		mBorderEndPointZ = levelData.BorderEndPointZ - mMarginZ;
		mBorderBlock = levelData.mBorderBlock;

		Transform blockModelTransform = mBorderBlock.transform.Find(GameObjectName.MODEL_3D);

		mBlockWidth = blockModelTransform.transform.localScale.x;
		mBlockDepth = blockModelTransform.transform.localScale.z;

		createHorizontalBlocks();
		createVerticalBlocks();
	}

	private void createHorizontalBlocks()
	{
		// Border has 2 more blocks than the corridors
		int blockQuantityX = mCorridorQuantityX + 2;

		// Start position of border
		float locationX = mBorderStartPointX;

		for (int x = 0; x < blockQuantityX; x++)
		{
			Vector3 blockStartPosition = new Vector3(locationX, mBlockPositionY, mBorderStartPointZ);
			Vector3 blockEndPosition = new Vector3(locationX, mBlockPositionY, mBorderEndPointZ);

			Instantiate(mBorderBlock, blockStartPosition, Quaternion.identity);
			Instantiate(mBorderBlock, blockEndPosition, Quaternion.identity);

//			GameObject borderBlockTop = Instantiate(mBorderBlock, blockStartPosition, Quaternion.identity);
//			GameObject borderBlockBottom = Instantiate(mBorderBlock, blockEndPosition, Quaternion.identity);
//
//			borderBlockTop.transform.parent = transform;
//			borderBlockBottom.transform.parent = transform;

			locationX += mBlockWidth;
		}
	}

	private void createVerticalBlocks ()
	{
		// Border has 2 more blocks than the corridors
		int blockQuantityZ = mCorridorQuantityZ + 2;

		// Start position of border
		float locationZ = mBorderStartPointZ;

		for (int z = 0; z < blockQuantityZ; z++)
		{
			Vector3 blockStartPosition = new Vector3(mBorderStartPointX, mBlockPositionY, locationZ);
			Vector3 blockEndPosition = new Vector3(mBorderEndPointX, mBlockPositionY, locationZ);

			Instantiate(mBorderBlock, blockStartPosition, Quaternion.identity);
			Instantiate(mBorderBlock, blockEndPosition, Quaternion.identity);

//			GameObject borderBlockLeft = Instantiate(mBorderBlock, blockStartPosition, Quaternion.identity);
//			GameObject borderBlockRight = Instantiate(mBorderBlock, blockEndPosition, Quaternion.identity);
//
//			borderBlockLeft.transform.parent = transform;
//			borderBlockRight.transform.parent = transform;

			locationZ -= mBlockDepth;
		}
	}

	public float mMarginX, mMarginZ;
	public float mBlockPositionY;
	
	protected GameObject mBorderBlock;
	
	protected int mCorridorQuantityX, mCorridorQuantityZ;
	protected float mBorderStartPointX, mBorderStartPointZ;
	protected float mBorderEndPointX, mBorderEndPointZ;
	
	protected float mBlockWidth;
	protected float mBlockDepth;
}
