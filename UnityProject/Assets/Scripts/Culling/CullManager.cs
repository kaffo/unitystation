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

	public static HashSet<BasicTile> baseTiles = new HashSet<BasicTile>();

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
		baseTiles.Clear();
	}
}
