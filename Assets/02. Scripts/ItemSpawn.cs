﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {
    public List<GameObject> itemPrefabList;

    public GameObject SpawnItem()
    {
        GameObject item;
        int r = Random.Range(0, itemPrefabList.Count);
        item = InstantiateItem(r);
        if(item == null){
            return null;
        }
        return item;
    }

    private GameObject InstantiateItem(int index){
        Vector3 screenPointPos = new Vector3(0, 0, 0);

        int r = Random.Range(0, 3);
        float position1 = (float)(Random.Range(2, 6) + 1.5) / 10.0f;
        float position2 = (float)(Random.Range(2, 6) + 1.5) / 10.0f;

        screenPointPos = new Vector3(position1 * Screen.width, position2 * Screen.height, 10.0f);

        Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(screenPointPos);
        GameObject item = Instantiate(itemPrefabList[index], screenToWorld, Quaternion.identity);

        return item;
    }
}
