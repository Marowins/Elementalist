using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// values
	public int hp = 10;
	public int element = 0;
	public float x; // player position x
	public float y; // player positino y
	public float msBetweenAttack = 1000; //attack speed (ms)
	float nextAttackTime;

	//bool
	bool isDamaged = false;

	// inventory
	public bool isInventoryOpen = false;
	public GameObject[] items = new GameObject[6];
	public GameObject magicArrow;
	GameObject inven;

	// Vector2~3
	public Vector3 mousePos;

    // Require Component
    PlayerMovement playermovement;

	void Start()
	{
		inven = GameObject.Find ("Inventory");
        playermovement = GetComponent<PlayerMovement>();
	}

	void Update () {
		//input
		x = Input.GetAxisRaw ("Horizontal");
		y = Input.GetAxisRaw ("Vertical");

        playermovement.Move(x, y);

		//공격
		if (Input.GetMouseButton(0)) {
			mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
			if (Time.time > nextAttackTime) {	//공격속도 제한
				nextAttackTime = Time.time + msBetweenAttack / 1000;
				Instantiate (magicArrow, transform.position, Quaternion.identity);
                SoundManager.instance.magic.Play();
            }

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
			if (isDamaged == false && other.GetComponent<Kelsiper>().isDead == false) {
				hp -= 1;
				StartCoroutine (Damaged ());
			}
		}
	}

	//피격시 무적
	IEnumerator Damaged(){
        SoundManager.instance.hit.Play();
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
		isDamaged = true;
		yield return new WaitForSeconds (1.5f);
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
		isDamaged = false;
	}
}
