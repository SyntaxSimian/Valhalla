using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomizationManager : MonoBehaviour
{

	void Start ()
    {
        partSelected = false;
	}

    bool partSelected;
    string ShipPart;
    public void SelectShipPart(string part)
    {
        partSelected = true;
        ShipPart = part;
    }

    public void AssignItem(GameObject listObject)
    {
        InventoryManagerAgent.Equip("", listObject.GetComponent<EquipMenuListItem>().GetOption());
        listObject.GetComponent<EquipMenuListItem>().UpdateDisplayAmount();
    }
}
