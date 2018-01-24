using System.Collections;	
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public GameObject cam;
	public GameObject[] inventory = new GameObject[6];
	public int itemNumb = 0;

	private int i;

	void Update()
	{
		transform.position = cam.transform.position;
	}


	public void takeItem(int element){
		inventory [itemNumb].GetComponent<InventoryItems> ().state = element;
		inventory [itemNumb].GetComponent<InventoryItems> ().invenNumber = itemNumb;
		itemNumb++;
	}

	public void useItem(int invenNumb)
	{

		for (i = invenNumb; i < 5; i++) {
			inventory [i].GetComponent<InventoryItems> ().state = inventory [i+1].GetComponent<InventoryItems> ().state;
		}
		inventory [5].GetComponent<InventoryItems> ().state = 6;
		itemNumb--;
	}
}