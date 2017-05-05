using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class InventoryManager : MonoBehaviour
{
    public GameObject contentField;
    public GameObject sampleTextObj;

    Vector3 itemLocalPos;

    List<string> inventory = new List<string>();
    
    int zeroToZed;

    string ItemDbConnectPath = Application.dataPath + "ItemDatabase.db";
    IDbConnection dbConnection;
    
    private void connectDatabases()
    {
        dbConnection = (IDbConnection)new SqliteConnection(ItemDbConnectPath);
        dbConnection.Open();

        dbConnection.Close();
    }



	void Start ()
    {
        connectDatabases();
        #region Set Default Weapon
        CharacterSheet.Weapon w = new CharacterSheet.Weapon("pea shooter", 1);
        CharacterSheet.Weapon[] wa = new CharacterSheet.Weapon[1];
        wa[0] = w;
        CharacterSheet.SetCharacter(wa);
        #endregion

        PlayerPrefs.SetInt("item1", 2); PlayerPrefs.SetInt("item2", 6); PlayerPrefs.SetInt("item3", 3); PlayerPrefs.SetInt("item4", 5);
        inventory.Add("item1"); inventory.Add("item2"); inventory.Add("item3"); inventory.Add("item4");

        for (int n = inventory.Count; n > 0; n--)
        {
            zeroToZed = n - inventory.Count;
            GameObject e = new GameObject("item");
            GameObject t = Instantiate(sampleTextObj);

            t.GetComponent<Text>().text = PlayerPrefs.GetInt("item" + ((zeroToZed - 1) * -1)) + "| " + "item" + ((zeroToZed - 1) * -1);
            t.GetComponent<EquipMenuListItem>().SetOption("item" + ((zeroToZed - 1) * -1));

            itemLocalPos.x = t.GetComponent<Text>().preferredWidth / 1.8f;
            itemLocalPos.y = (t.GetComponent<Text>().preferredHeight * zeroToZed) - (t.GetComponent<Text>().preferredHeight / 2);

            t.transform.localPosition = itemLocalPos;
            t.transform.SetParent(e.transform, false);
            e.transform.SetParent(contentField.transform, false);
            e.transform.localPosition = new Vector3(0, 0, 0);
        }
        InventoryManagerAgent.SetManager(gameObject.GetComponent<InventoryManager>());
    }
	
	public void EquipItem(string armor, string weapon)
    {
        if(weapon != null)
        {
            foreach(string s in inventory)
            {
                if(s == weapon)
                {
                    if (s != CharacterSheet.GetWeapon0Name())
                    {
                        CharacterSheet.Weapon w = new CharacterSheet.Weapon(weapon, 15);
                        CharacterSheet.Weapon[] wa = new CharacterSheet.Weapon[1];
                        wa[0] = w;
                        CharacterSheet.SetCharacter(wa);
                        PlayerPrefs.SetInt(s, PlayerPrefs.GetInt(s) - 1);
                    }
                    break;
                }
            }
        }
        if (armor != null)
        {

        }
    }
}