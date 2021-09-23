using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftHandManager : MonoBehaviour
{
	private XRDefaultActions dia;

	public Text holeNum;
	public Text parNum;

	public bool paused = false;

	public GameObject GolfBall;


	void Start()
	{
		bool HasBall = false;
		dia = new XRDefaultActions();
		dia.Enable();

		var hn = GameManager.getHoleNumber();
		holeNum.text = $"Hole {hn}";
		parNum.text = $"Par: {GameManager.getPar(hn)}";

		dia.XRILeftHand.PrimaryButton.performed += ctx =>
		{
			if (GolfBall.GetComponent<BallController>().inTurn == false && GolfBall.GetComponent<BallController>().sinked == false)
			{
				if (!HasBall)
				{
					GolfBall.GetComponent<Rigidbody>().isKinematic = true;
					GolfBall.gameObject.transform.position = transform.position;
					GolfBall.gameObject.transform.SetParent(transform);
					HasBall = true;
				}
				else
				{
					GolfBall.GetComponent<Rigidbody>().isKinematic = false;
					GolfBall.gameObject.transform.SetParent(null, true);
					HasBall = false;
				}
			}
		};

		dia.XRILeftHand.MenuButton.performed += ctx =>
		{
			if (!paused)
			{
				paused = true;


			}
			else
			{
				paused = false;
			}
		};

		dia.XRILeftHand.SecondaryButton.performed += ctx =>
		{
			Debug.Log("Left hand secondary");
		};
	}
}
