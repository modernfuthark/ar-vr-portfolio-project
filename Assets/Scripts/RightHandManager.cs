using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RightHandManager : MonoBehaviour
{
	private InputDevice controller;

    private XRDefaultActions dia;
    private bool gripValue;

    public GameObject golfClub;

	void Start()
	{
        dia = new XRDefaultActions();
        dia.Enable();

		var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
		UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        if (rightHandDevices.Count > 0)
		    controller = rightHandDevices[0];
        else
            Debug.Log("No right hand XR devices found.");

        dia.XRIRightHand.PrimaryButton.performed += (ctx) => {
            Debug.Log("Right hand primary");
        };

        dia.XRIRightHand.SecondaryButton.performed += ctx => {
            Debug.Log("Right hand secondary");
        };
	}

	void Update()
	{
		if (controller.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out gripValue) && gripValue)
		{
			if (!golfClub.activeSelf)
            {
                golfClub.SetActive(true);
            }
		}
        else
        {
            golfClub.SetActive(false);
        }
	}
}