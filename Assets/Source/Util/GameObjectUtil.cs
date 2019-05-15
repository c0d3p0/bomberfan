using System;
using UnityEngine;

public class GameObjectUtil
{
	public static GameObject FindChildByTag(Transform parent, string tag)
	{
		for(int i = 0; i < parent.childCount; i++)
		{
			Transform child = parent.GetChild(i);

			if(child.tag.Equals(tag))
				return child.gameObject;
		}

		return null;
	}

	public static Transform FindChildTransformByTag(Transform parent, string tag)
	{
		for(int i = 0; i < parent.childCount; i++)
		{
			Transform child = parent.GetChild(i);

			if(child.tag.Equals(tag))
				return child;
		}

		return null;
	}
}

