using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float speed = 6.0f;
    public GameObject[] items = new GameObject[6];
	public GameObject magicArrow;
	GameObject inven;

	Animator anim;

	public bool isInventoryOpen = false;

	public int element = 0;

	public Vector3 mousePos;

	void Start()
	{
		inven = GameObject.Find ("Inventory");
		anim = GetComponent<Animator> ();
	}

	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
			anim.Play ("player_right");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
			anim.Play ("player_left");
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime);
			anim.Play ("player_back");
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime);
			anim.Play ("player_front");
        }
		if (Input.GetMouseButtonDown(0)) {
			mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
			Instantiate (magicArrow, transform.position, Quaternion.identity);
		}


    }

	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag.Equals ("Items") && inven.GetComponent<Inventory>().itemNumb != 6) {
			element = other.gameObject.GetComponent<FieldItems> ().element;
			GameObject.Find ("Inventory").GetComponent<Inventory> ().takeItem (element);
			Destroy (other.gameObject);
		}
    }
}
