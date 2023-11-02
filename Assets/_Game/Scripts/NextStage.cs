using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using random = System.Random;

public class NextStage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private List<GameObject> listBrickPrefab;
    public List<GameObject> listBrick = new List<GameObject>();
    private bool isSpawn= false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(conststring.PLAYER)&& !isSpawn)
        {
            int k = 0;
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    int rd = Random.Range(1,5);
                    GameObject newBrick = Instantiate(listBrickPrefab[rd], spawnPosition);
                    newBrick.transform.localPosition = new Vector3(i * 2f, 0, j * 2f);
                    newBrick.name = $"BrickStage2";
                    listBrick.Add(newBrick);
                    k++;
                }
            }
            StartCoroutine(Check());
            isSpawn = true;
        }
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
                    if (listBrick[k] == null) StartCoroutine(SpawnBrickInBlank(new Vector3(i * 2f, 0, j * 2f),k));
                    k++;
                }
            }
        }
    }
    private IEnumerator SpawnBrickInBlank(Vector3 position, int i)
    {
        yield return new WaitForSeconds(Random.Range(1f,5f));
        int rd = Random.Range(1, 5);
        GameObject newBrick = Instantiate(listBrickPrefab[rd], spawnPosition);
        newBrick.transform.localPosition = position;
        listBrick[i] = newBrick;
        newBrick.name = $"BrickStage2";
    }
}
