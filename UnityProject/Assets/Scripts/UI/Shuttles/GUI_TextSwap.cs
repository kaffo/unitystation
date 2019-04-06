﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A generic TextSwap script for different UITypes
/// </summary>
public class GUI_TextSwap : MonoBehaviour
{
	[Header("References")]
	public GUI_ShuttleControl shuttleControlScript;
	public Text textToSet;

	[Header("Settings")]
	public UISwapDictionary textSetupDict;

	void Start()
    {
		if (shuttleControlScript == null || textToSet == null)
		{
			Logger.LogError("TextSwap script reference failure!");
			this.enabled = false;
			return;
		}

		UIType keyToCheck = shuttleControlScript.MatrixMove.uiType;
		if (textSetupDict.ContainsKey(keyToCheck))
		{
			textToSet.text = textSetupDict[keyToCheck].Replace("\\n","\n");
		} else
		{
			Logger.LogWarning("No Key for UIType found in TextSwap. Leaving Text alone", Category.UI);
		}
	}
}
