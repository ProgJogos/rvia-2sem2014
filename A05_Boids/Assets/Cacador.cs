using UnityEngine;
using System.Collections;

public class Cacador : MonoBehaviour
{
    public string tagPresa = "Caca";
    public float raioDeteccao = 10f;
    private Boid boidPresa;

    void Update()
    {
        GameObject[] presas = GameObject.FindGameObjectsWithTag(
            tagPresa);
        if (presas.Length > 0 && boidPresa == null)
        {
            foreach (var boid in Boid.boids)
            {
                float distancia = Vector3.Distance(
                    boid.transform.position,
                    transform.position);
                                                   
                if (distancia <= raioDeteccao &&
                    distancia > 0 &&
                    boid.CompareTag(tagPresa))
                {
                    boidPresa = boid;
                }
            }

            if (boidPresa != null)
            {
                GetComponent<ComportamentoSeek>().peso = 20;
                GetComponent<ComportamentoSeek>().alvo = 
                    boidPresa.gameObject;
            }
        }


    }
}