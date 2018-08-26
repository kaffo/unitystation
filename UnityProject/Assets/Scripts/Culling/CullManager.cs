using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CullManager : MonoBehaviour
{

	private static CullManager cullManager;

	public static CullManager Instance
	{
		get
		{
			if (cullManager == null)
			{
				cullManager = FindObjectOfType<CullManager>();
			}
			return cullManager;
		}
	}

	public static List<SimpleTile> basicTiles = new List<SimpleTile>();

	private void OnEnable()
	{
		SceneManager.activeSceneChanged += Instance.OnSceneChange;
	}

	private void OnDisable()
	{
		SceneManager.activeSceneChanged -= Instance.OnSceneChange;
	}

	void OnSceneChange(Scene prevScene, Scene nextScene)
	{
		ResetManager();
	}

	void ResetManager()
	{
		Debug.Log("Reset");
		basicTiles.Clear();
	}

	public static void CullTile(int index, bool isOn)
	{
		//if (!Application.isPlaying)
		//{
		//	return;
		//}

		//if(PlayerManager.LocalPlayer == null)
		//{
		//	return;
		//}

		//Debug.Log("Cull tilE: " + isOn);
		//if (isOn)
		//{
		//	basicTiles[index].tileMap.SetTile(basicTiles[index].LocalPos(),
		//		basicTiles[index]);
			
		//} else
		//{
		//	basicTiles[index].tileMap.SetTile(basicTiles[index].LocalPos(), null);
		//}
		//basicTiles[index].tileMap.RefreshTile(basicTiles[index].LocalPos());
		//	basicTiles[index].tileMap.SetTile(basicTiles[index].LocalPos(), null);
	}
}
