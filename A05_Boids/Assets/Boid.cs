using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boid : MonoBehaviour
{

	public static List<Boid> boids;

	public float velocidadeMaxima;
	public float curvaMaxima;
	public Vector3 velocidadeDesejada;
	Vector3 steer;
	float contadorComportamentos;

	void Start ()
	{
		if (boids == null) {
			boids = new List<Boid> ();
		}
		boids.Add (this);

		rigidbody2D.velocity = Random.insideUnitCircle * velocidadeMaxima;
	}
	
	void Update ()
	{
		// rotacao visual
		transform.right = rigidbody2D.velocity;
	}

	void FixedUpdate ()
	{
		// aplicando a media de todos os comportamentos
		if (contadorComportamentos != 0)
			velocidadeDesejada = velocidadeDesejada / contadorComportamentos;
		// limitando os vetores pelos valores maximos
		velocidadeDesejada = Vector3.ClampMagnitude (
			velocidadeDesejada, velocidadeMaxima);
		steer = velocidadeDesejada - (Vector3)rigidbody2D.velocity;

		steer = Vector3.ClampMagnitude (steer, curvaMaxima);
		// aplicar a forca
		rigidbody2D.AddForce (steer);
		// reiniciar contadores e medias
		contadorComportamentos = 0;
		velocidadeDesejada = Vector3.zero;
	}

	public void AdicionarVelDesejada (Vector3 desejada, float peso)
	{
		contadorComportamentos += peso;
		velocidadeDesejada += desejada * peso;
	}
}
