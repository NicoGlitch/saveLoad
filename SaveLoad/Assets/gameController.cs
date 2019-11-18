using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class gameController : MonoBehaviour {
    public static gameController gameControl;

    public int attack;
    public int defense;
    public int health;
    public List<weapon> myWeapon;
    public static int listeIndex;
    void Start () {

        if (gameControl == null)
        {
            DontDestroyOnLoad(gameObject);
            gameControl = this;
            SetDefaultValues();
        }
        else
        {
            Destroy(gameControl);
        }
    }

    public void addWeapon()
    {   
        weapon NewWeapon = new weapon();
        NewWeapon.WeaponAttack = 1;
        myWeapon.Add(NewWeapon);
        listeIndex++;
        print("addweapon");
    }
    public void addWeaponDamage()
    {
        print(listeIndex);
        myWeapon[listeIndex].WeaponAttack++;
        print("addweaponDamage");
    }
    public void SetDefaultValues()
    {
        attack = 1;
        defense = 1;
        health = 1;
        listeIndex = -1;
        myWeapon = new List<weapon>();
    }
    public void addAttack()
    {
        attack++;
    }
    public void addDefense()
    {
        defense++;
    }
    public void addHealth()
    {
        health++;
    }
    public void load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "gameInfo.dat"))
        {
            throw new Exception("Game file not found !");
        }
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat", FileMode.Open);
        PlayerData playerDataToLoad = (PlayerData)bf.Deserialize(file);
        
   
        file.Close();
        attack = playerDataToLoad.attack;
        defense = playerDataToLoad.defense;
        health = playerDataToLoad.health;
        myWeapon = playerDataToLoad.myWeapon;
    }

    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat", FileMode.Create);
        PlayerData playerDataToSave = new PlayerData();
        playerDataToSave.attack = attack;
        playerDataToSave.defense= defense;
        playerDataToSave.health= health;

        List<weapon> weaponToSave = new List<weapon>();

        playerDataToSave.myWeapon = myWeapon;

        bf.Serialize(file, playerDataToSave);
        file.Close();

    }
    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 180, 80),"Attack: " + attack, style);
        GUI.Label(new Rect(10, 110, 180, 80), "Defense: " + defense, style);
        GUI.Label(new Rect(10, 160, 180, 80), "Health: " + health, style);
        if(myWeapon.Count != 0)
        {
        GUI.Label(new Rect(10, 210, 180, 80), "Weapon: " + myWeapon[listeIndex].WeaponAttack, style);
        }
    }
    public void NextWeapon()
    {
        if (listeIndex >= myWeapon.Count-1)
        {
            listeIndex = 0;
        }
        else
        {
            listeIndex++;
        }
        print("NextWeapon");
    }
    public void previousWeapon()
    {
        if (listeIndex == 0)
        {
            listeIndex = myWeapon.Count -1;
        }
        else
        {
            listeIndex--;
        }
        print("Previousweapon");
    }


}


[Serializable]
class PlayerData
{
    public int attack;
    public int defense;
    public int health;
    public List<weapon> myWeapon;
}
[Serializable]
public class weapon
{
    public int WeaponAttack;
}