using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour {
	public int thisID;
	Animator PlayerAnim;
	CapsuleCollider2D PlayerPunch;
	Rigidbody2D target;


	// Use this for initialization
	void Start () {
		//PlayerAnim = GetComponentInParent<Animator> ();
		PlayerPunch = GetComponent<CapsuleCollider2D> ();
		//Debug.Log (PlayerAnim.GetBool("Test"));
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Entered");
	}
	void OnTriggerEnter2D(Collider2D Pl)
	{
		Debug.Log ("Entered");
		if (Pl.gameObject.tag == "Player") {
			target = Pl.gameObject.GetComponent<Rigidbody2D> ();
			//Debug.Log (PlayerAnim.GetBool ("Test"));
			PlayerAnim = Pl.gameObject.GetComponent<Animator>();
			PlayerAnim.SetBool ("Test", true);
			//target.
			Debug.Log (PlayerAnim.GetBool ("Test"));
		}
	}



}
