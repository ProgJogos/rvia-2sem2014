using UnityEngine;
using System.Collections;

public class ComportamentoAlinhamento : MonoBehaviour
{
	public float peso;
	Vector3 desejado;
	public float raio;

	void Update ()
	{
		desejado = Vector3.zero;
		int boidsProximos = 0;
		foreach (var boid in Boid.boids) {
			// distancia do boid atual para o outro
			float distancia = Vector3.Distance (
				boid.transform.position, 
				transform.position);
			if (distancia <= raio && distancia > 0) {
				desejado = desejado + (Vector3)boid.rigidbody2D.velocity;
				boidsProximos++;
			}
		}
		if (boidsProximos > 0) {
			desejado = desejado / boidsProximos;
		}
		GetComponent<Boid> ().AdicionarVelDesejada (desejado, peso);
	}
}
