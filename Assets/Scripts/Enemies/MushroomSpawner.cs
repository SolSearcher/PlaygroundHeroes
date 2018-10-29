using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour {

    //Mushroom Prefab to Spawn
    public GameObject m_MushroomPrefab;
    private GameObject mushroom;

    // Use this for initialization
    void Start()
    {
        SpawnMushroom(transform.position);
    }
	// Update is called once per frame
	void Update () {
		


	}

    public void SpawnMushroom(Vector3 position)
    {
        mushroom = m_MushroomPrefab;

        mushroom.GetComponent<EnemyFollow>().enabled = false;
        Instantiate(mushroom, position, Quaternion.identity);
    }


}
