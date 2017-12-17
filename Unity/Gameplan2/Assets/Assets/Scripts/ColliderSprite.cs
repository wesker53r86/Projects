using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSprite : MonoBehaviour {
	SpriteRenderer charar;
	CapsuleCollider2D[] sounds;
	CapsuleCollider2D bounds;
	CapsuleCollider2D grounds;
	//CapsuleCollider2D grounds;
	Vector2 size;
	float unit;
	float a,b,c,d;
	Vector2 A,B,C;
	// Use this for initialization
	void Start () {
		charar = GetComponent <SpriteRenderer> ();
		sounds = GetComponents<CapsuleCollider2D> ();
		bounds = sounds [0];
		grounds = sounds [1];
		/*bounds = GetComponent <BoxCollider2D> ();
		grounds = GetComponent<BoxCollider2D> ();*/
		//grounds = GetComponent<CapsuleCollider2D> ();
		unit = charar.sprite.pixelsPerUnit; 
		size = charar.size;// in vector2 form
		CalculateOffsets();
	}
	//1/3 of the sprite is ground, 2/3 of sprite is body
	// Update is called once per frame
	void Update () {
		

	}
	void CalculateOffsets()
	{
		AdjustBounds ();
		AdjustGrounds ();
		a = charar.size.y/2;//center
		b = 0f;
		c = grounds.size.y/2;
		d = a - c;
		d = b - d;
		grounds.offset = new Vector2 (0, d);
		b = b + grounds.size.y;
		c = bounds.size.y / 2;
		d = a - c;
		d = b - d;
		bounds.offset = new Vector2 (0, d);

	}
	void AdjustBounds()
	{
		a = 2f/3f;
		a = size.y * a;
		b = size.y - a;
		bounds.size = new Vector2(size.x,a);
	}
	void AdjustGrounds()
	{
		a = 1f / 3f;
		a = size.y * a;
		b = size.y + a;
		grounds.size = new Vector2 (size.x, a);
	}
}
