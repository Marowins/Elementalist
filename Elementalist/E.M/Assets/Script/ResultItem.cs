using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultItem : MonoBehaviour {
    public Sprite[] sprite = new Sprite[7];
    public int state = 6;
    public GameObject origin;
    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().sprite = sprite[state];
        transform.position = origin.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
