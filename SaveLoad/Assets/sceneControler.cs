using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneControler : MonoBehaviour {

    public static sceneControler sceneControl;

    private void Start()
    {
        if (sceneControl == null)
        {
            DontDestroyOnLoad(gameObject);
            sceneControl = this;
        }
        else
        {
            Destroy(sceneControl);
        }
    }
    public void nextScene()
    {
        if (SceneManager.sceneCountInBuildSettings-1 > SceneManager.GetActiveScene().buildIndex)
        {
            print("Loeading " + (SceneManager.GetActiveScene().buildIndex +1));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else
        {
            print("Error, cannot load next scene ; This is the last scene");
        }
    }
    public void previousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex !=0)
        {
            print("Loeading " + (SceneManager.GetActiveScene().buildIndex - 1));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            print("Error, cannot load previous scene ; This is the first scene");
        }
    }
    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 56;
        GUI.Label(new Rect(10,10,180,80), "Active Scene : " + SceneManager.GetActiveScene().buildIndex, style);
    }

}
