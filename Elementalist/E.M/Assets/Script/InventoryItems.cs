using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItems : MonoBehaviour {

    public Sprite[] sprite = new Sprite[7];
    public int state = 6;
	public int invenNumber = 0;

	public GameObject player;
	public GameObject equip;
	public GameObject origin;

	private Vector3 offset;
	private Vector2 originPosition;
    public bool isStuff = false;
    public bool craftContact = false;
	public bool playerContact = false;


    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = sprite[state];
        originPosition = origin.transform.position;
       // Debug.Log(craftContact);
    } 	

	void OnMouseDown()
	{
		if (state != 6) {
			
			offset = gameObject.transform.position -
			Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f));
		}
	}

	void OnMouseDrag()
	{
		if (state != 6) {
			Vector3 newPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f);
			transform.position = Camera.main.ScreenToWorldPoint (newPosition) + offset;
		}
	}

	void OnMouseUp(){
		if (state != 6) {
			if (playerContact == true || craftContact) {
                if (playerContact)
                {
                    equip.GetComponent<EquipItem>().state = state;
                    Debug.Log(transform.position.x + "");
                    transform.position = originPosition;
                    state = 6;
                    GameObject.Find("Inventory").GetComponent<Inventory>().useItem(invenNumber);
                }
                
                if (craftContact)
                {
                    if (GameObject.Find("CraftingTable").GetComponent<Craft>().craftNum == 0)
                        originPosition = new Vector3(-0.8f, 0, -1);
                    if (GameObject.Find("CraftingTable").GetComponent<Craft>().craftNum == 1)
                        originPosition = new Vector3(0, 0, -1);

                    GameObject.Find("Inventory").GetComponent<Inventory>().moveToCraft(invenNumber);

                }

            }
            else {
				transform.position = originPosition;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{ 	
		if (other.gameObject.CompareTag ("Player"))
			playerContact = true;

        if (other.gameObject.CompareTag("Skill"))
            craftContact = true;

        Debug.Log(other.gameObject.tag);
    }

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
			playerContact = false;

        if (other.gameObject.CompareTag("Skill"))
            craftContact = false;
    }
		
}