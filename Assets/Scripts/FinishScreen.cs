using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishScreen : MonoBehaviour
{

    private int holeNum;

    public Text endText;

    public GameObject golfBall;

    public LineRenderer raycastLine;

    // Start is called before the first frame update
    void Start()
    {
        holeNum = GameManager.getHoleNumber();

        raycastLine.enabled = true;

        var turns = golfBall.GetComponent<BallController>().turns;

        endText.text = $"Course Over!\nStrokes: {turns}";
    }

    public void next()
    {

        var next = "";

        if (holeNum == 0)
            next = "MainMenu";
        else
            next = $"Hole_{holeNum + 1}";
        
        if (Application.CanStreamedLevelBeLoaded(next))
            SceneManager.LoadScene(next);
        else
            SceneManager.LoadScene("MainMenu");
    }
}
