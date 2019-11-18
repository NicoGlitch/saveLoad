using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponcontrole : MonoBehaviour {

    public void nextWeapon()
    {
        gameController.gameControl.NextWeapon();
    }
    public void previousWeapon()
    {
        gameController.gameControl.previousWeapon();
    }
    public void AddWeapon()
    {
        gameController.gameControl.addWeapon();
    }
    public void AddWeaponDamage()
    {
        gameController.gameControl.addWeaponDamage();
    }
}
