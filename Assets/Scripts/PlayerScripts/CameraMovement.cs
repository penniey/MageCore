using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] Camera playerCam;
	[SerializeField] Transform player;
	[SerializeField] float threshold;

	private void Update()
	{
		Vector3 mousePos = playerCam.ScreenToWorldPoint(Input.mousePosition); //Hittar muspositionen
		Vector3 targetPos = (player.position + mousePos) / 2f; //"Ritar" en linje dit mousePos �r

		targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.position.x, threshold + player.position.x); //Hittar positionen f�r x,y beroende p� begr�nsningen
		targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.position.y, threshold + player.position.y);

		this.transform.position = targetPos; //S�tter kamerapositionen till muspekaren
	}
}
