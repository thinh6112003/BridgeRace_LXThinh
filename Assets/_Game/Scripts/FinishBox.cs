using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBox : MonoBehaviour
{
    [SerializeField] GameObject vitoryPanel;
    [SerializeField] GameObject failPanel;
    bool isEnd = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(conststring.PLAYER)&& !isEnd)
        {
            if (other.name == conststring.PLAYER)
            {
                vitoryPanel.SetActive(true);
            }
            else
            {
                failPanel.SetActive(true);
            }
            isEnd = true;
        }
    }
}
