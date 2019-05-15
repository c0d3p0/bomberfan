using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitTakenController : MonoBehaviour
{
//	protected void HandleInitAttributes()
//	{
//		if(mInitAttributes)
//		{
//			mHitBoxCollider = GameObjectUtil.FindChildTransformByTag(transform, TagName.HIT_BOX).GetComponent<Collider>();
//			mController = GetComponent<BaseController>();
//			mMadBomberData = GetComponentInParent<MadBomberData>();
//			mPlayerManager = GetComponentInParent<PlayerManager>();
//			mInitAttributes = false;
//		}
//	}

	public void InitAttributes()
	{
		mHitBoxCollider = GameObjectUtil.FindChildTransformByTag(transform, TagName.HIT_BOX).GetComponent<Collider>();
		mController = GetComponent<BaseController>();
		mMadBomberData = GetComponentInParent<MadBomberData>();
		mPlayerManager = GetComponentInParent<PlayerManager>();
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
//		mHitBoxCollider.enabled = false;
	}


	protected void Update()
	{
		HandleAttributes();
		HandleApplyHit();
		HandleDestroyAfterDeath();
	}

	protected void HandleAttributes()
	{
		if(Time.time > mPersistFlagEndTime)
			mDamage = false;

		if(Time.time > mHitTakenEndTime && !mMadBomberData.IsDead())
			mController.mCanExecuteActions = true;

		if(Time.time > mInvincibleEndTime && !mMadBomberData.IsDead())
		{
			mHitBoxCollider.enabled = true;
			mInvincible = false;
		}
	}

	protected void HandleApplyHit()
	{
		if(mInvincible)
			mApplyHit = false;

		if(mApplyHit)
		{
			mMadBomberData.HealthAmount--;
			mApplyHit = false;

			if(mMadBomberData.IsDead())
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
		mController.mCanExecuteActions = false;
		mHitBoxCollider.enabled = false;
	}

	protected void HandleDestroyAfterDeath()
	{
		if(Time.time > mHitTakenEndTime && mMadBomberData.IsDead())
			mPlayerManager.ApplyLoseLife();
	}

	public float mPersistFlagDuration = 0.5f;
	public float mDamageDuration = 1f;
	public float mDeathDuration = 3f;
	public float mInvincibleDuration = 1f;

	protected PlayerManager mPlayerManager;
	protected MadBomberData mMadBomberData;
	protected BaseController mController;
	protected Collider mHitBoxCollider;

	protected float mHitTakenEndTime, mPersistFlagEndTime, mInvincibleEndTime;

	[HideInInspector]
	public bool mDamage, mDead, mInvincible;

	protected bool mApplyHit;

	protected bool mInitAttributes = true;
}
