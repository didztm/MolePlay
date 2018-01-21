using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour, IGameEngine
{
    public AudioClip brawlSound;
    public AudioClip popSound;
    public AudioClip diggingSound;
    public AudioClip paperSound;
    public int m_goldPerCoinChest = 50;
    public int m_priceOfLevel = 50;
    private bool m_hasJustLostBattle;
    
    #region properties
    
    #endregion

    #region system
    private void Awake()
    {
    }
    #endregion
    
    #region  class methods
    public void DoBattle(Player player,Player Enemy)
    {
      /*  GetComponent<AudioSource>().PlayOneShot(brawlSound);


        Vector3 PlayerRespawnPosition = new Vector3();
        Vector3 EnemyRespawnPosition = new Vector3();
        int temp= player.Level;
        player.Level -= Enemy.Level;
        Enemy.Level -= temp;
        if(player.Level<1)
        {
            player.Level = 1;
            PlayerRespawnPosition = player.PlayerFaction.RespawnPosition;
            transform.position = PlayerRespawnPosition;
            player.CurrentTerritory = GameObject.Find("y=" + PlayerRespawnPosition.y + "x=" + PlayerRespawnPosition.x);
            m_hasJustLostBattle = true;
            if(player.hasGlasses)
            {
                player.hasGlasses = false;
                Enemy.hasGlasses = true;
            }
        }
        if (Enemy.Level < 1)
        {
            Enemy.Level = 1;
            EnemyRespawnPosition = Enemy.PlayerFaction.RespawnPosition;
            Enemy.transform.position = EnemyRespawnPosition;
            Enemy.CurrentTerritory = GameObject.Find("y=" + EnemyRespawnPosition.y + "x=" + EnemyRespawnPosition.x);
            if (Enemy.hasGlasses)
            {
                player.hasGlasses = true;
                Enemy.hasGlasses = false;
            }
        }*/
    }

    public void TestForNearbyEnnemies(Player player)
    {
        /*
        float y;
        float x;
        Territory TerritoryToTest;
        y = player.CurrentTerritory.transform.position.y + 1;
        if (!(y > m_manager.m_nbrYTerritories - 1))
        {
            float tempx = player.CurrentTerritory.gameObject.transform.position.x;
            float tempy = player.CurrentTerritory.gameObject.transform.position.y + 1;
            TerritoryToTest = GameObject.Find("y=" + (int)tempy + "x=" + (int)tempx).GetComponent<Territory>();
            if(TerritoryToTest.GetPlayerNumOnTerritory()>0)
            {
                foreach(Player OtherMole in TerritoryToTest.GetListOfPlayerOnThisTerritory())
                {

                    if(!m_hasJustLostBattle)
                    {
                        if(player.PlayerFaction.FactionColor!=OtherMole.PlayerFaction.FactionColor)
                        {
                            DoBattle(OtherMole);
                        }
                    }
                }
            }
        }
        y = player.CurrentTerritory.transform.position.y - 1;
        if (!(y < 0))
        {
            float tempx = player.CurrentTerritory.gameObject.transform.position.x;
            float tempy = player.CurrentTerritory.gameObject.transform.position.y - 1;
            TerritoryToTest = GameObject.Find("y=" + (int)tempy + "x=" + (int)tempx).GetComponent<Territory>();
            if (TerritoryToTest.GetPlayerNumOnTerritory() > 0)
            {
                foreach (Player OtherMole in TerritoryToTest.GetListOfPlayerOnThisTerritory())
                {
                    if (!m_hasJustLostBattle)
                    {
                        if (player.PlayerFaction.FactionColor != OtherMole.PlayerFaction.FactionColor)
                        {
                            DoBattle(OtherMole);
                        }
                    }
                        
                }
            }
        }
        x = player.CurrentTerritory.transform.position.x - 1;
        if (!(x < 0))
        {
            float tempx = player.CurrentTerritory.gameObject.transform.position.x - 1;
            float tempy = player.CurrentTerritory.gameObject.transform.position.y;
            TerritoryToTest = GameObject.Find("y=" + (int)tempy + "x=" + (int)tempx).GetComponent<Territory>();
            if (TerritoryToTest.GetPlayerNumOnTerritory() > 0)
            {
                foreach (Player OtherMole in TerritoryToTest.GetListOfPlayerOnThisTerritory())
                {
                    if (!m_hasJustLostBattle)
                    {
                        if (player.PlayerFaction.FactionColor != OtherMole.PlayerFaction.FactionColor)
                        {
                            DoBattle(OtherMole);
                        }
                    }
                        
                }
            }
        }
        x = player.CurrentTerritory.transform.position.x + 1;
        if (!(x > m_manager.m_nbrXTerritories - 1))
        {
            float tempx = player.CurrentTerritory.gameObject.transform.position.x + 1;
            float tempy = player.CurrentTerritory.gameObject.transform.position.y;
            TerritoryToTest = GameObject.Find("y=" + (int)tempy + "x=" + (int)tempx).GetComponent<Territory>();
            if (TerritoryToTest.GetPlayerNumOnTerritory() > 0)
            {
                foreach (Player OtherMole in TerritoryToTest.GetListOfPlayerOnThisTerritory())
                {
                    if (!m_hasJustLostBattle)
                    {
                        if (player.PlayerFaction.FactionColor != OtherMole.PlayerFaction.FactionColor)
                        {
                            DoBattle(OtherMole);
                        }
                    }
                        
                }
            }
        }
        m_hasJustLostBattle = false;*/
    }

    public void Move(string TypeOfMove,Player player)
    {/*
        float y;
        float x;
        
        switch (TypeOfMove)
        {
            case "UP":
                y = player.CurrentTerritory.transform.position.y + 1;
                if (!(y > m_manager.m_nbrYTerritories - 1))
                {
                    this.gameObject.transform.Translate(0f, 1f, 0f);
                    float tempx = player.CurrentTerritory.gameObject.transform.position.x;
                    float tempy = player.CurrentTerritory.gameObject.transform.position.y + 1;
                    player.CurrentTerritory = GameObject.Find("y=" + (int)tempy + "x=" + (int)tempx);
                    TestForNearbyEnnemies();
                }
                break;
            case "DOWN":
                y = player.CurrentTerritory.transform.position.y - 1;
                if (!(y < 0))
                {
                    this.gameObject.transform.Translate(0f, -1f, 0f);
                    float tempx = player.CurrentTerritory.gameObject.transform.position.x;
                    float tempy = player.CurrentTerritory.gameObject.transform.position.y - 1;
                    player.CurrentTerritory = GameObject.Find("y=" + (int)tempy + "x=" + (int)tempx);
                    TestForNearbyEnnemies();
                }
                break;
            case "LEFT":
                x = player.CurrentTerritory.transform.position.x - 1;
                if (!(x < 0))
                {
                    this.gameObject.transform.Translate(-1f, 0f, 0f);
                    float tempx = player.CurrentTerritory.gameObject.transform.position.x - 1;
                    float tempy = player.CurrentTerritory.gameObject.transform.position.y;
                    player.CurrentTerritory = GameObject.Find("y=" + (int)tempy + "x=" + (int)tempx);
                    TestForNearbyEnnemies();
                }
                break;
            case "RIGHT":
                x = player.CurrentTerritory.transform.position.x + 1;
                if (!(x > m_manager.m_nbrXTerritories - 1))
                {
                    this.gameObject.transform.Translate(1f, 0f, 0f);
                    float tempx = player.CurrentTerritory.gameObject.transform.position.x + 1;
                    float tempy = player.CurrentTerritory.gameObject.transform.position.y;
                    player.CurrentTerritory = GameObject.Find("y=" + (int)tempy + "x=" + (int)tempx);
                    TestForNearbyEnnemies();
                }
                break;
            case "DIG":
                

                if (player.CurrentTerritory.GetComponent<Territory>().HasSpecial)
                {
                    Special special = player.CurrentTerritory.HasSpecial();
                    special.m_PlayerAction = this;
                    SpecialAPI.NotifyNewSpecial(special);
                    if(special.m_typeSpecial==Special.e_specialType.COINCHEST)
                    { m_goldmoney += m_goldPerCoinChest; }
                    if (special.m_typeSpecial == Special.e_specialType.GLASSES)
                    { hasGlasses=true; }

                    if (special.m_typeSpecial == Special.e_specialType.PARCHEMENT)
                        GetComponent<AudioSource>().PlayOneShot(paperSound);
                    else
                        GetComponent<AudioSource>().PlayOneShot(diggingSound);


                    CurrentTerritory.GetComponent<Territory>().HasSpecial = false;
                    Destroy(CurrentTerritory.GetComponent("Special"));
                    m_manager.RePopSpecial();
                }
                else
                {
                    //message nothing to dig?
                }
                break;
            case "!Level":
                if(m_goldmoney>m_priceOfLevel)
                {
                    m_goldmoney -= m_priceOfLevel;
                    m_Level++;
                }
                break;
           
        }*/

    }

  
    public void GetCommandFromPlayer(string PName, string Command)
    {
        throw new System.NotImplementedException();
    }

    public void AssignFactionToPlayers(List<Player> ListOfPlayerNames)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region Didi



    #endregion
}
