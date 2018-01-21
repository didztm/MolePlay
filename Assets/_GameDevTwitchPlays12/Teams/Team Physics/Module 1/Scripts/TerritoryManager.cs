using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryManager  : MonoBehaviour, IGameEngine
{

    #region Public Members
    public bool m_debug = true;
    public List<Player> m_listPlayer = new List<Player>();
    public List<PlayerInfo> m_listPlayerInfo = new List<PlayerInfo>();
    public int m_sizeOfDiceItem = 5;
    public int m_incomePerTerritory = 1;
    public float m_timeBetweenPayDay = 1;
    public int m_nbrXTerritories =33;
    public int m_nbrYTerritories =33;
    public GameObject m_territoryPrefab;
    public GameObject m_playerCharPrefab;
    public int m_nbrFactions;
    public int m_territoryInCentralZone=0;
    public int m_headQuarter=0;
    public Territory[,] m_battleField;
    private List<Territory> eligibleTerritoryItem=new List<Territory>();
    
    #endregion


    #region Public Void
    


    public Faction FactionRED
    {
        get { return m_factionRed; }
        set { m_factionRed = value; }
    }
    public Faction FactionBLUE
    {
        get { return m_factionBlue; }
        set { m_factionBlue = value; }
    }
    public Faction FactionGREEN
    {
        get { return m_factionGreen; }
        set { m_factionGreen = value; }
    }
    public Faction FactionYELLOW
    {
        get { return m_factionYellow; }
        set { m_factionYellow = value; }
    }

    #endregion


    void Awake()
    {
        //GameStart();
    }
    public void DispatchTeam(Faction faction1, Faction faction2, Faction faction3,Faction faction4,int playerLimit) {
      
    }
    public void AssignFactionToPlayers(List<Player> ListOfPlayerNames)         //JEROME HERE ! Give me a list of player names, or ID in string format, thx buddy ;-)
    {/*
        if (m_isInitialized)
        {
            return;
        }
        m_isInitialized = true;
        int countRed;
        int countBlue;
        int countYellow;
        int countGreen;

        for (int i = 0; i < ListOfPlayerNames.Count; i++)
        {
            countBlue = m_factionBlue.ListPlayer.Count;
            countRed = m_factionGreen.ListPlayer.Count;
            countYellow = m_factionYellow.ListPlayer.Count;
            countGreen = m_factionRed.ListPlayer.Count;
            int playerLimit = countBlue+ countGreen + countRed + countYellow / 4;
            if (countBlue >= playerLimit || playerLimit != 0)
            {
                m_factionBlue.AddPlayer(ListOfPlayerNames[i]);
            }
            else if (countRed >= playerLimit)
            {
                m_factionRed
            }
            else if (countYellow >= playerLimit)
            {
                m_factionYellow
            }
            else if (countGreen >= playerLimit)
            {
                m_factionGreen
            }

        }
        
        int PlayerNum = 0;
        for(int faction = 0; PlayerNum< ListOfPlayerNames.Count; PlayerNum++)
        {
            GameObject NewPlayerGameObject = Instantiate(m_playerCharPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, transform);
            NewPlayerGameObject.name = ListOfPlayerNames[PlayerNum];
            NewPlayerGameObject.GetComponentInChildren<TextMesh>().text = "" + PlayerNum;
            Player NewPlayerScript = NewPlayerGameObject.GetComponent<Player>();
           // NewPlayerScript.MyManager = this;
            NewPlayerScript.NumPlayer = PlayerNum;
            NewPlayerScript.name = ListOfPlayerNames[PlayerNum];
            if (faction == 0)

            {
                NewPlayerScript.PlayerFaction = FactionRED;
                FactionRED.AddPlayer(NewPlayerScript);
                NewPlayerGameObject.transform.position = FactionRED.RespawnPosition;
                NewPlayerScript.CurrentTerritory = m_AxeY[0][0].gameObject;
            }
            else if (faction == 1)
            {
                NewPlayerScript.PlayerFaction = FactionBLUE;
                FactionBLUE.AddPlayer(NewPlayerScript);
                NewPlayerGameObject.transform.position = FactionBLUE.RespawnPosition;
                NewPlayerScript.CurrentTerritory = m_AxeY[m_nbrXTerritories - 1][m_nbrYTerritories - 1].gameObject;
            }
            else if (faction == 2)
            {
                NewPlayerScript.PlayerFaction = FactionGREEN;
                FactionGREEN.AddPlayer(NewPlayerScript);
                NewPlayerGameObject.transform.position = FactionGREEN.RespawnPosition;
                NewPlayerScript.CurrentTerritory = m_AxeY[m_nbrXTerritories - 1][0].gameObject;
            }
            else if (faction == 3)
            {
                NewPlayerScript.PlayerFaction = FactionYELLOW;
                FactionYELLOW.AddPlayer(NewPlayerScript);
                NewPlayerGameObject.transform.position = FactionYELLOW.RespawnPosition;
                NewPlayerScript.CurrentTerritory = m_AxeY[0][m_nbrYTerritories - 1].gameObject;
            }
            faction++;
            if (ListOfPlayerNames.Count > 8 )
            {
                if(faction > 3)
                {
                    faction = 0;
                }
            }
            else if(faction > 1)
            {
                faction = 0;
            }
           // NewPlayerScript.MyManager = this;
            m_listPlayer.Add(NewPlayerScript);
        }*/

    }



    IEnumerator TimerPayDay()
        {
            m_timerFinished = false;
            yield return new WaitForSeconds(m_timeBetweenPayDay);
            FactionRED.GoldReserves += FactionRED.NbrTerritories * m_incomePerTerritory;
            FactionBLUE.GoldReserves += FactionBLUE.NbrTerritories * m_incomePerTerritory;
            FactionGREEN.GoldReserves += FactionGREEN.NbrTerritories * m_incomePerTerritory;
            FactionYELLOW.GoldReserves += FactionYELLOW.NbrTerritories * m_incomePerTerritory;
            m_timerFinished = true;
            FactionRED.DispatchMoney();
            FactionBLUE.DispatchMoney();
            FactionGREEN.DispatchMoney();
            FactionYELLOW.DispatchMoney();


        }
        public void FillPlayerInfoList()
        {
            m_listPlayerInfo.Clear();
            int nbrRed = 1;
            int nbrBlue = 1;
            int nbrGreen = 1;
            int nbrYellow = 1;
            for (int i=0; i<m_listPlayer.Count;i++)
            {
                PlayerInfo _playerInfo = new PlayerInfo();
                Player playerC = m_listPlayer[i];
                _playerInfo.num = m_listPlayer[i].NumPlayer;
                _playerInfo.name = m_listPlayer[i].Name;
                _playerInfo.level = m_listPlayer[i].Level;
                _playerInfo.gold = m_listPlayer[i].Gold;
                _playerInfo.faction = m_listPlayer[i].PlayerFaction.FactionColor.ToString().ToUpper();
                switch(_playerInfo.faction)
                {
                    case "GREEN":
                        _playerInfo.posOnScreen = nbrGreen;
                        nbrGreen++;
                        break;
                    case "RED":
                        _playerInfo.posOnScreen = nbrRed;
                        nbrRed++;
                        break;
                    case "BLUE":
                        _playerInfo.posOnScreen = nbrBlue;
                        nbrBlue++;
                        break;
                    case "YELLOW":
                        _playerInfo.posOnScreen = nbrYellow;
                        nbrYellow++;
                        break;
                }
                m_listPlayerInfo.Add(_playerInfo);
            }

        }
       

        public void GetCommandFromPlayer(string PName, string Command)              //JEROME HERE ! Give me a player names and the command he sends ;-)       
        {
            foreach(Player PlayerChar in m_listPlayer)
            {
                if(PlayerChar.Name==PName)
                {

                    //PlayerChar.Move(Command);
                }
            }
        }

        #region System
        void Start () 
        {

        }



        void Update()
        {
            //testing only !!
            if (Input.GetButtonDown("Fire1"))
            {
              //  m_listPlayer[0].GetComponent<PlayerAction>().Move("UP");

            }
            if (Input.GetButtonDown("Fire2"))
            {
              //  m_listPlayer[0].GetComponent<PlayerAction>().Move("RIGHT");
            }
            //--------------


            if (m_gameHasStarted)
            {
                if (m_timerFinished)
                {
                    StartCoroutine("TimerPayDay");
                }
            }

            foreach (PlayerInfo _playerInfo in m_listPlayerInfo)
            {
                //_placementPlayer(_playerInfo.faction, _playerInfo.posOnScreen, _playerInfo.num, _playerInfo.name, _playerInfo.level, _playerInfo.gold);
            }
        }

        #endregion
        
    #region Private Void
    public void GameStart()
    {
        InitializeBoard();

        //List<string> DebugList = new List<string>();
        //for (int i = 0; i < 20; i++)
        //{
        //    DebugList.Add("hoho" + i);
        //}

        //AssignFactionToPlayers(DebugList);
    }
    private void InitializeBoard()
    {
        // InstanciateTerritories();
        CreateBattleField();
        PlaceCenterZone();
        //CreateFactions();
        PlaceFactionHQ();
        InitializeTerritorryItems();
       // PlaceItems();
    }

    private void CreateBattleField() {
        
        Vector3 positionOfCell = new Vector3();
        m_battleField = new Territory[m_nbrXTerritories,m_nbrYTerritories];

        for (int x = 0; x < m_battleField.GetLength(0); x++) {

            for(int y=0;y < m_battleField.GetLength(1); y++)
            {
                
                positionOfCell = new Vector3(x * 1f, y * 1f, 0);
                GameObject territoryPrefab = Instantiate(m_territoryPrefab, positionOfCell, Quaternion.identity, transform);
                territoryPrefab.name = "y=" + positionOfCell.y + "x=" + positionOfCell.x;
                territoryPrefab.GetComponent<Territory>().Manager = this;
                m_battleField[x,y] = territoryPrefab.GetComponent<Territory>();
                m_battleField[x, y].TerritoryID = "x"+x+"y"+y;
               // Debug.Log(m_battleField[x, y].TerritoryID);

            }

        }

    }
    private void PlaceCenterZone()
    {
        int xTrueCenter = (((m_battleField.GetLength(0)) - 1) / 2);
        int yTrueCenter = (((m_battleField.GetLength(1)) - 1) / 2);
        for (int y = yTrueCenter-1; y <= yTrueCenter +1; y++)
        {
            for (int x = xTrueCenter - 1; x <= xTrueCenter + 1; x++)
            {
               // Debug.Log(m_battleField[x, y]);

                m_battleField[x,y].GetComponent<Territory>().IsCenter = true;
                m_territoryInCentralZone++;
                m_battleField[x, y].GetComponent<Territory>().ColorChange(Color.red);
            }
        }
    }
    private Faction AddFaction(Territory territory, Color color)
    {
        
        territory.TerritoryGameObject.AddComponent<Faction>();
        Faction faction=territory.TerritoryTransform.GetComponent<Faction>();
        color.a = 100f;
        faction.FactionColor = color;
        faction.RespawnPosition = territory.TerritoryTransform.position;

        return faction;
        //FactionBLUE = CreateAFaction(Color.blue, new Vector3(m_nbrYTerritories - 1, m_nbrXTerritories - 1, 0f));
        //FactionGREEN = CreateAFaction(Color.green, new Vector3(m_nbrYTerritories - 1, 0f, 0f));
        //FactionYELLOW = CreateAFaction(Color.yellow, new Vector3(0f, m_nbrXTerritories - 1, 0f));
    }
    private void PlaceFactionHQ()
    {
        //LeftBottom
        FactionRED = AddFaction(m_battleField[0, 0],Color.red);
        MakeHq(m_battleField[0, 0], FactionRED);
        MakeHq(m_battleField[0, 1], FactionRED);
        MakeHq(m_battleField[1, 0], FactionRED);
        MakeHq(m_battleField[1, 1], FactionRED);
        //RightBottom
        FactionBLUE = AddFaction(m_battleField[0, m_battleField.GetLength(1)-1], Color.blue);
        MakeHq(m_battleField[0, m_battleField.GetLength(1)-1], FactionBLUE);
        MakeHq(m_battleField[1, m_battleField.GetLength(1) - 1], FactionBLUE);
        MakeHq(m_battleField[1, m_battleField.GetLength(1) - 2], FactionBLUE);
        MakeHq(m_battleField[0, m_battleField.GetLength(1) - 2], FactionBLUE);

        //LeftTop
        FactionGREEN= AddFaction(m_battleField[m_battleField.GetLength(0) - 1, 0], Color.green);
        MakeHq(m_battleField[m_battleField.GetLength(0)-1, 0], FactionGREEN);
        MakeHq(m_battleField[m_battleField.GetLength(0)-1, 1], FactionGREEN);
        MakeHq(m_battleField[m_battleField.GetLength(0)-2, 1], FactionGREEN);
        MakeHq(m_battleField[m_battleField.GetLength(0)-2, 0], FactionGREEN);

        //RightTop
        FactionYELLOW = AddFaction(m_battleField[m_battleField.GetLength(1) - 1, m_battleField.GetLength(1) - 1], Color.yellow);
        MakeHq(m_battleField[m_battleField.GetLength(0) - 1, m_battleField.GetLength(1) - 1], FactionYELLOW);
        MakeHq(m_battleField[m_battleField.GetLength(0) - 1, m_battleField.GetLength(1) - 2], FactionYELLOW);
        MakeHq(m_battleField[m_battleField.GetLength(0) - 2, m_battleField.GetLength(1) - 1], FactionYELLOW);
        MakeHq(m_battleField[m_battleField.GetLength(0) - 2, m_battleField.GetLength(1) - 2], FactionYELLOW);

    }
    public void MakeHq(Territory HQTerritory, Faction faction)
    {
        HQTerritory.IsHQ = true;
        HQTerritory.TerritoryMeshRenderer.material.color = faction.FactionColor;
        HQTerritory.CurrentColor = faction.FactionColor;
        m_headQuarter++;
    }

    public void InitializeTerritorryItems()
    {
        int randomCenterZone = Random.Range(1, m_territoryInCentralZone+1);//decides which central territory gets the glasses

        int centerCount = 0;
        int itemCount = Item.ItemTypeLength();
        bool hasGlasses = false;
        int i = 1;
        foreach (Territory t in m_battleField) {
           
            if (!hasGlasses)
            {
                if (t.IsCenter && !t.HasItem && centerCount == randomCenterZone)
                {
                    t.HasItem = true;
                    Item item= t.TerritoryGameObject.AddComponent<Item>();
                    item.ItemType= Item.e_itemType.GLASSES;
                    item.ItemEffectType = Item.e_itemEffectType.INVENTORY;
                    t.TerritoryItem = item;
                    t.HasItem = true;
                    hasGlasses = true;
                    t.ColorChange(Color.grey);
                }
                else if (t.IsCenter)
                {
                    centerCount++;
                }
                
            }
            if (!t.IsCenter && !t.HasItem && !t.IsHQ)
                {
                    eligibleTerritoryItem.Add(t);
                    i++;
                }
            
        }
        InitializeItems();
    }
    private void InitializeItems()
    {
        //Voir comment améliorer le random
        
        if (m_debug)
        {
            Debug.Log("Total eligibleTerritory:"+eligibleTerritoryItem.Count);
        }

        for (int i = 1; i < Item.ItemTypeLength(); i++)
        {
            if (Random.Range(1, 4) == Random.Range(1, 4))
            {
                {
                    int intRndItem = Random.Range(1, Item.ItemTypeLength());
                    int intRndTerritory = Random.Range(0, eligibleTerritoryItem.Count);
                    if (m_debug)
                    {
                        Debug.Log("Rnd eligibleTerritory1------>" + intRndTerritory);
                        Debug.Log("Rnd item1------>" + intRndItem);
                        eligibleTerritoryItem[intRndTerritory].ColorChange(Color.magenta);
                    }
                    Item item = eligibleTerritoryItem[intRndTerritory].TerritoryGameObject.AddComponent<Item>();
                    item.ItemType = (Item.e_itemType)intRndItem;
                    eligibleTerritoryItem[intRndTerritory].TerritoryItem = item;
                    eligibleTerritoryItem.Remove(eligibleTerritoryItem[intRndTerritory]);

                }
            }
            else i--;
        }
       
    }
    //lié à un evenement
    public void PopItem()
    {

    }
    #endregion

    #region Tools Debug And Utility

    #endregion


    #region Private And Protected Members
    private List<GameObject> m_AxeX = new List<GameObject>();
    private List<List<GameObject>> m_AxeY = new List<List<GameObject>>();

    private Faction m_factionRed;
    private Faction m_factionBlue;
    private Faction m_factionGreen;
    private Faction m_factionYellow;
    private bool m_timerFinished=true;
    private bool m_gameHasStarted;
    private bool m_isInitialized;
    #endregion

}
