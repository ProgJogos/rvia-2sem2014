 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boid : MonoBehaviour
{
    public static List<Boid> boids = null;
    public static Vector3[,] campoDeFluxo = null;
    public static int larguraCelulaFluxo = 5;

    public float velocidadeMaxima;
    public float curvaMaxima;
    public Vector3 velocidadeDesejada;
    Vector3 steer;
    float contadorComportamentos;

    void Start()
    {
        // inicializaco da lista de boids
        if (boids == null)
        {
            boids = new List<Boid>();
        }
        boids.Add(this);
        float angulo;
        float offset = Random.Range(-20f, 20f);
        // inicializacao do campo de fluxo
        if (campoDeFluxo == null)
        {
            campoDeFluxo = new Vector3[20, 20];
            for (int l = 0; l < 20; l++)
            {
                for (int c = 0; c < 20; c++)
                {
                    float X = Mathf.PerlinNoise(
                        offset + c * 1.121f, 0.121f);
                    float Y = Mathf.PerlinNoise(
                        offset + l * 1.121f, 0.121f);
                    campoDeFluxo [c, l] = new Vector3(
                        X, 
                        Y, 
                        0f).normalized * 10f;

                    //campoDeFluxo [c, l] = Random.insideUnitCircle;
                }
            }
        }

        rigidbody2D.velocity = 
            Random.insideUnitCircle * velocidadeMaxima;
    }
	
    void Update()
    {
        // rotacao visual
        transform.right = rigidbody2D.velocity;
    }

    void FixedUpdate()
    {
        // aplicando a media de todos os comportamentos
        if (contadorComportamentos != 0)
            velocidadeDesejada = velocidadeDesejada / contadorComportamentos;
        // limitando os vetores pelos valores maximos
        velocidadeDesejada = Vector3.ClampMagnitude(
			velocidadeDesejada, velocidadeMaxima);
        steer = velocidadeDesejada - (Vector3)rigidbody2D.velocity;

        steer = Vector3.ClampMagnitude(steer, curvaMaxima);
        // aplicar a forca
        rigidbody2D.AddForce(steer);
        // reiniciar contadores e medias
        contadorComportamentos = 0;
        velocidadeDesejada = Vector3.zero;
    }

    public void AdicionarVelDesejada(Vector3 desejada, float peso)
    {
        contadorComportamentos += peso;
        velocidadeDesejada += desejada * peso;
    }
}
