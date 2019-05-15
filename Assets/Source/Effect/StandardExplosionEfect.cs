using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardExplosionEfect : MonoBehaviour
{
	void Start () 
	{
		mBomb = GetComponentInParent<Bomb>();
		mParticleSystem = GetComponent<ParticleSystem>();

		Transform strikeBoxTransform = GameObjectUtil.FindChildTransformByTag(transform.root, TagName.STRIKE_BOX);
		mBoxCollider = GameObjectUtil.FindChildTransformByTag(strikeBoxTransform, mStrikeBoxTag).GetComponent<BoxCollider>();
	}

	void Update()
	{
		HandleEffect();
	}

	protected void HandleEffect()
	{
		if(mBomb.ExplosionStarted)
		{
//			mExplosionSizeFactor = mBomb.mMBOwner.GetComponentInParent<MadBomberData>().ExplosionSizeFactor;
//
//			var mainModule = mParticleSystem.main;
//			mainModule.startSize = mStartSize * mExplosionSizeFactor;

			var shapeModule = mParticleSystem.shape;
			shapeModule.box = mBoxCollider.size;
		}
	}

	public string mStrikeBoxTag;
//	public float mStartSize = 2f;
	protected BoxCollider mBoxCollider;

	protected Bomb mBomb;
	protected ParticleSystem mParticleSystem;

	protected bool mInitEffect = true;
}
