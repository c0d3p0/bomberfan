using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItemCollision : BaseHitBoxCollisionManager 
{
	void Start()
	{
		mDestructActivationTime = Time.time + mDestructActivationDuration;
	}

	void Update()
	{
		HandleDestructible();
	}

//	void OnTriggerEnter(Collider collider)
//	{
//		HandleBomberCharacterCollision(collider);		
//		HandleDestructionCollision(collider);
//	}

	protected override void HandleCollision()
	{
		HandleBomberCharacterCollision(mCollider);		
		HandleDestructionCollision(mCollider);
	}

	protected void HandleBomberCharacterCollision(Collider collider)
	{
		if(LayerMaskUtil.ContainsLayer(mBomberMask, collider.gameObject.layer))
			HandleCollected(collider);
	}
		
	protected void HandleDestructionCollision(Collider collider)
	{
		if(LayerMaskUtil.ContainsLayer(mDestructionMask, collider.gameObject.layer))
			Destroy(gameObject.transform.root.gameObject);
	}

	protected void HandleDestructible()
	{
		if(mDestructActivationTime < Time.time)
			mDestructible = true;
	}

	protected abstract void HandleCollected(Collider collider);

	public float mDestructActivationDuration = 1.5f;

	public LayerMask mBomberMask;
	public LayerMask mDestructionMask;

	protected float mDestructActivationTime;
	protected bool mDestructible;
}
