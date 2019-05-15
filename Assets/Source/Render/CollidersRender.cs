using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// TODO: Code the logic to draw hit, strike, physic box using GameFlag variables
[RequireComponent(typeof(Renderer))]
public class CollidersRender : MonoBehaviour
{
	void Start()
	{
		mRenderer = GetComponent<Renderer>();
	}

	void OnDrawGizmos()
	{
		Render();
//		OnDrawGizmosSelected();
	}

//	void OnDrawGizmosSelected()
//	{
//		Render();
//	}

	protected void Render()
	{
		GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();

		foreach(GameObject gameObject in gameObjects)
		{
			if (mRenderer != null && !LayerMaskUtil.ContainsLayer(mIgnoredLayer, gameObject.layer))
			{
				Collider[] colliders = gameObject.GetComponents<Collider>();

				foreach(Collider collider in colliders)
				{
					if(!collider.enabled)
						continue;

					DrawBoxCollider(collider);
//					DrawCapsuleCollider(collider);
					DrawSphereCollider(collider);
				}
			}
		}
	}

	protected void DrawCapsuleCollider(Collider collider)
	{
		if(collider.GetType() == typeof(CapsuleCollider))
		{
//			CapsuleCollider capsuleCollider = (CapsuleCollider) collider;

			// TODO: Code the draw capsule collider here
		}
	}

	protected void DrawBoxCollider(Collider collider)
	{
		if(collider.GetType() == typeof(BoxCollider))
		{
			BoxCollider boxCollider = (BoxCollider) collider;
			Vector3 finalScale = boxCollider.size;
			Transform parentTransform = gameObject.transform.parent;
				
			if(parentTransform != null)
				finalScale = Vector3.Scale(finalScale, parentTransform.localScale);
				
			if(collider.isTrigger && GameFlag.drawTriggerBoxes)
			{
				if(LayerMaskUtil.ContainsLayerInGameObject(collider.gameObject, LayerName.EXPLOSION_STRIKE_BOX))
					Gizmos.color = Color.red;
				else
				{
					if(LayerMaskUtil.ContainsLayerInGameObject(collider.gameObject, LayerName.ENEMY_STRIKE_BOX))
						Gizmos.color = Color.yellow;
					else
						Gizmos.color = Color.green;
				}

				Gizmos.DrawWireCube(collider.transform.position, finalScale);
			}

			if(!collider.isTrigger && GameFlag.drawNonTriggerBoxes)
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawWireCube(collider.transform.position, finalScale);
			}
		}
	}

	protected void DrawSphereCollider(Collider collider)
	{
		if(collider.GetType() == typeof(SphereCollider))
		{
			SphereCollider sphereCollider = (SphereCollider) collider;
			Transform parentTransform = gameObject.transform.parent;
			float radius = sphereCollider.radius;

			if(parentTransform != null)
				radius *= Mathf.Max(parentTransform.localScale.x, parentTransform.localScale.y, parentTransform.localScale.z);

			if(collider.isTrigger && GameFlag.drawTriggerBoxes)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(collider.transform.position, radius);
			}
		}
	}
		
	public LayerMask mIgnoredLayer;
	
	protected Renderer mRenderer;
}
