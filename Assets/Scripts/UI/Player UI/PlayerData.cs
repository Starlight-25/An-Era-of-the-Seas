using System.Collections.Generic;
using JetBrains.Annotations;using UnityEngine;

public class PlayerData
{
    public string Pseudo;
    public int Level;
    public List<int?> Location;
    public Inventory Inventory;
}





public class Inventory
{
    public Equipped Equipped;
    public Backpack Backpack;
}









public class Equipped
{
    public Weapon Weapon;
    [ItemCanBeNull] public List<Stigma> Stigmata = new List<Stigma>();
    [CanBeNull] public Boat Boat;
    public Crew Crew;
}





public class Weapon
{
    [CanBeNull] public Sword Sword;
    [CanBeNull] public Firearm Firearm;
}

public class Sword
{
    public string Name;
    public string Rarity;
    public int Level;
}

public class Firearm
{
    public string Name;
    public string Rarity;
    public int Level;
    
}





public class Stigma
{
    public string Name;
    public string Rarity;
    public int Level;
}





public class Boat
{
    public string Name;
    public string Rarity;
    public int Level;
}





public class Crew
{
    [ItemCanBeNull] public List<Explorer> Explorer = new List<Explorer>();
    [ItemCanBeNull] public List<Navigator> Navigator = new List<Navigator>();
    [ItemCanBeNull] public List<Gunner> Gunner = new List<Gunner>();
    [ItemCanBeNull] public List<Boatswain> Boatswain = new List<Boatswain>();
}

public class Explorer
{
    public string Rarity;
    public int Level;
}

public class Navigator
{
    public string Rarity;
    public int Level;
}

public class Gunner
{
    public string Rarity;
    public int Level;
}

public class Boatswain
{    
    public string Rarity;
    public int Level;
}










public class Backpack
{
    public Materials Materials;
    public Weapons Weapons;
    [ItemCanBeNull] public List<Stigma> Stigmata = new List<Stigma>();
    [ItemCanBeNull] public List<Boat> Boats = new List<Boat>();
    public Crew Crew;
}




public class Materials
{
    public int Coins;
    public int PureWaterDrop;
    public int Wood;
    public int Steal;
}   




public class Weapons
{
    [ItemCanBeNull] public List<Sword> Swords = new List<Sword>();
    [ItemCanBeNull] public List<Firearm> Firearms = new List<Firearm>();
}