using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	Vector2 targetPos;

	public GameObject item;

	public bool isDead = false;

	void Start () {
		StartCoroutine (Targetting ());
	}

	void Update () {
		transform.Translate (targetPos * 3.0f * Time.deltaTime);
		if (isDead) {
			Instantiate (item, transform.position, Quaternion.identity);
			item.GetComponent<FieldItems> ().element = Random.Range(0, 2);
			Destroy (gameObject);
		}
	}

	IEnumerator Targetting(){
		targetPos = (GameObject.Find ("Player").GetComponent<PlayerController> ().transform.position - transform.position).normalized;
		yield return new WaitForSeconds (0.75f);
		StartCoroutine (Targetting());
	}
}
