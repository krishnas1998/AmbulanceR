﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager1 : MonoBehaviour {
	public GameObject[] tilePrefabs;
	private Transform playerTransform;
	private float spawnZ = -5.0f;
	private float tileLength = 10.0f;
	private int amnTileOnScreen = 5;
	private float safeZone = 15.0f;
	private List<GameObject> activeTiles;
	private int lastPrefabIndex = 0;
	// Use this for initialization
	void Start () {
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		for (int i = 0; i < amnTileOnScreen; i++) {
			if (i < 2)
				SpawnTile (0);
			else
				SpawnTile ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z - safeZone > (spawnZ - amnTileOnScreen * tileLength)) {
			SpawnTile ();
			DeleteTile ();
		}
	}
	void SpawnTile(int prefabIndex = -1){
		GameObject go;
		if (prefabIndex == -1)
			go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
		else
			go = Instantiate (tilePrefabs [prefabIndex]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);
	}
	void DeleteTile()
	{
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	}
	int RandomPrefabIndex()
	{
		if (tilePrefabs.Length <= 1)
			return 0;
		int randomPrefabIndex = lastPrefabIndex;
		while (randomPrefabIndex == lastPrefabIndex) {
			randomPrefabIndex = Random.Range (0, tilePrefabs.Length);
		}
		lastPrefabIndex = randomPrefabIndex;
		return randomPrefabIndex;
	}
}
