using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicArrow : MonoBehaviour {

	GameObject[] Enemys;

	GameObject target;

	Vector3 targetPos;

	int playerState;

	private bool isAttacking = false;

	void Start()
	{
		var distance = Mathf.Infinity;
		Enemys = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject targetEnemys in Enemys) {
			Vector2 targetPos = targetEnemys.transform.position;
			Vector2 diff = targetEnemys.transform.position - transform.position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				target = targetEnemys;
				distance = curDistance;
			}
		}

		playerState = GameObject.Find ("Player").GetComponent<Player> ().element;

		targetPos = (GameObject.Find ("Player").GetComponent<Player> ().mousePos - transform.position).normalized;
	}

	void Update () {
		if (playerState == 0 || playerState == 6)
			transform.Translate (targetPos * 14.0f * Time.deltaTime);
		else if (playerState == 1) {
			if (target == null)
				Destroy (gameObject);
			else {
				if(isAttacking == false)
					transform.Translate (targetPos * 14.0f * Time.deltaTime);
				StartCoroutine (ArrowDelay());
				if(isAttacking == true)
					transform.position = Vector2.Lerp (transform.position, target.transform.position, 3 * Time.deltaTime);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("A");
		if (other.gameObject.CompareTag ("Enemy")) {
			Destroy (gameObject);
			other.GetComponent<Enemy> ().isDead = true;
		}
	}

	IEnumerator ArrowDelay(){
		yield return new WaitForSeconds (0.2f);
		isAttacking = true;
	}

}
