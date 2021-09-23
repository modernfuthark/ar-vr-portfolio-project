using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    public static int[] Pars = new int[]{
        0, // Index 0 is 0, hole unused
        3,
        4,
        3
    };

    public static int getPar(int holeNumber)
    {
        return Pars[holeNumber];
    }

    public static int getHoleNumber()
    {
        var sceneName = SceneManager.GetActiveScene().name;

        string[] sceneNumber = sceneName.Split('_');

        if (sceneNumber != null)
        {
            return int.Parse(sceneNumber[1]);
        }
        return 0;
    }
}
