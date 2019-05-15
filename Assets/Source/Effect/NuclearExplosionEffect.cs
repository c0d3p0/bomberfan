using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearExplosionEffect : MonoBehaviour
{
	void Start () 
	{
		mBomb = GetComponentInParent<Bomb>();
		mParticleSystem = GetComponent<ParticleSystem>();
	}

	void Update()
	{
		HandleEffect();
	}

	protected void HandleEffect()
	{
		if(mBomb.ExplosionStarted && mInitEffect)
		{
			float explosionSizeFactor = mBomb.mMBOwner.GetComponentInParent<MadBomberData>().ExplosionSizeFactor;

			var mainModule = mParticleSystem.main;
			mainModule.startSize = mStartSize * explosionSizeFactor;

			var shapeModule = mParticleSystem.shape;
			shapeModule.radius = explosionSizeFactor;

			mInitEffect = false;
		}
	}

	public float mStartSize = 7f;

	protected Bomb mBomb;
	protected ParticleSystem mParticleSystem;

//	protected float mExplosionSizeFactor;
	protected bool mInitEffect = true;
}
