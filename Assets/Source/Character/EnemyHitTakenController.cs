using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitTakenController : MonoBehaviour
{
	protected void Start()
	{
		mHitBoxCollider = GameObjectUtil.FindChildTransformByTag(transform, TagName.HIT_BOX).GetComponent<Collider>();
		mStrikeBoxCollider = GameObjectUtil.FindChildTransformByTag(transform, TagName.STRIKE_BOX).GetComponent<Collider>();
		mController = GetComponent<BaseController>();
		mEnemyData = GetComponent<EnemyData>();
	}

	protected void Update()
	{
		HandleAttributes();
		HandleApplyHit();
		HandleDestroyAfterDeath();
	}

	public void ApplyHit()
	{
		if(!mInvincible)
			mApplyHit = true;
	}

	public void ApplyInvincibility()
	{
		mInvincibleEndTime = Time.time + mInvincibleDuration;
		mInvincible = true;
		mHitBoxCollider.enabled = false;
	}

	protected void HandleAttributes()
	{
		if(Time.time > mPersistFlagEndTime)
			mDamage = false;

		if(Time.time > mHitTakenEndTime && !mEnemyData.IsDead())
			mController.mCanExecuteActions = true;

		if(Time.time > mInvincibleEndTime && !mEnemyData.IsDead())
		{
			mHitBoxCollider.enabled = true;
			mInvincible = false;
		}
	}

	public void HandleApplyHit()
	{
		if(mInvincible)
			mApplyHit = false;
		
		if(mApplyHit)
		{
			mEnemyData.HealthAmount--;
			mApplyHit = false;

			if(mEnemyData.IsDead())
				HandleDeath();
			else
			{
				HandleDamage();
				ApplyInvincibility();
			}
		}
	}

	protected void HandleDamage()
	{
		mPersistFlagEndTime = Time.time + mPersistFlagDuration;
		mHitTakenEndTime = Time.time + mDamageDuration;
		mDamage = true;
		mController.mCanExecuteActions = false;
	}

	protected void HandleDeath()
	{
		mPersistFlagEndTime = Time.time + mPersistFlagDuration;
		mHitTakenEndTime = Time.time + mDeathDuration;
		mDead = true;
		mStrikeBoxCollider.enabled = false;
		mController.mCanExecuteActions = false;
		mHitBoxCollider.enabled = false;
	}
		
	protected void HandleDestroyAfterDeath()
	{
		if(Time.time > mHitTakenEndTime && mEnemyData.IsDead())
			Destroy(transform.root.gameObject);
	}

	public float mPersistFlagDuration = 0.5f;
	public float mDamageDuration = 1f;
	public float mDeathDuration = 3f;
	public float mInvincibleDuration = 1f;

	protected EnemyData mEnemyData;
	protected BaseController mController;
	protected Collider mHitBoxCollider;
	protected Collider mStrikeBoxCollider;

	protected float mHitTakenEndTime, mPersistFlagEndTime, mInvincibleEndTime;

	[HideInInspector]
	public bool mDamage, mDead, mInvincible;

	protected bool mApplyHit;
}
