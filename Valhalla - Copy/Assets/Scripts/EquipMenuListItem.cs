using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipMenuListItem : MonoBehaviour
{
    private string option;
    public void SetOption(string _string)
    {
        option = _string;
    }

    public string GetOption()
    {
        return option;
    }

    public void UpdateDisplayAmount()
    {
        char[] caDisplay = option.ToCharArray();
        SetOption("item" + (caDisplay[4]));
        gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("item" + (caDisplay[4])) + "| " + option;
    }
}
