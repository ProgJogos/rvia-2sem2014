using UnityEngine;
using System.Collections;

public class ComportamentoSeparacao : MonoBehaviour
{
	public float peso;
	public float raio;
	//public float velMaxima;
	Vector3 steer;

	
	void Update ()
	{

		Vector3 dirDesejada = Vector3.zero;
		foreach (var boid in Boid.boids) {
			float distancia = Vector3.Distance (
				boid.transform.position, 
				transform.position);

			if (distancia <= raio && distancia > 0) {
				dirDesejada += (transform.position - boid.transform.position);
				dirDesejada = dirDesejada * (raio - distancia) / raio;
			}
		}
		GetComponent<Boid> ().AdicionarVelDesejada (dirDesejada, peso);
	}
}
