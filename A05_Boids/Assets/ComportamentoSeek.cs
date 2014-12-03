using UnityEngine;
using System.Collections;

public class ComportamentoSeek : MonoBehaviour
{
	public float peso;
	public GameObject alvo;
	//public float velMaxima;
	//public float curvaMaxima;
	Vector3 velDesejada;


	void Update ()
	{
		velDesejada = alvo.transform.position - transform.position;
		//velDesejada = velDesejada.normalized * velMaxima;
		GetComponent<Boid> ().AdicionarVelDesejada (velDesejada, peso);
		//steer = steer.normalized * curvaMaxima;
	}
}
