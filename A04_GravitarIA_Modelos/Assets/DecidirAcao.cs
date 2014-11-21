using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecidirAcao : MonoBehaviour {

	public List<Acao> acoesPossiveis;
	public Acao acaoAtual;

	private DetectarEstado _detector;

	void Start () {
		acoesPossiveis = new List<Acao> ();
		acoesPossiveis.Add (new Fugir ());
		acoesPossiveis.Add (new Atirar ());
		acoesPossiveis.Add (new FazerNada ());
		acoesPossiveis.Add (new Procurar ());
		acoesPossiveis.Add (new Perseguir ());
		_detector = GetComponent<DetectarEstado> ();
	}

	void Update () {
		// recebe acao padrao
		acaoAtual = null;

		// se quero destruir o alvo
		if(GetComponent<EscolherObjetivo>().objetivoAtual == 
		   Objetivo.DestruirAlvo)
		{
			// se esta visivel
			if (_detector.estadoAtual != Estado.Seguro) {
				// se esta longe
				if(_detector.estadoAtual == Estado.EmAlerta) {
					if(Random.value > 0.5f)
						acaoAtual = new Perseguir();
					else 
						acaoAtual = new Atirar();
				}
				// se esta perto
				else {
					acaoAtual = new Atirar();
				}

			}
			// se esta invisivel
			else {
				acaoAtual = new Procurar();
			}
		}
		// se objetivo for sobreviver
		else 
		{
			if(_detector.estadoAtual == Estado.EmPerigo) {
				acaoAtual = new Fugir();
			}
			else if (_detector.estadoAtual == Estado.Seguro) {
				acaoAtual = new FazerNada();
			}
			else {
				if(Random.value > 0.66f) {
					acaoAtual = new Atirar();
				}
				else {
					acaoAtual = new Fugir();
				}
			}
		}
		print (acaoAtual);
	}
}
