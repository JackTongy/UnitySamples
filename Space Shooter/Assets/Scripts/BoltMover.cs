using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = speed * transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
