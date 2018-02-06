using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItems1 : MonoBehaviour {

    public Sprite[] sprite = new Sprite[7];
    public int state = 6;
    public int invenNumber = 0;

    public GameObject player;
    public GameObject equip;
    public GameObject origin;

    private Vector3 offset;
    private Vector2 originPosition;

    private bool playerContact = false;


    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = sprite[state];
    }

    void OnMouseDown()
    {
        if (state != 6)
        {
            offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }
    }

    void OnMouseDrag()
    {
        if (state != 6)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }

    void OnMouseUp()
    {
        if (state != 6)
        {
            if (playerContact == true)
            {
                equip.GetComponent<EquipItem>().state = state;
                Debug.Log(transform.position.x + "");
                transform.position = originPosition;
                state = 6;
                GameObject.Find("Inventory").GetComponent<Inventory>().useItem(invenNumber);
            }
            else
            {
                transform.position = originPosition;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerContact = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerContact = false;
    }

}
