using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject startText;

    public void HideStartText()
	{
		startText.SetActive(false);
	}
}
