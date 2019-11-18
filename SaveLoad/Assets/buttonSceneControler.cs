using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSceneControler : MonoBehaviour {

	public void NextScene()
    {
        sceneControler.sceneControl.nextScene();
    }
    public void PreviousScene()
    {
        sceneControler.sceneControl.previousScene();
    }
}
