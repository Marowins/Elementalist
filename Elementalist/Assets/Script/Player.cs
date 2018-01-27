using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float speed = 6.0f;
    public GameObject[] items = new GameObject[6];
	public GameObject magicArrow;
	GameObject inven;

	public bool isInventoryOpen = false;

	public int element = 0;

	public Vector3 mousePos;

	Vector2 movement;
	Animator anim;
	Rigidbody2D rb;

	void Start()
	{
		inven = GameObject.Find ("Inventory");
		anim = GetComponent<Animator> ();
	}

	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		movement = new Vector2 (x, y);
		transform.Translate (movement * speed * Time.deltaTime);

		if (x > 0 || (x > 0 && y > 0) || (x > 0 && y < 0)) {
			anim.SetBool ("isMoving", true);
			anim.SetInteger ("y", 0);

			anim.SetInteger ("x", 1);
		} else if ( x < 0 || ( x < 0 && y > 0 ) || ( x > 0 && y < 0 )) {
			anim.SetBool ("isMoving", true);
			anim.SetInteger ("y", 0);

			anim.SetInteger ("x", -1);
		} else {
			if (y > 0) {
				anim.SetBool ("isMoving", true);
				anim.SetInteger ("x", 0);

				anim.SetInteger ("y", 1);
			} else if (y < 0) {
				anim.SetBool ("isMoving", true);
				anim.SetInteger ("x", 0);

				anim.SetInteger ("y", -1);
			} else {
				anim.SetBool ("isMoving", false);
				anim.SetInteger ("x", 0);
				anim.SetInteger ("y", 0);
			}
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
