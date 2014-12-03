using UnityEngine;
using System.Collections;

public class ComportamentoVagar : MonoBehaviour
{
    public float peso;

    public float freqAtual;
    public float freqMinima;
    public float freqMaxima;
    public float raioMinimo;
    public float raioMaximo;
    Vector3 alvo;
    float timer = 9999f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= freqAtual)
        {
            timer = 0;
            freqAtual = Random.Range(freqMinima, freqMaxima);
            alvo = Random.insideUnitCircle.normalized * 
                Random.Range(raioMinimo, raioMaximo);
        }
        Vector3 desejado = alvo - transform.position;
        GetComponent<Boid>().AdicionarVelDesejada(desejado, peso);
    }
}
