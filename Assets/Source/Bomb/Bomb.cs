using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Bomb : MonoBehaviour
{
	void Start()
	{
//		mExplosionColliders = GetComponentsInChildren<BombExplosionStrikeBox>();
//		mRenderer = GetComponent<MeshRenderer>();
//		mCollider = GetComponent<Collider>();
//		mIgnoreCharacters = new Dictionary<int, GameObject>();

//		IgnoreCollisionInSamePoint();
		OnStart();
	}

	void Update()
	{
//		HandleSamePointColision();
		HandleEndExplosion();
		HandleStartExplosion();
		OnUpdate();
	}

	// TODO: Attention to some hard coded values
	// After character is out of the same point as bomb, colision to the
	// character has to go to the original state.
//	protected void IgnoreCollisionInSamePoint()
//	{
//		GameObject gameObject;
//
//		// Hard coded radius value
//		Collider[] colliders = Physics.OverlapSphere(transform.root.gameObject.transform.position, 1, mCollisionCheckLayer);
//
//		foreach(Collider collider in colliders)
//		{
//			gameObject = collider.transform.root.gameObject;
//			Collider rootCollider = gameObject.GetComponent<Collider>();
//			Physics.IgnoreCollision(mCollider, rootCollider, true);
//			mIgnoreCharacters[gameObject.GetInstanceID()] = gameObject;
//		}
//	}

	// TODO: Attention to some hard coded values
	// Fill the mIgnoreCharacters list and add ignore colision to it
//	protected void HandleSamePointColision()
//	{
//		if(mIgnoreCharacters.Count < 1 || mExploding)
//			return;
//
//		GameObject gameObject;
//
//		// Hard coded radius value
//		Collider[] colliders = Physics.OverlapSphere(transform.root.gameObject.transform.position, 1, mCollisionCheckLayer);
//		Dictionary<int, GameObject> mapColliders = new Dictionary<int, GameObject>();
//
//		foreach(Collider collider in colliders)
//		{
//			gameObject = collider.transform.root.gameObject;
//			mapColliders[gameObject.GetInstanceID()] = gameObject;
//		}
//
//		foreach(GameObject ignoreObject in mIgnoreCharacters.Values)
//		{
//			Collider ignoreCollider;
//
//			if(!(mapColliders.ContainsKey(ignoreObject.GetInstanceID())))
//			{
//				ignoreCollider = ignoreObject.GetComponent<Collider>();
//				Physics.IgnoreCollision(mCollider, ignoreCollider, false);
//				mIgnoreCharacters.Remove(ignoreCollider.GetInstanceID());
//			}
//		}
//	}

//	protected void HandleStartExplosion()
//	{
//		if(!mExplosionStarted && mDetonationActivated)
//		{
//			for(int i = 0; i < mExplosionColliders.Length; i++)
//				mExplosionColliders[i].enabled = true;
//
////			mRenderer.enabled = false;
////			mCollider.enabled = false;
//			mExplosionStarted = true;
//		}
//	}

	protected void HandleEndExplosion()
	{			
		if(mExplosionStarted && ((mExplosionEndTime + mEffectTimeTolerance) < Time.time))
			Destroy(this.gameObject);
	}

	protected void HandleStartExplosion()
	{
		if(!mExplosionStarted && mDetonationActivated)
		{
			for(int i = 0; i < transform.childCount; i++)
			{
				Transform childTransform = transform.GetChild(i);

				if(childTransform.tag.Equals(TagName.STRIKE_BOX))
				{
					childTransform.gameObject.SetActive(true);
					continue;
				}

				if(childTransform.tag.Equals(TagName.PARTICLE_EFFECT))
				{
					childTransform.gameObject.SetActive(true);
					continue;
				}
					
				childTransform.gameObject.SetActive(false);
			}

			mExplosionStarted = true;
			mExplosionEndTime = Time.time + mExplosionDuration;
		}
	}

	public bool ExplosionStarted
	{
		get
		{
			return mExplosionStarted;
		}
	}

	public float ExplosionEndTime
	{
		get
		{
			return mExplosionEndTime;
		}
	}
		
	public virtual bool Detonate() 
	{
		return false;
	}

	protected virtual void OnUpdate() {}
	protected virtual void OnStart() {}


	public BombType mBombType;
	public ExplosionType mExplosionType;

	public float mExplosionDuration;
	public float mEffectTimeTolerance;


	[HideInInspector]
	public GameObject mMBOwner;
	
	[HideInInspector]
	public bool mDetonationActivated;

	[HideInInspector]
	public float mExplosionSizeFactor;

//	protected MeshRenderer mRenderer;
//	protected Collider mCollider;

	protected float mExplosionEndTime;

	protected bool mExplosionStarted, mExplosionEnded;
}
