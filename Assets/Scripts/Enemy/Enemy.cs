using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Elemental Overload 2/Enemy", order = 0)]
public sealed class Enemy : ScriptableObject 
{
    public int value;
    public int health;
    public Sprite sprite;
}
