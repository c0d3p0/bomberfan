using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStandardExplosionEffect : MonoBehaviour
{
	void Start () 
	{
		mBomb = GetComponentInParent<Bomb>();

		Transform mStrikeBoxGameObjectTransform = GameObjectUtil.FindChildTransformByTag(transform.root, TagName.STRIKE_BOX);

		mStrikeBoxTransform = GameObjectUtil.FindChildTransformByTag(mStrikeBoxGameObjectTransform, mStrikeBoxTag);
		mBoxCollider = mStrikeBoxTransform.GetComponent<BoxCollider>();
	}

	void Update()
	{
		HandleEffect();
	}

	protected void HandleEffect()
	{
		if(mBomb.ExplosionStarted)
		{
			transform.localScale = mBoxCollider.size;
			transform.position = mStrikeBoxTransform.position;
		}
	}

	public string mStrikeBoxTag;

	protected BoxCollider mBoxCollider;
	protected Transform mStrikeBoxTransform;

	protected Bomb mBomb;
}
