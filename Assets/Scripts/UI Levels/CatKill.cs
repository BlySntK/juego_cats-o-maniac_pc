using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CatKill : MonoBehaviour {

	GameObject text_1, text_target;
	VariablesGlobales vars;
	HardLevels motor, _nextLevel;
	NormalLevels _motor, nextLevel;
	EasyLevels motor_, nextLevel_;

	

	void Update () {

		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		Temporizador tempoLevel = GameObject.Find ("Timer").GetComponent<Temporizador> ();
		if (vars.d_normal) {
			nextLevel = GameObject.Find ("JuegoGeneral").GetComponent<NormalLevels> ();
			if (over.end || nextLevel.n_cats >= nextLevel.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				GameObject labelCat = GameObject.Find ("CATS KILL");
				GameObject labelCat_ = GameObject.Find ("EliminarAEstos");
				GameObject laBelCat = GameObject.Find ("ObjetivosAEliminar");
				Text laBelCat_ = laBelCat.GetComponent<Text> ();
				Text _labelCat_ = labelCat_.GetComponent<Text> ();
				Image _labelCat = labelCat.GetComponent<Image> ();
				_labelCat.enabled = false;
				_labelCat_.enabled = false;
				laBelCat_.enabled = false;
				text_1 = GameObject.Find ("Kills");
				Text text_1_ = text_1.GetComponent<Text>();
				text_1_.enabled = false;
			}
		}else if (vars.d_easy) {
			nextLevel_ = GameObject.Find ("JuegoGeneral").GetComponent<EasyLevels> ();
			if (over.end || nextLevel_.n_cats >= nextLevel_.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				GameObject labelCat = GameObject.Find ("CATS KILL");
				GameObject labelCat_ = GameObject.Find ("EliminarAEstos");
				GameObject laBelCat = GameObject.Find ("ObjetivosAEliminar");
				Text laBelCat_ = laBelCat.GetComponent<Text> ();
				Text _labelCat_ = labelCat_.GetComponent<Text> ();
				Image _labelCat = labelCat.GetComponent<Image> ();
				_labelCat.enabled = false;
				_labelCat_.enabled = false;
				laBelCat_.enabled = false;
				text_1 = GameObject.Find ("Kills");
				Text text_1_ = text_1.GetComponent<Text>();
				text_1_.enabled = false;
			}
		}else if (vars.d_hard) {
			_nextLevel = GameObject.Find ("JuegoGeneral").GetComponent<HardLevels> ();
			if (over.end || _nextLevel.n_cats >= _nextLevel.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				GameObject labelCat = GameObject.Find ("CATS KILL");
				GameObject labelCat_ = GameObject.Find ("EliminarAEstos");
				GameObject laBelCat = GameObject.Find ("ObjetivosAEliminar");
				Text laBelCat_ = laBelCat.GetComponent<Text> ();
				Text _labelCat_ = labelCat_.GetComponent<Text> ();
				Image _labelCat = labelCat.GetComponent<Image> ();
				_labelCat.enabled = false;
				_labelCat_.enabled = false;
				laBelCat_.enabled = false;
				text_1 = GameObject.Find ("Kills");
				Text text_1_ = text_1.GetComponent<Text>();
				text_1_.enabled = false;
			}
		}
	}

	public void Contador (long kill) {

		text_1 = GameObject.Find ("Kills");
		Text text_1_ = text_1.GetComponent<Text>();
		text_1_.text = kill.ToString ();

		//Dependiendo de la dificultad:
		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		if (vars.d_hard) {
			motor = GameObject.Find ("JuegoGeneral").GetComponent<HardLevels> ();
			motor.n_cats = kill;
		}else if (vars.d_easy) {
			motor_ = GameObject.Find ("JuegoGeneral").GetComponent<EasyLevels> ();
			motor_.n_cats = kill;
		}else if (vars.d_normal) {
			_motor = GameObject.Find ("JuegoGeneral").GetComponent<NormalLevels> ();
			_motor.n_cats = kill;
		}
		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		vars.n_cats = kill;
	}

	public void Targets (long target) {

		text_target = GameObject.Find ("EliminarAEstos");
		Text _text_target = text_target.GetComponent<Text> ();
		_text_target.text = target.ToString ();
	}
}
