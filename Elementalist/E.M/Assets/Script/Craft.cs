using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour {

    public GameObject[] stuff = new GameObject[2];
    public GameObject result;
    public int craftNum = 0;


    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (stuff[1] != null) craftNum = 1;
        else if (stuff[0] != null) craftNum = 0;
    }
}
