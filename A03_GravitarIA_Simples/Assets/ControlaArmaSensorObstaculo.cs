using UnityEngine;
using System.Collections;

public class ControlaArmaSensorObstaculo : ControlaArmaAutomatico
{
	public float raioSensor;
	public LayerMask camadasDetectadas;

	void Update()
	{
		timer += Time.deltaTime;

		Vector3 direcaoAlvo = alvo.position - transform.position;
		RaycastHit2D resultado = Physics2D.Raycast(
			transform.position,
			direcaoAlvo,
			raioSensor,
			camadasDetectadas);

		Debug.DrawRay(transform.position, direcaoAlvo, Color.yellow);
		print(resultado.transform.name);

		if (timer > frequencia && alvo != null && 
			resultado.transform == alvo.transform) {
			timer = 0;
			Vector2 distanciaParaAlvo = Random.insideUnitCircle * 
				margemErro;
			Vector3 erro = alvo.position + new Vector3(
				distanciaParaAlvo.x,
				distanciaParaAlvo.y);
			Vector3 mira = erro - transform.position;
			transform.GetComponent<Arma>().Disparar(mira.normalized);
		}
	}
}
