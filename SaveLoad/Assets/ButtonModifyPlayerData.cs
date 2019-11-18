using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonModifyPlayerData : MonoBehaviour {

    public void IncreaseAttack()
    {
        gameController.gameControl.addAttack();
    }
    public void IncreaseDefense()
    {
        gameController.gameControl.addDefense();
    }
    public void IncreaseHealth()
    {
        gameController.gameControl.addHealth();
    }
}
