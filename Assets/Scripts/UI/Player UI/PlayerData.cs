using System.Collections.Generic;

public class PlayerData
{
    public string Pseudo;
    public int Level;
    public (int x, int y, int z) Location;
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
    public List<Stigma> Stigmata;
    public Boat Boat;
    public Crew Crew;
}





public class Weapon
{
    public Sword Sword;
    public Firearm Firearm;
}

public class Sword
{
    
}

public class Firearm
{
    
}





public class Stigma
{
    
}





public class Boat
{

}





public class Crew
{
    public List<Explorer> Explorer;
    public List<Navigator> Navigator;
    public List<Gunner> Gunner;
    public List<Boatswain> Boatswain;
}

public class Explorer
{
    
}

public class Navigator
{
    
}

public class Gunner
{
    
}

public class Boatswain
{
    
}















public class Backpack
{
    public Materials Materials;
    public Weapons Weapons;
    public List<Stigma> Stigmata;
    public List<Boat> Boats;
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
    public List<Sword> Swords;
    public List<Firearm> Firearms;
}