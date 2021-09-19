using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
	public bool inMotion = false;
	public bool inTurn = false;

    public GameObject golfClub;

	public bool sinked = false;

	public Text turnsText;

	public int turns = 0;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (gameObject.GetComponent<Rigidbody>().isKinematic == false && sinked == false)
		{
			inMotion = !gameObject.GetComponent<Rigidbody>().IsSleeping();

            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude < .1f && inMotion && golfClub.activeSelf == false)
            {
                Debug.Log("Stopping ball...");
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().Sleep();
            }

			if (turns == 12 && !inMotion && !inTurn)
			{
				Debug.Log("End game");
			}

			if (inMotion && !inTurn)
			{
				Debug.Log("Moving, not in turn");
				inTurn = true;
				turns++;
				turnsText.text = $"Strokes: {turns}";
			}

			if (!inMotion && inTurn)
			{
				Debug.Log("Not moving, in turn");
				inTurn = false;
			}
		}
	}
}
