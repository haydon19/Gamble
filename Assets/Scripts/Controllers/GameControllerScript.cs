using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Unknown, MainMenu, InShip, InWorld, GameOver };
public enum GameActiveState { Inactive, Active };


public class GameControllerScript : MonoBehaviour {
    int lightYearsToEOU;
    public PartyManager party;
    public float eventRate = 2.0f;
    public float nextEvent = 0.0f;
    public List<Character> Enemies = new List<Character>();
    public bool choosing = false;
    public static GameControllerScript instance;


    int characterIndex = 0;
    GameState gameState = GameState.Unknown;
    public GameActiveState gameActiveState = GameActiveState.Inactive;
    public SpaceShip ship;
    public bool paused = false;
    public SpaceShip enemyShip;
    [SerializeField]
    public LocationState locationState = LocationState.Space;

    public Situation currentSituation;

    public int LightYearsToEOU
    {
        get
        {
            return lightYearsToEOU;
        }

        set
        {
            int oldValue = lightYearsToEOU;
            if (value != oldValue)
            {
                lightYearsToEOU = value;
                EventPanelScript.instance.LightYearCounter.text = lightYearsToEOU + " Light Years to go";
            }

        }
    }


    //Creating non player characters, giving them random stats, races, genders, etc.
    public Character createNPC()
    {
        return new Character(GameData.instance.getRandomName(), GameData.instance.getRandomRace(), GameData.instance.getRandomGender(), GameData.instance.nextCharID(), Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
    }

    public Character getRandomPartyMember()
    {
        return party.getParty()[Random.Range(0, party.getParty().Count)];
    }




    // Use this for initialization
    void Start() {

        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
        //PartyManagerPanel.instance.gameObject.SetActive(false);

        DontDestroyOnLoad(this);


    }

    void CheckScene()
    {

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Logic for loading between scenes
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSituation = null;
        if (scene.name == "MainMenuScene")
        {
            gameState = GameState.MainMenu;
        }
        else if (scene.name == "Scene1")
        {
            gameState = GameState.InShip;
            NewGame();
        }
        else if (scene.name == "Level 1")
        {
            gameState = GameState.InWorld;
        }

        Debug.Log(gameState);

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    public void NewGame()
    {
        gameActiveState = GameActiveState.Active;
        characterIndex = 0;
        LightYearsToEOU = 30;

        party = new PartyManager();
        //Debug.Log(GameControllerScript.instance.party.ToString());
        if (GameData.instance.party != null)
        {
            foreach (Character c in GameData.instance.party)
                party.addPartyMember(c);
        }

        //Lets create some Characters, we'll randomize their starting stats (done in the character creation function)
        while (party.partyMembers.Count < 4)
        {
            party.AddRandomPartyMember();
        }

        CharacterIconsPanel.instance.populateContainer();

    }


    
    //function for quitting the game
    public void ExitGame() {
            Application.Quit();
    }

    public Situation GetRandomSituation()
    {
        return Instantiate(GameData.instance.situationPrototypes[Random.Range(0, GameData.instance.situationPrototypes.Count)]);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    // Update is called once per frame
    void Update () {


        if(SoundControllerScript.instance != null)
        {
            //SoundControllerScript.instance.PlayMusic(1);
        }

        switch (gameState)
        {
            case GameState.InShip:
                InShipUpdate();
                break;
            
        }
        
        
	}

    void InShipUpdate()
    {
        if (gameState == GameState.GameOver)
        {
            //if the game is over stop doing the game loop
            return;
        }

        if (currentSituation == null)
        {
            currentSituation = GetRandomSituation();
            currentSituation.Initialize();
        }
    }
}
