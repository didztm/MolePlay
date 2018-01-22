using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(TwitchIRC),typeof(ListenToTwitchIRC),typeof(SendToTwitchIRC))]
public class AutoConnectTwitchIRC : MonoBehaviour {
    

    public string _userName;
    public string _oAuth;
    private TwitchIRC m_irc;
    // Use this for initialization
   
    private void Awake()
    {
        m_irc = gameObject.GetComponent<TwitchIRC>();
    }

    void Start () {
        m_irc = GetComponent<TwitchIRC>();
        PlayerPrefs.SetString("user", _userName);
        PlayerPrefs.SetString("oauth", _oAuth);
        PlayerPrefs.Save();
        m_irc.Login(_userName, _oAuth);
    }

    public static void GetOAuthFromWeb(string url) {
        Application.OpenURL(url);
    }
    public TwitchIRC GetIRC()
    {
        return m_irc;
    }
}
