using UnityEngine;
using System.Collections;

public class ComportamentoCampoDeFluxo : MonoBehaviour
{
    public float peso;

    void Update()
    {
        int coluna = Mathf.FloorToInt(transform.position.x) 
            / Boid.larguraCelulaFluxo;
        int linha = Mathf.FloorToInt(transform.position.y) 
            / Boid.larguraCelulaFluxo;

        coluna = Mathf.Clamp(coluna, 0, 19);
        linha = Mathf.Clamp(linha, 0, 19);

        GetComponent<Boid>().AdicionarVelDesejada(
            Boid.campoDeFluxo [coluna, linha].normalized,
            peso);

        // visualizacao de debug
        for (int l = 0; l < 20; l++)
        {
            for (int c = 0; c < 20; c++)
            {
                Debug.DrawRay(new Vector3(
                    c * Boid.larguraCelulaFluxo, 
                    l * Boid.larguraCelulaFluxo,
                    0), Boid.campoDeFluxo [c, l], Color.cyan);
            }
        }
    }
}
