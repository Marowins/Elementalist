using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	public GameObject inventory;
	public GameObject inventoryButton;

	public void OpenIventory()
	{
		inventory.transform.Translate(Vector3.down * 3.5f);
		inventoryButton.SetActive (false);
	}
}
