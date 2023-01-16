using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mira : MonoBehaviour {

	VariablesGlobales vars;
	HardLevels nextLevel;
	NormalLevels _nextLevel;
	EasyLevels nextLevel_;


	void Update () {
		
		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		Temporizador tempoLevel = GameObject.Find ("Timer").GetComponent<Temporizador> ();

		if (vars.d_hard) {
			nextLevel = GameObject.Find ("JuegoGeneral").GetComponent<HardLevels> ();
			if (over.end || nextLevel.n_cats >= nextLevel.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos la mira de la escopeta si hay un Game Over
				GameObject labelMira = GameObject.Find ("Mira");
				Image _labelMira = labelMira.GetComponent<Image> ();
				_labelMira.enabled = false;
			}
		}else if (vars.d_easy) {
			nextLevel_ = GameObject.Find ("JuegoGeneral").GetComponent<EasyLevels> ();
			if (over.end || nextLevel_.n_cats >= nextLevel_.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos la mira de la escopeta si hay un Game Over
				GameObject labelMira = GameObject.Find ("Mira");
				Image _labelMira = labelMira.GetComponent<Image> ();
				_labelMira.enabled = false;
			}
		}else if (vars.d_normal) {
			_nextLevel = GameObject.Find ("JuegoGeneral").GetComponent<NormalLevels> ();
			if (over.end || _nextLevel.n_cats >= _nextLevel.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos la mira de la escopeta si hay un Game Over
				GameObject labelMira = GameObject.Find ("Mira");
				Image _labelMira = labelMira.GetComponent<Image> ();
				_labelMira.enabled = false;
			}
		}
	}
}
