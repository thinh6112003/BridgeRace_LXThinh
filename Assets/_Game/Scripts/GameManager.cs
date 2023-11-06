using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Sigleton<GameManager>
{
    [SerializeField]public GameObject vitoryPanel;
    [SerializeField] GameObject failPanel;
    
    public void Victory_Fail(GameObject gameObject)
    {
        if (gameObject.name == conststring.PLAYER)
        {
            vitoryPanel.SetActive(true);
        }
        else
        {
            failPanel.SetActive(true);
        }
    }
}
