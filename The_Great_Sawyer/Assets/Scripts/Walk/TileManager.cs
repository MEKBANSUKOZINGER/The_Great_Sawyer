using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance;

    public Tilemap[] tilemaps;
    public Tilemap curTilemap;
    public int rand;

    void Start()
    {
        int rand = Random.Range(0, tilemaps.Length);
        for (int i = 0; i < tilemaps.Length; i++)
        {
            if (i != rand)
            {
                GameObject targetGrid = tilemaps[i].transform.parent.gameObject;
                targetGrid.SetActive(false);
            }
        }
        curTilemap = tilemaps[rand];
    }
}