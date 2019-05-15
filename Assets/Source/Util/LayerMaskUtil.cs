using System;
using UnityEngine;

public class LayerMaskUtil
{
	public static bool ContainsLayerInGameObject(GameObject gameObject, string layerName)
	{
		int layerToCheck = LayerMask.NameToLayer(layerName);

		if(gameObject.layer == layerToCheck)
			return true;

		return false;
	}

	public static bool ContainsLayerInGameObject(GameObject gameObject, int layer)
	{
		if(gameObject.layer == layer)
			return true;

		return false;
	}

	public static bool ContainsLayer(LayerMask layerMask, string layerName)
	{
		LayerMask layerMaskToCheck  = 1 << LayerMask.NameToLayer(layerName);

		if((layerMask & layerMaskToCheck) == layerMaskToCheck)
			return true;

		return false;
	}

	public static bool ContainsLayer(LayerMask layerMask, int layer)
	{
		LayerMask layerMaskToCheck  = 1 << layer;

		if((layerMask & layerMaskToCheck) == layerMaskToCheck)
			return true;

		return false;
	}

	public static bool ContainsLayerMask(LayerMask layerMask, LayerMask layerMaskToCheck)
	{
		if((layerMask & layerMaskToCheck) == layerMaskToCheck)
			return true;

		return false;
	}

	public static LayerMask AddToLayerMask(LayerMask layerMask, int layer)
	{
		layerMask |= 1 << layer;
		return layerMask;
	}

	public static LayerMask AddToLayerMask(LayerMask layerMask, string layerName)
	{
		layerMask |= 1 << LayerMask.NameToLayer(layerName);
		return layerMask;
	}
}

