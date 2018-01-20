using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Territory  : MonoBehaviour
{

    #region Public Members


    #endregion


    #region Public Void
    private bool m_hasSpecial;
    private GameObject m_territoryGameObject;

    public GameObject TerritoryGameObject
    {
        get { return m_territoryGameObject; }
        set { m_territoryGameObject = value; }
    }

    private Transform m_territoryTransform;

    public Transform TerritoryTransform
    {
        get { return m_territoryTransform; }
        set { m_territoryTransform = value; }
    }

    private MeshRenderer m_territoryMeshRenderer;

    public MeshRenderer TerritoryMeshRenderer
    {
        get { return m_territoryMeshRenderer; }
        set { m_territoryMeshRenderer = value; }
    }


    public bool HasSpecial
    {
        get { return m_hasSpecial; }
        set { m_hasSpecial = value; }
    }
    private Special m_territorySpecial;

    public Special TerritorySpecial
    {
        get { return m_territorySpecial; }
        set { m_territorySpecial = value; }
    }
    private bool m_isHQ;
    public bool IsHQ
    {
        get { return m_isHQ; }
        set { m_isHQ = value; }
    }

    private bool m_isCenter;
    public bool IsCenter
    {
        get { return m_isCenter; }
        set { m_isCenter = value; }
    }
    private Color m_currentColor = Color.white;
    public Color CurrentColor
    {
        get { return m_currentColor; }
        set { m_currentColor = value; }
    }
    public TerritoryManager Manager
    {
        get { return m_manager; }
        set { m_manager = value; }
    }
    private List<Player> m_listPlayerCharOnTerritory = new List<Player>();
    public List<Player> GetListOfPlayerOnThisTerritory()
    {
        return m_listPlayerCharOnTerritory;
    }

    public int GetPlayerNumOnTerritory()
    {
    return m_listPlayerCharOnTerritory.Count;
    }


    #endregion


    #region System

    void Awake () 
    {
        m_territoryMeshRenderer = GetComponent<MeshRenderer>();
        m_territoryTransform = transform;
        m_territoryGameObject = gameObject;
	}

    #endregion

    #region Private Void
    // à déplacer
    private void OnTriggerEnter(Collider col)
    {
        Player p = col.GetComponent<Player>();
        m_listPlayerCharOnTerritory.Add(p);
        if ((m_currentColor != p.PlayerFaction.FactionColor)&&(!IsHQ))
        {
            ColorChange(p);
        }
    }
    public void ColorChange(Color color) {
        
        m_territoryMeshRenderer.material.color = color;

    }
    public void ColorChange(Player p)
    {
        //previous territory owner looses Nbrterritory
        if (m_currentColor != Color.white)
        {
            if (m_currentColor == Color.red)
            {
                m_manager.FactionRED.NbrTerritories--;
            }
            else if (m_currentColor == Color.blue)
            {
                m_manager.FactionBLUE.NbrTerritories--;
            }
            else if (m_currentColor == Color.green)
            {
                m_manager.FactionGREEN.NbrTerritories--;
            }
            else if (m_currentColor == Color.yellow)
            {
                m_manager.FactionYELLOW.NbrTerritories--;
            }
        }
        m_currentColor = p.PlayerFaction.FactionColor;
        Color col = gameObject.GetComponentInChildren<MeshRenderer>().material.color;
        col = p.PlayerFaction.FactionColor;
        col.a = 100f;
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = col;
        //new territory owner gains Nbrterritory
        if (m_currentColor == Color.red)
        {
            m_manager.FactionRED.NbrTerritories++;
        }
        else if (m_currentColor == Color.blue)
        {
            m_manager.FactionBLUE.NbrTerritories++;
        }
        else if (m_currentColor == Color.green)
        {
            m_manager.FactionGREEN.NbrTerritories++;
        }
        else if (m_currentColor == Color.yellow)
        {
            m_manager.FactionYELLOW.NbrTerritories++;
        }
    }

    private void Battle()
    {

    }
    #endregion

    #region Tools Debug And Utility

    #endregion


    #region Private And Protected Members
    
    
  
    
    
    private TerritoryManager m_manager;
    #endregion

}
