using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboidStrikeBoxCollisionSender : MonoBehaviour
{
	void Start ()
	{
		mCollider = GetComponent<BoxCollider>();
	}

	void LateUpdate()
	{
		HandleCollisions();
	}

	protected void HandleCollisions()
	{
		Vector3 startPosition = mCollider.transform.position;
		startPosition.y -= 0.1f;

		RaycastHit[] raycastHits = Physics.BoxCastAll(startPosition, mCollider.bounds.extents, Vector3.up, Quaternion.identity, mCastDistance, mCollisionMask);
//			(startPosition, mCollider.radius, Vector3.up, mSphereCastDistance, mCollisionMask);

		for(int i = 0; i < raycastHits.Length; i++)
		{
			BaseHitBoxCollisionManager collisionHandler = raycastHits[i].collider.gameObject.GetComponent<BaseHitBoxCollisionManager>();

			if(collisionHandler != null)
				collisionHandler.AddCollision(mCollider);
		}
	}

	public LayerMask mCollisionMask;

	protected float mCastDistance = 0.1f;

	protected BoxCollider mCollider;
}