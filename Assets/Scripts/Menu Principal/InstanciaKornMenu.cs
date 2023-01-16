using UnityEngine;
using System.Collections;

public class InstanciaKornMenu : MonoBehaviour {

	public GameObject korn;
	Camera kornClone, kornMenu;
	Camera trigger_1, trigger_2, trigger_3, trigger_4;
	public bool instancia;

	void Start () {

		if (!instancia) {
			Canvas titulo = GameObject.Find ("Canvas Titulo").GetComponent<Canvas>();
			titulo.enabled = true;
			Instantiate (korn, transform.position, transform.rotation);
			kornClone = GameObject.Find ("Main Camera").GetComponent<Camera>();
			kornMenu = GameObject.Find ("CameraMenu").GetComponent<Camera> ();
			trigger_1 = GameObject.Find ("Camera_2_TriggerFollow").GetComponent<Camera>();
			trigger_2 = GameObject.Find ("Camera_1_Trigger").GetComponent<Camera> ();
			trigger_3 = GameObject.Find ("Camera_3_TriggerFollowFoot").GetComponent<Camera> ();
			trigger_4 = GameObject.Find ("CameraDifferent").GetComponent<Camera>();
			kornClone.enabled = false;
			kornMenu.enabled = true;
			trigger_1.enabled = false;
			trigger_2.enabled = false;
			trigger_3.enabled = false;
			trigger_4.enabled = false;
			instancia = true;
		}
	}
}
