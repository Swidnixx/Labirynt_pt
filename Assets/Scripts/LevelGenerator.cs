using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] mappings;

    public float offset = 5;

    public void Clear()
    {
        for(int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    public void Generate()
    {
        for(int x=0; x< map.width; x++)
        {
            for(int y=0; y< map.height; y++)
            {
                Color c = map.GetPixel(x, y);
                foreach(var m in mappings)
                {
                    if(m.color == c)
                    {
                        Vector3 pos = new Vector3(x, 0, y) * offset; 
                        GameObject go = Instantiate(m.prefab, transform);
                        go.transform.localPosition = pos;
                    }
                }
            }
        }
    }

    [Serializable]
    public class ColorToPrefab
    {
        public Color color;
        public GameObject prefab;
    }
}
