using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugNuclearExplosionEffect : MonoBehaviour
{
	void Start () 
	{
		mBomb = GetComponentInParent<Bomb>();

//		mStrikeBoxTransform = GameObjectUtil.FindChildTransformByTag(transform.root, TagName.STRIKE_BOX);
		mSphereCollider = GameObjectUtil.FindChildTransformByTag(transform.root, TagName.STRIKE_BOX).GetComponent<SphereCollider>();
	}

	void Update()
	{
		HandleEffect();
	}

	protected void HandleEffect()
	{
		if(mBomb.ExplosionStarted)
		{
			float size = mSphereCollider.radius * 2;
			transform.localScale = new Vector3(size, size, size);
		}
	}

//	public string mStrikeBoxTag;

	protected SphereCollider mSphereCollider;
//	protected Transform mStrikeBoxTransform;

	protected Bomb mBomb;
}
