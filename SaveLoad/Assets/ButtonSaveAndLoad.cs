using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSaveAndLoad : MonoBehaviour {

    public void Save()
    {
        gameController.gameControl.save();
    }
    public void Load()
    {
        gameController.gameControl.load();
    }
}
