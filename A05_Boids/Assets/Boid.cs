using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boid : MonoBehaviour {

	public static List<Boid> boids;

	void Start () {

		if (boids == null) 
		{
			boids = new List<Boid>();
		}
		boids.Add (this);

		rigidbody2D.velocity = Random.insideUnitCircle * 5f;
	}
	
	void Update () {
		// rotacao visual
		transform.right = rigidbody2D.velocity;
	}
}
