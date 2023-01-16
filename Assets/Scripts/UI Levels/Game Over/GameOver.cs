using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	public bool end;
	Temporizador tempo;
	GameObject texto;
	NormalLevels motor;
	EasyLevels _motor;
	HardLevels motor_;


	void Update () {

		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		tempo = GameObject.Find ("Timer").GetComponent<Temporizador> ();

		if (vars.d_normal) {
			motor = GameObject.Find ("JuegoGeneral").GetComponent<NormalLevels> ();
			if (tempo.timeLeft <= 0) {
				if (motor.n_cats < motor.maxCatsKills) {
					end = true;
					tempo.begingCountdown = false;
				}
			}
		}else if (vars.d_easy) {
			_motor = GameObject.Find ("JuegoGeneral").GetComponent<EasyLevels> ();
			if (tempo.timeLeft <= 0) {
				if (_motor.n_cats < _motor.maxCatsKills) {
					end = true;
					tempo.begingCountdown = false;
				}
			}
		}else if (vars.d_hard) {
			motor_ = GameObject.Find ("JuegoGeneral").GetComponent<HardLevels> ();
			if (tempo.timeLeft <= 0) {
				if (motor_.n_cats < motor_.maxCatsKills) {
					end = true;
					tempo.begingCountdown = false;
				}
			}
		}

		if (end) {
			texto = this.gameObject;
			Text _texto = texto.GetComponent<Text> ();
			_texto.enabled = true;
		}else{
			texto = this.gameObject;
			Text _texto = texto.GetComponent<Text> ();
			_texto.enabled = false;
		}
	}
}
