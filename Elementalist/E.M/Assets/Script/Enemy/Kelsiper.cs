using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kelsiper : MonoBehaviour {

	//Value
	public int hp = 4;
    float colorA = 1;
	//Vector
	Vector2 targetPos;

	//GameObject
	public GameObject item;

	//bool
	public bool isDead = false;
	bool waiting = false;

	void Start () {
		StartCoroutine (Targetting ());
	}

	void Update () {
		if(waiting == false)
			transform.Translate (targetPos * 4.0f * Time.deltaTime);

        if (hp <= 0) {
            colorA -= Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, colorA);

            if (colorA <= 0)
            {
                Instantiate(item, transform.position, Quaternion.identity);
                item.GetComponent<FieldItems>().element = 4;
                Destroy(gameObject);
            }
		}
	}

	IEnumerator Targetting(){
		targetPos = (GameObject.Find ("Player").GetComponent<PlayerController> ().transform.position - transform.position).normalized;
		yield return new WaitForSeconds (1.5f);
		StartCoroutine (Targetting());
	}
}
