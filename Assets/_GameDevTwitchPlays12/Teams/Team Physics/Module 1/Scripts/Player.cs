using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Faction m_playerFaction;
    public Faction PlayerFaction
    {
        get { return m_playerFaction; }
        set { m_playerFaction = value; }
    }
    public Territory m_currentTerritory;
    public Territory CurrentTerritory
    {
        get { return m_currentTerritory; }
        set { m_currentTerritory = value; }
    }
    //voir inventaire
    public bool hasGlasses = false;
    private string m_name;

    public string Name
    {
        get { return m_name; }
        set { m_name = value; }
    }

    private int m_level = 1;
    public int Level
    {
        get { return m_level; }
        set { m_level = value; }
    }
    private int m_gold;
    public int Gold
    {
        get { return m_gold; }
        set { m_gold = value; }
    }
    private int m_numPlayer;
    public int NumPlayer
    {
        get { return m_numPlayer; }
        set { m_numPlayer = value; }
    }
}
