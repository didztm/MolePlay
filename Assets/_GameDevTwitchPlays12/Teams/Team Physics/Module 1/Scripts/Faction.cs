using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction : MonoBehaviour
{
    private List<Player> m_listPlayer;
    public List<Player> ListPlayer
    {
        get { return m_listPlayer; }
        set { m_listPlayer = value; }
    }

    public void AddPlayer(Player player)
    {
        m_listPlayer.Add(player);
    }
    /*
     * TODO
    public bool RemovePlayer()
    {
        if(m_listPlayerChar.Contains()
    }*/

    public Color FactionColor
    {
        get { return m_factionColor; }
        set { m_factionColor = value; }
    }
    public int NbrTerritories
    {
        get { return m_nbrTerritories; }
        set { m_nbrTerritories = value; }
    }
    public bool HasMiddle
    {
        get { return m_hasMiddle; }
        set { m_hasMiddle = value; }
    }
    public int GoldReserves
    {
        get { return m_goldReserves; }
        set { m_goldReserves = value; }
    }
    public Vector3 RespawnPosition
    {
        get { return m_respawnPosition; }
        set { m_respawnPosition = value; }
    }


    void StartCountDown()
    {

    }
    private void Awake()
    {
        m_listPlayer = new List<Player>();
    }

    void Update ()
    {
        
    }

    public void DispatchMoney()
    {
        if(m_listPlayer.Count != 0)
        {
            int part = m_goldReserves / m_listPlayer.Count;
            foreach(Player player in m_listPlayer)
            {
                player.Gold += part;
            }
            m_goldReserves = m_goldReserves % m_listPlayer.Count;
        }        
    }
   
    private int m_nbrTerritories;
    private Color m_factionColor;
    private int m_goldReserves;
    private bool m_hasMiddle = false;
    private Vector3 m_respawnPosition;
  
}
