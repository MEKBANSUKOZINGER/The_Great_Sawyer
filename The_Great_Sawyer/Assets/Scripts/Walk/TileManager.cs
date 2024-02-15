using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance;

    public Tilemap[] tilemaps;
    public Tilemap curNPCTilemap;
  
}