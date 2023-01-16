using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cancion : MonoBehaviour {
	
	Text _labelSong; //Variable texto de la cancion
	RectTransform label_song; //Variable transform imagen reproductor
	GameObject labelSong; //Variable GameObject reproductor
	Image labelSong_; //Variable imagen reproductor
	GameObject label_Song; // Variable titulo de la cancion
	float posX;
	float posXMin = 303.75f;
	float posXMax = 539;
	float posY = -48, posZ = 0;
	float speed = 150;
	float timeWait = 4;
	bool turn;
	[HideInInspector]
	public bool nuevaCancion; //Variable manejada en Musica
	[HideInInspector]
	public AudioSource _song; //Variable manejada en Musica
	[HideInInspector]
	public AudioSource __song; //Variable manejada en Musica
	[HideInInspector]
	public AudioSource ___song; //Variable manejada en Musica
	HardLevels nextLevel;
	NormalLevels _nextLevel;
	EasyLevels nextLevel_;

	void Awake () {
		_song = GameObject.Find ("PatrollCamera").GetComponent<AudioSource> ();
		__song = GameObject.Find ("PatrollCamera_lvl2").GetComponent<AudioSource> ();
		___song = GameObject.Find ("PatrollCamera_lvl3").GetComponent<AudioSource> ();
		labelSong = this.gameObject;
		label_Song = GameObject.Find ("TituloCancion");
		label_song = labelSong.GetComponent<RectTransform> ();
		posX = posXMax;
		label_song.localPosition = new Vector3 (posX, posY, posZ);
	}

	void Update () {
		
		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		if (vars.d_hard) {
			nextLevel = GameObject.Find ("JuegoGeneral").GetComponent<HardLevels> ();
			Temporizador tempoLevel = GameObject.Find ("Timer").GetComponent<Temporizador> ();
			_song = GameObject.Find ("PatrollCamera").GetComponent<AudioSource> ();
			__song = GameObject.Find ("PatrollCamera_lvl2").GetComponent<AudioSource> ();
			___song = GameObject.Find ("PatrollCamera_lvl3").GetComponent<AudioSource> ();

			if (over.end || nextLevel.n_cats > nextLevel.maxCatsKills && tempoLevel.timeLeft <= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				_labelSong = label_Song.GetComponent<Text> ();
				_labelSong.enabled = false;
				labelSong_ = labelSong.GetComponent<Image> ();
				labelSong_.enabled = false;
			}else{
				if (nuevaCancion) {
					Text newText = label_Song.GetComponent<Text> ();
					if (vars.level == 5 && _song.clip != null)
						newText.text = _song.clip.name;
					if (vars.level == 8 && __song.clip != null)
						newText.text = __song.clip.name;
					if (vars.level == 11 && ___song.clip != null)
						newText.text = ___song.clip.name;

					if (vars.level == 5) {
						posXMin = 303.75f; 
						if (posX > posXMin && !turn) {
							posX -= speed * Time.deltaTime;
							label_song.localPosition = new Vector3 (posX, posY, posZ);
						}else if (posX <= posXMin && !turn)
							turn = true;

						if (timeWait > 0 && turn)
							timeWait -= Time.deltaTime;
						else{
							posXMax = 539;
							if (posX < posXMax && turn) {
								posX += speed * Time.deltaTime;
								label_song.localPosition = new Vector3 (posX, posY, posZ);
							}else if (posX >= posXMax && turn) {
								nuevaCancion = false;
								turn = false;
								timeWait = 10;
							}
						}
					}else if (vars.level == 8) {
						posXMin = 338;
						if (posX > posXMin && !turn) {
							posX -= speed * Time.deltaTime;
							label_song.localPosition = new Vector3 (posX, posY, posZ);
						}else if (posX <= posXMin && !turn)
							turn = true;
						
						if (timeWait > 0 && turn)
							timeWait -= Time.deltaTime;
						else{
							posXMax = 539;
							if (posX < posXMax && turn) {
								posX += speed * Time.deltaTime;
								label_song.localPosition = new Vector3 (posX, posY, posZ);
							}else if (posX >= posXMax && turn) {
								nuevaCancion = false;
								turn = false;
								timeWait = 10;
							}
						}
					}else if (vars.level == 11) {
						posXMin = 338;
						if (posX > posXMin && !turn) {
							posX -= speed * Time.deltaTime;
							label_song.localPosition = new Vector3 (posX, posY, posZ);
						}else if (posX <= posXMin && !turn)
							turn = true;
						
						if (timeWait > 0 && turn)
							timeWait -= Time.deltaTime;
						else{
							posXMax = 539;
							if (posX < posXMax && turn) {
								posX += speed * Time.deltaTime;
								label_song.localPosition = new Vector3 (posX, posY, posZ);
							}else if (posX >= posXMax && turn) {
								nuevaCancion = false;
								turn = false;
								timeWait = 10;
							}
						}
					}
				}
			}
		}else if (vars.d_easy) {
			nextLevel_ = GameObject.Find ("JuegoGeneral").GetComponent<EasyLevels> ();
			Temporizador tempoLevel = GameObject.Find ("Timer").GetComponent<Temporizador> ();
			_song = GameObject.Find ("PatrollCamera").GetComponent<AudioSource> ();
			__song = GameObject.Find ("PatrollCamera_lvl2").GetComponent<AudioSource> ();
			___song = GameObject.Find ("PatrollCamera_lvl3").GetComponent<AudioSource> ();
			
			if (over.end || nextLevel_.n_cats > nextLevel_.maxCatsKills && tempoLevel.timeLeft <= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				_labelSong = label_Song.GetComponent<Text> ();
				_labelSong.enabled = false;
				labelSong_ = labelSong.GetComponent<Image> ();
				labelSong_.enabled = false;
			}else{
				if (nuevaCancion) {
					Text newText = label_Song.GetComponent<Text> ();
					if (vars.level == 4 && _song.clip != null)
						newText.text = _song.clip.name;
					if (vars.level == 7 && __song.clip != null)
						newText.text = __song.clip.name;
					if (vars.level == 10 && ___song.clip != null)
						newText.text = ___song.clip.name;
					
					if (vars.level == 4) {
						posXMin = 303.75f; 
						if (posX > posXMin && !turn) {
							posX -= speed * Time.deltaTime;
							label_song.localPosition = new Vector3 (posX, posY, posZ);
						}else if (posX <= posXMin && !turn)
							turn = true;
						
						if (timeWait > 0 && turn)
							timeWait -= Time.deltaTime;
						else{
							posXMax = 539;
							if (posX < posXMax && turn) {
								posX += speed * Time.deltaTime;
								label_song.localPosition = new Vector3 (posX, posY, posZ);
							}else if (posX >= posXMax && turn) {
								nuevaCancion = false;
								turn = false;
								timeWait = 10;
							}
						}
					}else if (vars.level == 7) {
						posXMin = 338;
						if (posX > posXMin && !turn) {
							posX -= speed * Time.deltaTime;
							label_song.localPosition = new Vector3 (posX, posY, posZ);
						}else if (posX <= posXMin && !turn)
							turn = true;
						
						if (timeWait > 0 && turn)
							timeWait -= Time.deltaTime;
						else{
							posXMax = 539;
							if (posX < posXMax && turn) {
								posX += speed * Time.deltaTime;
								label_song.localPosition = new Vector3 (posX, posY, posZ);
							}else if (posX >= posXMax && turn) {
								nuevaCancion = false;
								turn = false;
								timeWait = 10;
							}
						}
					}else if (vars.level == 10) {
						posXMin = 338;
						if (posX > posXMin && !turn) {
							posX -= speed * Time.deltaTime;
							label_song.localPosition = new Vector3 (posX, posY, posZ);
						}else if (posX <= posXMin && !turn)
							turn = true;
						
						if (timeWait > 0 && turn)
							timeWait -= Time.deltaTime;
						else{
							posXMax = 539;
							if (posX < posXMax && turn) {
								posX += speed * Time.deltaTime;
								label_song.localPosition = new Vector3 (posX, posY, posZ);
							}else if (posX >= posXMax && turn) {
								nuevaCancion = false;
								turn = false;
								timeWait = 10;
							}
						}
					}
				}
			}
		}else if (vars.d_normal) {
			_nextLevel = GameObject.Find ("JuegoGeneral").GetComponent<NormalLevels> ();
			Temporizador tempoLevel = GameObject.Find ("Timer").GetComponent<Temporizador> ();
			_song = GameObject.Find ("PatrollCamera").GetComponent<AudioSource> ();
			__song = GameObject.Find ("PatrollCamera_lvl2").GetComponent<AudioSource> ();
			___song = GameObject.Find ("PatrollCamera_lvl3").GetComponent<AudioSource> ();
			
			if (over.end || _nextLevel.n_cats > _nextLevel.maxCatsKills && tempoLevel.timeLeft <= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				_labelSong = label_Song.GetComponent<Text> ();
				_labelSong.enabled = false;
				labelSong_ = labelSong.GetComponent<Image> ();
				labelSong_.enabled = false;
			}else{
				if (nuevaCancion) {
					Text newText = label_Song.GetComponent<Text> ();
					if (vars.level == 3 && _song.clip != null)
						newText.text = _song.clip.name;
					if (vars.level == 6 && __song.clip != null)
						newText.text = __song.clip.name;
					if (vars.level == 9 && ___song.clip != null)
						newText.text = ___song.clip.name;
					
					if (vars.level == 3) {
						posXMin = 303.75f; 
						if (posX > posXMin && !turn) {
							posX -= speed * Time.deltaTime;
							label_song.localPosition = new Vector3 (posX, posY, posZ);
						}else if (posX <= posXMin && !turn)
							turn = true;
						
						if (timeWait > 0 && turn)
							timeWait -= Time.deltaTime;
						else{
							posXMax = 539;
							if (posX < posXMax && turn) {
								posX += speed * Time.deltaTime;
								label_song.localPosition = new Vector3 (posX, posY, posZ);
							}else if (posX >= posXMax && turn) {
								nuevaCancion = false;
								turn = false;
								timeWait = 10;
							}
						}
					}else if (vars.level == 6) {
						posXMin = 338;
						if (posX > posXMin && !turn) {
							posX -= speed * Time.deltaTime;
							label_song.localPosition = new Vector3 (posX, posY, posZ);
						}else if (posX <= posXMin && !turn)
							turn = true;
						
						if (timeWait > 0 && turn)
							timeWait -= Time.deltaTime;
						else{
							posXMax = 539;
							if (posX < posXMax && turn) {
								posX += speed * Time.deltaTime;
								label_song.localPosition = new Vector3 (posX, posY, posZ);
							}else if (posX >= posXMax && turn) {
								nuevaCancion = false;
								turn = false;
								timeWait = 10;
							}
						}
					}else if (vars.level == 9) {
						posXMin = 338;
						if (posX > posXMin && !turn) {
							posX -= speed * Time.deltaTime;
							label_song.localPosition = new Vector3 (posX, posY, posZ);
						}else if (posX <= posXMin && !turn)
							turn = true;
						
						if (timeWait > 0 && turn)
							timeWait -= Time.deltaTime;
						else{
							posXMax = 539;
							if (posX < posXMax && turn) {
								posX += speed * Time.deltaTime;
								label_song.localPosition = new Vector3 (posX, posY, posZ);
							}else if (posX >= posXMax && turn) {
								nuevaCancion = false;
								turn = false;
								timeWait = 10;
							}
						}
					}
				}
			}
		}
	}
}
