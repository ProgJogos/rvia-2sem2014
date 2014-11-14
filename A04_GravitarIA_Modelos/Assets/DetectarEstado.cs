using UnityEngine;
using System.Collections;

public class DetectarEstado : MonoBehaviour
{
    public LayerMask mascara;
    public Transform alvo;
    public float raio;
    public Estado estadoAtual;
    
    void Update()
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
            estadoAtual = Estado.Seguro;
        } else if (perto)
        {
            estadoAtual = Estado.EmPerigo;
        } else
        {
            estadoAtual = Estado.EmAlerta;
        }
    }
}
