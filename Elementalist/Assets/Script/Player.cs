using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// values
    public float speed = 6.0f;
	public int element = 0;
	public float x; // player position x
	public float y; // player positino y

	// inventory
	public bool isInventoryOpen = false;
    public GameObject[] items = new GameObject[6];
	public GameObject magicArrow;
	GameObject inven;

	// Vector2~3
	public Vector3 mousePos;
	Vector2 movement;

	// anim
	Animator anim;

	void Start()
	{
		inven = GameObject.Find ("Inventory");
		anim = GetComponent<Animator> ();
	}

	void Update () {
		x = Input.GetAxisRaw ("Horizontal");
		y = Input.GetAxisRaw ("Vertical");

		movement = new Vector2 (x, y);
		transform.Translate (movement * speed * Time.deltaTime);

		if ( x > 0 || (x > 0 && y != 0) ) { // 오른쪽 위 & 오른쪽 아래 & 오른쪽 
			anim.SetBool ("isMoving", true);
			anim.SetInteger ("y", 0); // 애니메이션 2개 중첩 방지

            anim.SetInteger ("x", 1);
		} else if ( x < 0 || ( x < 0 && y != 0) ) { // 왼쪽 위 & 왼쪽 아래 & 왼쪽
			anim.SetBool ("isMoving", true);
			anim.SetInteger ("y", 0); // 애니메이션 2개 중첩 방지

			anim.SetInteger ("x", -1);
		} else {
			if (y > 0) { // 위
				anim.SetBool ("isMoving", true);
				anim.SetInteger ("x", 0); // 애니메이션 2개 중첩 방지

                anim.SetInteger ("y", 1);
			} else if (y < 0) { // 아래
				anim.SetBool ("isMoving", true);
				anim.SetInteger ("x", 0); // 애니메이션 2개 중첩 방지

                anim.SetInteger ("y", -1);
			} else { // 멈췄을때
				anim.SetBool ("isMoving", false);
				anim.SetInteger ("x", 0);
				anim.SetInteger ("y", 0);
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
			var arrow = Instantiate (magicArrow, transform.position, Quaternion.identity);
			Destroy (arrow, 2f);
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
