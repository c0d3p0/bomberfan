using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MadBomberData : MonoBehaviour
{
	void Awake()
	{
		mActiveBombs = new List<GameObject>();
	}

	void Update()
	{
		mActiveBombs.RemoveAll(item => item == null);
	}

	public void SetToDefaultValues()
	{
		mHealthAmount = 1;

		// TODO: Code the rest here
	}

	public int MoveSpeedFactor
	{
		get
		{
			return mMoveSpeedFactor;
		}
		set
		{
			if(value <= mMaxMoveSpeedFactor)
				mMoveSpeedFactor = value;
		}
	}

	public int ExplosionSizeFactor
	{
		get
		{
			return mExplosionSizeFactor;
		}
		set
		{
			if(value <= mMaxExplosionSizeFactor)
				mExplosionSizeFactor = value;
		}
	}

	public int BombAmount
	{
		get
		{
			return mBombAmount;
		}
		set
		{
			if(value <= mMaxBombAmount)
				mBombAmount = value;
		}
	}

	public int HealthAmount
	{
		get
		{
			return mHealthAmount;
		}
		set
		{
			if(value >= 0)
				mHealthAmount = value;
		}
	}

	public bool IsDead()
	{
		return mHealthAmount <= 0;
	}

	public GameObject[] mBombSlots;

	public int mMaxMoveSpeedFactor = 9;
	public int mMaxExplosionSizeFactor = 9;
	public int mMaxBombAmount = 9;


	[HideInInspector]
	public List<GameObject> mActiveBombs;

	[HideInInspector]
	public byte mSelectedBombIndex = 0;


	[SerializeField]
	protected int mMoveSpeedFactor = 1;

	[SerializeField] 
	protected int mExplosionSizeFactor = 3;

	[SerializeField] 
	protected int mBombAmount = 1;

	[SerializeField]
	protected int mHealthAmount = 1;

//	public bool mCanKick = false;
//	public bool mCanPassBlocks = false;
//	public bool mCanPassBomb = false;
//	public bool mCanHold = false;
}
