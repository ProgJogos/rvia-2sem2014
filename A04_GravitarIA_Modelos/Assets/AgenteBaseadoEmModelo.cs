using UnityEngine;
using System.Collections;

public enum Estado
{
    EmAlerta,
    EmPerigo,
    Seguro
}

public class AgenteBaseadoEmModelo : MonoBehaviour
{
    public LayerMask mascara;
    public Transform alvo;
    public float raio;
    public Estado estadoAtual;

    void Update()
    {
        estadoAtual = DecidirEstado();
        switch (estadoAtual)
        {
            case Estado.Seguro:
                print("ficar parado");
                break;
            case Estado.EmAlerta:
                print("procurar jogador / patrulhar");
                break;
            case Estado.EmPerigo:
                print("mirar e atirar / fugir");
                break;
        }
    }

    Estado DecidirEstado()
    {
        float distancia = Vector3.Distance(
            transform.position,
            alvo.position);

        RaycastHit2D toque = Physics2D.Raycast(
            transform.position, 
            (alvo.position - transform.position),
            100f,
            mascara);

        bool visivel = (toque.transform == alvo);
        bool perto = (distancia <= raio);

        if (!visivel)
        {
            return Estado.Seguro;
        } else if (perto)
        {
            return Estado.EmPerigo;
        } else
        {
            return Estado.EmAlerta;
        }
    }

}
