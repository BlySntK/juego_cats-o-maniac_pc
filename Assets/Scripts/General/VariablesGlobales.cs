using UnityEngine;
using System.Collections;

public class VariablesGlobales : MonoBehaviour {

	public bool street;
	public bool parking;
	public bool park;

	public bool d_easy;
	public bool d_hard;
	public bool d_normal;

	public int level;
	public bool introduccion;
	public float currentTime;
	public int puntos;
	public int n_balas;
	public long n_cats;
	public bool carga_completa;
	public float posXPlayer, posYPlayer, posZPlayer;



	void Awake () {
		
		DontDestroyOnLoad (gameObject);
	}
}
