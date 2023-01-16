using UnityEngine;
using System.Collections;

public class RespawnPlayer : MonoBehaviour {

	public GameObject _player;
	const int N_PLAYER = 1;
	[HideInInspector]
	public int player = 0;
	public float posX, posY, posZ; //Variables manejadas en NormalLevels
	public float rotateY = 75.19f; // ""		""			""
	[HideInInspector]
	public bool respawnPlayer; //Variable manejada por NormalLevels
	Quaternion rotacion;


	void Update () {

		VariablesGlobales currentLevel = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		if (currentLevel.level == 3 || currentLevel.level == 4 || currentLevel.level == 5) {
			if (respawnPlayer) {
				if (player < N_PLAYER) {
					Vector3 posiciones = new Vector3 (posX, posY, posZ);
					rotacion.eulerAngles = new Vector3 (0, rotateY, 0);
					Instantiate (_player, posiciones, rotacion);
					player++;
					respawnPlayer = false;
				}
			}
		}else if (currentLevel.level == 6 || currentLevel.level == 7 || currentLevel.level == 8) {
			if (respawnPlayer) {
				if (player < N_PLAYER) {
					Vector3 posiciones = new Vector3 (posX, posY, posZ);
					rotacion.eulerAngles = new Vector3 (0, rotateY, 0);
					Instantiate (_player, posiciones, rotacion);
					player++;
					respawnPlayer = false;
				}
			}
		}else if (currentLevel.level == 9 || currentLevel.level == 10 || currentLevel.level == 11) {
			if (respawnPlayer) {
				if (player < N_PLAYER) {
					Vector3 posiciones = new Vector3 (posX, posY, posZ);
					rotacion.eulerAngles = new Vector3 (0, rotateY, 0);
					Instantiate (_player, posiciones, rotacion);
					player++;
					respawnPlayer = false;
				}
			}
		}
	}
}
