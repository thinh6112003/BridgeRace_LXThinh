using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBrick : MonoBehaviour
{
    public bool isreceived = false;
    public color brickColor = color.none;
    [SerializeField] private List<Material> listMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(conststring.PLAYER) && isreceived == false && other.GetComponent<Character>().listBrick.Count > 0)
        {
            LayBrick(other.gameObject, other.GetComponent<Character>());
        }
        if (other.CompareTag(conststring.PLAYER) && isreceived == true&& other.GetComponent<Character>().colorCharater!= brickColor && other.GetComponent<Character>().listBrick.Count > 0)
        {
            ChangeBrick(other.gameObject);
        }
    }

    private void ChangeBrick(GameObject gameObject)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = listMaterial[(int)gameObject.GetComponent<Character>().colorCharater];
    }

    private void LayBrick(GameObject character,  Character c)
    {
        GetComponent<MeshRenderer>().enabled = true;
        Renderer renderer = gameObject.GetComponent<Renderer>();
        brickColor = character.GetComponent<Character>().colorCharater; 
        renderer.material = listMaterial[(int)brickColor]; 
        isreceived = true;
        Destroy( c.listBrick[c.listBrick.Count - 1]);
        c.listBrick.RemoveAt(c.listBrick.Count - 1);
    }
}
public static class conststring
{
    public static string PLAYER= "Player";
    public static string BRICK = "Brick";
    public static string BRIDGEBRICK = "BridgeBrick";
}
