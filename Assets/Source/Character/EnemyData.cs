using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData : MonoBehaviour
{
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

	public float mMoveSpeed = 1;
	public float mMoveSpeedFactor = 1;

	[SerializeField]
	protected int mHealthAmount = 2;

	public float mDamagedFlagResetDuration = 0.5f;

	protected float mDamagedFlagResetTime;
}
