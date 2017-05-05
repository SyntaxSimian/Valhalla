using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryManagerAgent
{
    static InventoryManager iManager;
    public static void SetManager(InventoryManager _iManager)
    {
        iManager = _iManager;
    }

    public static void Equip(string _armour, string _weapon)
    {
        iManager.EquipItem(_armour, _weapon);
    }
}
