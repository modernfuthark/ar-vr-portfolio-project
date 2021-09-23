using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class BallController : MonoBehaviour
{
	public Canvas endScreen;

	public GameObject loco;

	private bool over = false;

	private Vector3 lastPos;

	public bool inMotion = false;
	public bool inTurn = false;

	public GameObject golfClub;

	public bool sinked = false;

	public Text turnsText;

	public int turns = 0;

	// Update is called once per frame
	void Update()
	{
		if (sinked == true && over == false)
		{
			endRound();
			over = true;
		}
		if (gameObject.GetComponent<Rigidbody>().isKinematic == false && sinked == false && over == false)
		{
			inMotion = !gameObject.GetComponent<Rigidbody>().IsSleeping();

			if (gameObject.GetComponent<Rigidbody>().velocity.magnitude < .1f && inMotion && golfClub.activeSelf == false)
			{
				gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				gameObject.GetComponent<Rigidbody>().Sleep();
			}

			if (turns == 12 && !inMotion && !inTurn)
			{
				endRound();
				over = true;
			}

			if (inMotion && !inTurn)
			{
				inTurn = true;
				turns++;
				turnsText.text = $"Strokes: {turns}";
			}

			if (!inMotion && inTurn)
			{
				lastPos = gameObject.transform.position;
				inTurn = false;
			}

			if (gameObject.transform.position.y < -2)
			{
				gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				gameObject.transform.position = lastPos;
			}
		}
	}

	public void endRound()
	{
		endScreen.gameObject.SetActive(true);
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
		sinked = true;
		over = true;
	}
}
