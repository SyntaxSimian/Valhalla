using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterSheet
{
    public class Weapon
    {
        string name;
        int damagePerHit;
        public Weapon(string _name, int _damage)
        {
            name = _name;
            damagePerHit = _damage;
        }

        public int getDamage() { return damagePerHit; }
        public string getName() { return name; }
    }

    public static void SetCharacter(Weapon[] _weapons) { weapons = _weapons; }

    public static void SetCharacter(int _maxHealth)
    {
        MaxHealth = _maxHealth;
        CurrentHealth = _maxHealth;
    }
    
    public static string GetWeapon0Name() { return weapons[0].getName(); }
    public static int GetWeapon0Damage() { return weapons[0].getDamage(); }

    //core stats
    static int MaxHealth, CurrentHealth;
    static int MaxArmour, CurrentArmour;
    static int MaxPower, CurrentPower;
    static int MaxHeat, CurrentHeat;
    static Weapon[] weapons;
}