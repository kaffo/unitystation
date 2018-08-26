using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullBehaviour : MonoBehaviour
{
	CullingGroup localCullingGroup;

	BoundingSphere[] cullingPoints;

	private void OnEnable()
	{
		DoInit();
	}

	void OnDisable()
	{
		localCullingGroup.Dispose();
	}

	private void DoInit()
	{
		localCullingGroup = new CullingGroup();
		cullingPoints = new BoundingSphere[CullManager.basicTiles.Count];

		for (int i = 0; i < CullManager.basicTiles.Count; i++)
		{
			cullingPoints[i].position = CullManager.basicTiles[i].localPos;
			cullingPoints[i].radius = 4f;
		}

		localCullingGroup.onStateChanged = CullingEvent;
		localCullingGroup.SetBoundingSpheres(cullingPoints);
		localCullingGroup.SetBoundingDistances(new float[] { 0f, 5f });
		localCullingGroup.SetDistanceReferencePoint(transform.localPosition);
		localCullingGroup.targetCamera = Camera.main;

		Debug.Log("LENGTH OF CULLS " + CullManager.basicTiles.Count);
	}

	private void FixedUpdate()
	{
		localCullingGroup.SetDistanceReferencePoint(transform.localPosition);
	}

	void CullingEvent(CullingGroupEvent sphere)
	{
		switch (sphere.currentDistance)
		{
			case 0:
				CullManager.basicTiles[sphere.index].CullTile(true);
				break;
			case 1:
				CullManager.basicTiles[sphere.index].CullTile(false);
				break;
			case 2:
				CullManager.basicTiles[sphere.index].CullTile(false);
				break;
		}
	}
}
