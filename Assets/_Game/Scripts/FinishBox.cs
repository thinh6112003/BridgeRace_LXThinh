using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBox : MonoBehaviour
{
    bool isEnd = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(conststring.PLAYER)&& !isEnd)
        {
            GameManager.Instance.Victory_Fail(other.gameObject);
            isEnd = true;
        }
    }
}
