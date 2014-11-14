using UnityEngine;
using System.Collections;

public enum Objetivo
{
    DestruirAlvo,
    Sobreviver
}

public class EscolherObjetivo : MonoBehaviour
{

    public Objetivo objetivoAtual;
    public float pesosDestruirAlvoQuandoSeguro;
    public float pesosDestruirAlvoQuandoAlerta;
    public float pesosDestruirAlvoQuandoPerigo;
	
    void Update()
    {
        Estado estado = GetComponent<DetectarEstado>().estadoAtual;
        float sorteio = Random.value;
        switch (estado)
        {
            case Estado.Seguro:
                if (sorteio <= pesosDestruirAlvoQuandoSeguro)
                {
                    objetivoAtual = Objetivo.DestruirAlvo;
                } else
                {
                    objetivoAtual = Objetivo.Sobreviver;
                }
                break;
            case Estado.EmAlerta:
                if (sorteio <= pesosDestruirAlvoQuandoAlerta)
                {
                    objetivoAtual = Objetivo.DestruirAlvo;
                } else
                {
                    objetivoAtual = Objetivo.Sobreviver;
                }
                break;
            case Estado.EmPerigo:
                if (sorteio <= pesosDestruirAlvoQuandoPerigo)
                {
                    objetivoAtual = Objetivo.DestruirAlvo;
                } else
                {
                    objetivoAtual = Objetivo.Sobreviver;
                }
                break;
        }
    }
}
