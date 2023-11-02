using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] public color mycolor;
}
public enum color
    {
        none=0,
        red=1,
        blue=2,
        orange=3,
        purple=4,
    };