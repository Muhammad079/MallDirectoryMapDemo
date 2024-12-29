using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoreInfo" , menuName = "Mall/Shop")]
public class ShopInfo : ScriptableObject
{
    public string ShopName;
    public Vector3 ShopPosition;
}
