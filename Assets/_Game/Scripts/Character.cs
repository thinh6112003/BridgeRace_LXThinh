using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int stageNumber = 1;
    [SerializeField]public color colorCharater;

    public List<GameObject> listBrick = new List<GameObject>();
    [SerializeField] private List<GameObject> listBrickPrefab;
    
    public void Addbrick(GameObject brick)
    {
        GameObject newBrick = Instantiate(listBrickPrefab[(int)colorCharater], transform);
        newBrick.transform.localPosition = new Vector3(0, listBrick.Count * 0.26f, -1f);
        listBrick.Add(newBrick);
        Destroy(brick);
    }
    public void ReturnBrick(GameObject brigdeBrick)
    {
        brigdeBrick.GetComponent<BridgeBrick>().isreceived = true;
        Destroy(listBrick[listBrick.Count - 1]);
        listBrick.RemoveAt(listBrick.Count - 1);
    }
}
