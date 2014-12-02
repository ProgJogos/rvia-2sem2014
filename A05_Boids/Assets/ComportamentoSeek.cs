using UnityEngine;
using System.Collections;

public class ComportamentoSeek : MonoBehaviour {

	public GameObject alvo;
	public float velMaxima;
	public float curvaMaxima;


	Vector3 velDesejada;
	Vector3 velAtual;
	Vector3 steer;

	void Update () {
		velAtual = rigidbody2D.velocity;
		velDesejada = alvo.transform.position - transform.position;
		velDesejada = velDesejada.normalized * velMaxima;
		steer = velDesejada - velAtual;
		steer = steer.normalized * curvaMaxima;
	}

	void FixedUpdate () 
	{
		rigidbody2D.AddForce (steer);
	}
}
