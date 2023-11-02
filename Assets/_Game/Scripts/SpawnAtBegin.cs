using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using random = System.Random;
public class SpawnAtBegin : MonoBehaviour
{ 
    [SerializeField] private List<GameObject> listBrickPrefab;

    public List<GameObject> listBrickStage1 = new List<GameObject>();
    void Start()
    {
        int k = 0;
        for (int i = 0; i <= 8; i++)
        {
            for (int j = 0; j <= 8; j++)
            {
                random rand = new random();
                GameObject newBrick = Instantiate(listBrickPrefab[Random.Range(1, 5)], transform);
                newBrick.transform.localPosition = new Vector3(i * 2f, 0, j * 2f);
                newBrick.name = "BrickStage1";
                listBrickStage1.Add(newBrick);
                k++;
            }
        }
        StartCoroutine(Check());
    }
    private IEnumerator Check()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            int k = 0;
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    if (listBrickStage1[k] == null) StartCoroutine(SpawnBrickInBlank(new Vector3(i * 2f, 0, j * 2f), k));
                    k++;
                }
            }
        }
    }
    private IEnumerator SpawnBrickInBlank(Vector3 position, int i)
    {
        yield return new WaitForSeconds(Random.Range(1f,4f));
        GameObject newBrick = Instantiate(listBrickPrefab[Random.Range(1, 5)], transform);
        listBrickStage1[i] = newBrick;
        newBrick.transform.localPosition = position;
        newBrick.name = $"BrickStage1";
    }

}
