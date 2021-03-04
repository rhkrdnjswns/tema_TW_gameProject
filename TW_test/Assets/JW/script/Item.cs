using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    private string BlockName;

    [SerializeField]
    private Sprite sprite;

}
