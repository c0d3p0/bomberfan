using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Try to fill the character specific spaces dynamically
public class LevelData : MonoBehaviour
{
	// Use this for initialization
	void Awake()
	{
		HandleAttributes();
		InitUsedSpacesMatrix();
		FillCharacterFakeUsedSpaces();
	}

	protected void Update()
	{
		mActiveEnemies.RemoveAll(item => item == null);
	}

	protected void HandleAttributes()
	{
		mBorderEndPointX = mBorderStartPointX + ((mCorridorAmountX + 1f) * mBlockWidthDepthDimension);
		mBorderEndPointZ = mBorderStartPointZ - ((mCorridorAmountZ + 1f) * mBlockWidthDepthDimension);

		mLevelBoundary = new Boundary();
		mLevelBoundary.mXMin = mBorderStartPointX + mWeakBlock.transform.localScale.x;
		mLevelBoundary.mXMax = (mCorridorAmountX * mWeakBlock.transform.localScale.x) + mBorderStartPointX;

		mLevelBoundary.mZMin = -(mCorridorAmountZ * mWeakBlock.transform.localScale.z) + mBorderStartPointZ;
		mLevelBoundary.mZMax = mBorderStartPointZ - mWeakBlock.transform.localScale.z;

		mActiveEnemies = new List<GameObject>();
	}
		
	protected void InitUsedSpacesMatrix()
	{
		mUsedSpaces = new bool[mCorridorAmountX, mCorridorAmountZ];

		for(int x = 0; x < mCorridorAmountX; x++)
		{
			bool oddX = x % 2 == 1;

			// Hard blocks are generated where both axis have odd values.
			for(int z = 0; z < mCorridorAmountZ; z++)
			{
				bool oddZ = z % 2 == 1;

				if(oddX && oddZ)
					mUsedSpaces[x, z] = true;
			}
		}
	}

	// It makes at least an L of blank spaces in each corner of level,
	// to make player don't stuck in own bomb and die on it.
	protected void FillCharacterFakeUsedSpaces()
	{
		mUsedSpaces[0, 0] = true;
		mUsedSpaces[0, 1] = true;
		mUsedSpaces[1, 0] = true;

		mUsedSpaces[mCorridorAmountX - 1, 0] = true;
		mUsedSpaces[mCorridorAmountX - 2, 0] = true;
		mUsedSpaces[mCorridorAmountX - 1, 1] = true;

		mUsedSpaces[0, mCorridorAmountZ - 1] = true;
		mUsedSpaces[0, mCorridorAmountZ - 2] = true;
		mUsedSpaces[1, mCorridorAmountZ - 1] = true;

		mUsedSpaces[mCorridorAmountX - 1, mCorridorAmountZ - 1] = true;
		mUsedSpaces[mCorridorAmountX - 2, mCorridorAmountZ - 1] = true;
		mUsedSpaces[mCorridorAmountX - 1, mCorridorAmountZ - 2] = true;
	}

	public GameObject GetBombGameObject(BombType bombType, ExplosionType explosionType)
	{
		if(bombType == BombType.TIMER_BOMB)
		{
			if(explosionType == ExplosionType.STANDARD)
				return mBombs[0];

			if(explosionType == ExplosionType.ENHANCED)
				return mBombs[1];

			if(explosionType == ExplosionType.NUCLEAR)
				return mBombs[2];

			return mBombs[0];
		}

		if(bombType == BombType.AIMLESS_BOMB)
		{
			if(explosionType == ExplosionType.STANDARD)
				return mBombs[3];

			if(explosionType == ExplosionType.ENHANCED)
				return mBombs[4];

			if(explosionType == ExplosionType.NUCLEAR)
				return mBombs[5];

			return mBombs[3];
		}

		if(bombType == BombType.MINE_BOMB)
		{
			if(explosionType == ExplosionType.STANDARD)
				return mBombs[6];

			if(explosionType == ExplosionType.ENHANCED)
				return mBombs[7];

			if(explosionType == ExplosionType.NUCLEAR)
				return mBombs[8];

			return mBombs[6];
		}

		if(bombType == BombType.EXPLOSIVE_BOMB)
		{
			if(explosionType == ExplosionType.STANDARD)
				return mBombs[9];

			if(explosionType == ExplosionType.ENHANCED)
				return mBombs[10];

			if(explosionType == ExplosionType.NUCLEAR)
				return mBombs[11];

			return mBombs[9];
		}

		return mBombs[0];
	}

	public bool[, ] UsedSpaces
	{
		get
		{
			return mUsedSpaces;
		}
	}

	public float BorderEndPointX
	{
		get
		{
			return mBorderEndPointX;
		}
	}

	public float BorderEndPointZ
	{
		get
		{
			return mBorderEndPointZ;
		}
	}

	public Boundary LevelBoundary
	{
		get
		{
			return mLevelBoundary;
		}
	}

	public GameObject mBorderBlock;
	public GameObject mHardBlock;
	public GameObject mWeakBlock;
	public GameObject mItemWeakBlock;

	public GameObject[] mBombs;
	public PrefabInstantiateData[] mItemsToGenerateData;
	public PrefabInstantiateData[] mEnemiesToGenerateData;
	public PrefabInstantiateData[] mExitAreas;

	public int mCorridorAmountX = 21;
	public int mCorridorAmountZ = 15;
	public int mQuadrantAmount = 4;
	
	public float mBlockWidthDepthDimension = 2f;
	public float mSmallerBlockSize = 1f;

	public float mBorderStartPointX = -2f;
	public float mBorderStartPointZ = 2f;
	public float mWeakBlockAmountPercentage = 0.40f;
	
	[HideInInspector]
	public List<GameObject> mActiveEnemies;

	protected Boundary mLevelBoundary;
	protected bool[, ] mUsedSpaces;
	protected float mBorderEndPointX;
	protected float mBorderEndPointZ;
}
