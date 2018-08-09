using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Stat { Strength, Mind, Agility };

public enum Resource { Fuel, Shields, Medicine };

public enum LocationState { Space, Land };
//This class holds all kind of data about the game
//There are a bunch of functions and data creation that needs to be moved here
public class GameData : MonoBehaviour {
    public List<string> characterStatNames = new List<string> { "Strength", "Agility", "Mind" };
    public List<string> resourceNames = new List<string> { "Fuel", "Ammo" };
    public static GameData instance;
    public Character player1;
    public List<Character> party = new List<Character>();
    public static int characterIndex;
    public Sprite defaultEventSprite = null;
    public Dictionary<string, Trait> traitDictionary;
    public Dictionary<string, Sprite> eventSpriteDictionary;
    public Dictionary<string, Sprite> characterPortraitDictionary;
    public Dictionary<string, Module> modulePrototypes;
    //public Dictionary<string, Enemy> enemyDictionary;
    public Dictionary<int, string> names;
    List<string> enemyKeyList;
    List<string> shipNames;


    public List<Situation> situationPrototypes;
    public Situation shipBattle;

    public List<string> races, genders;
    // Use this for initialization
    void Awake () {
        if (instance == null)
        {
            //...set this one to be it...
            instance = this;
            DontDestroyOnLoad(gameObject);
            //...otherwise...
        }
        else if (instance != this)
        {
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
        }

        LoadSprites();
        createRaceList();
        createGenderList();
        createTraitDictionary();
        createModulePrototypes();
        //Create prototype lists, eventually this will just be importing from an XML file or something
        createNameDictionary();
        //createEnemyPrototypes();
        createShipNameList();
    }

    public Sprite getEventSprite(string eventName)
    {
        if (eventSpriteDictionary.ContainsKey(eventName))
        {
            return eventSpriteDictionary[eventName];
        } else
        {
            return defaultEventSprite;
        }
    }

    void LoadSprites()
    {
        eventSpriteDictionary = new Dictionary<string, Sprite>();
        Sprite[] eventSprites = Resources.LoadAll<Sprite>("Images/EventImages/");

        foreach (Sprite s in eventSprites)
        {
            //Debug.Log(s.name);
            eventSpriteDictionary[s.name] = s;
        }

        characterPortraitDictionary = new Dictionary<string, Sprite>();
        Sprite[] portraitSprites = Resources.LoadAll<Sprite>("Images/CharacterPortraits/");

        foreach (Sprite s in portraitSprites)
        {
            Debug.Log(s.name);
            characterPortraitDictionary[s.name] = s;
        }
    }

    public int nextCharID()
    {
        return characterIndex += 1;
    }

    public void createModulePrototypes()
    {
        modulePrototypes = new Dictionary<string, Module>();
        modulePrototypes.Add("Laser Gun", new WeaponModule(ShipWeaponType.Laser, new Attack(1, 10), null));
    }

    public void createTraitDictionary()
    {
        traitDictionary = new Dictionary<string, Trait>();
        traitDictionary.Add("Engineer", new Trait("Engineer", "Enginners are adept at mechanical workings.", new List<StatBonus> { new StatBonus("Strength", 2), new StatBonus("Piloting", 1)}));
        traitDictionary.Add("Diplomat", new Trait("Diplomat", "A diplomat has exeptional negotiating skills.", new List<StatBonus> { new StatBonus("Mind", 2), new StatBonus("Strength", 1) }));
        traitDictionary.Add("Pirate", new Trait("Pirate", "Pirates will do whatever it takes to make some coin, even questionable things.", new List<StatBonus> { new StatBonus("Piloting", 2), new StatBonus("Agility", 1) }));
        traitDictionary.Add("Botanist", new Trait("Botanist", "A botanist can identify strange plants and even learn to grow their own.", new List<StatBonus> { new StatBonus("Mind", 3) }));
        traitDictionary.Add("Sharpshooter", new Trait("Sharpshooter", "When it comes to gunning, a sharpshooter never misses.", new List<StatBonus> { new StatBonus("Agility", 2), new StatBonus("Mind", 1) }));
        traitDictionary.Add("Explorer", new Trait("Explorer", "Explorers yearn for adventure and always seem to happen upon mysterious locales.", new List<StatBonus> { new StatBonus("Agility", 1), new StatBonus("Mind", 1), new StatBonus("Strength", 1), new StatBonus("Piloting", 1) }));

    }

   public void createRaceList()
    {
        races = new List<string>();
        races.Add("Terrestrial");
        races.Add("Martian");
        races.Add("Xorpan");

    }

    public string getRandomRace()
    {
        return races[Random.Range(0, races.Count)];
    }

    public void createGenderList()
    {
        genders = new List<string>();
        genders.Add("Male");
        genders.Add("Female");
        genders.Add("Neutral");
    }

    public string getRandomGender()
    {
        return genders[Random.Range(0, genders.Count)];
    }

    public void createNameDictionary()
    {
        names = new Dictionary<int, string>();
        names.Add(0, "Steve");
        names.Add(1, "Jerry");
        names.Add(2, "Margret");
        names.Add(3, "Jessica");
        names.Add(4, "Trisha");
        names.Add(5, "Bull");
        names.Add(6, "Nathan");
        names.Add(7, "Clarissa");

    }

    /*
    public void createEnemyPrototypes()
    {
        enemyDictionary = new Dictionary<string, Enemy>();
        enemyDictionary.Add("Zombie", new Enemy("Zombie", 0, 8, 1, 2, 0));
        enemyDictionary.Add("Feral Cat", new Enemy("Feral Cat", 0, 3, 4, 10, 0));
        enemyDictionary.Add("Robot", new Enemy("Robot", 0, 6, 6, 2, 0));
        enemyDictionary.Add("Alien", new Enemy("Alien", 0, 2, 10, 6, 0));
        enemyDictionary.Add("Horse", new Enemy("Horse", 0, 5, 2, 7, 0));

        enemyKeyList = new List<string>(enemyDictionary.Keys);
    }
    */

    /*
    //When we want a new enemy, we get a random one using this function
    public Enemy getRandomEnemy()
    {
        int rand = Random.Range(0, enemyKeyList.Count);
        string randomKey = enemyKeyList[rand];
        enemyDictionary[randomKey].ID += 1;
        Enemy enemy = new Enemy(enemyDictionary[randomKey].Name, enemyDictionary[randomKey].ID, enemyDictionary[randomKey].getStat("Strength"), enemyDictionary[randomKey].getStat("Mind"), enemyDictionary[randomKey].getStat("Agility"), enemyDictionary[randomKey].getStat("Piloting"));
        return enemy;
    }
    */

    public void createShipNameList()
    {
        shipNames = new List<string>();
        shipNames.Add("The Neverwhatever");
        shipNames.Add("The Star Destroyer");
        shipNames.Add("Her Majesty's Vessel");
        shipNames.Add("The Qtaz'Tzor");
        shipNames.Add("The Justice");
        shipNames.Add("The Wanderer");
        shipNames.Add("The Cheese Mechana");

    }

    public string getRandomName()
    {
        int r = Random.Range(0, 8);
        return names[r];
    }

    public string getRandomShipName()
    {

        return shipNames[Random.Range(0, shipNames.Count)];
    }
}
