using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Material> listMaterial;
    [SerializeField] private List<int> listColor;
    [SerializeField] private List<int> listPosition;
    [SerializeField] private List<GameObject> botListGO;
    [SerializeField] private List<Bot> botClassList;
    [SerializeField] private GameObject player;
    [SerializeField] private Player pclass;
    // Start is called before the first frame update
    void Start()
    {
        int rd = Random.Range(1, 5);
        pclass.colorCharater = (color)rd;
        player.GetComponent<Renderer>().material = listMaterial[rd];
        listMaterial.RemoveAt(rd);
        listColor.RemoveAt(rd);
        rd = Random.Range(1, 5);
        listPosition.RemoveAt(rd);
        pclass.transform.position= (-2f-0.5f +  (float)rd) * new Vector3(4f, 0f, 0f) + new Vector3(0f, 1f, -8f);
        for (int i = 1; i <= 3; i++)
        {
            botClassList[i].colorCharater = (color)listColor[i];
            botListGO[i].GetComponent<Renderer>().material = listMaterial[i];
            botClassList[i].transform.position = (-2f -0.5f + (float)listPosition[i])* new Vector3(4f, 0f,0f)+ new Vector3(0f,1f,-8f);
        }
    }
}
