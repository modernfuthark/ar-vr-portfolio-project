using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GolfBall")
        {
            other.GetComponent<BallController>().sinked = true;
            Debug.Log("Ball entered hole");
        }
    }
}
