using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// values
    public float speed = 6.0f;
	public int hp = 10;
	public int element = 0;
	public float x; // player position x
	public float y; // player positino y

	//bool
	bool isDamaged = false;

	// inventory
	public bool isInventoryOpen = false;
    public GameObject[] items = new GameObject[6];
	public GameObject magicArrow;
	GameObject inven;

	// Vector2~3
	public Vector3 mousePos;
	Vector2 movement;

    PlayerMovement playerMov;

	void Start()
	{
		inven = GameObject.Find ("Inventory");
        playerMov = GetComponent<PlayerMovement>();
	}

	void Update () {
		//input
		x = Input.GetAxisRaw ("Horizontal");
		y = Input.GetAxisRaw ("Vertical");

        playerMov.Move(x,y);

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

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Enemy")) {
			if (isDamaged == false) {
				hp -= 1;
				StartCoroutine (Damaged ());
			}
		}
	}

	IEnumerator Damaged(){
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
		isDamaged = true;
		yield return new WaitForSeconds (1.5f);
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
		isDamaged = false;
	}
}
