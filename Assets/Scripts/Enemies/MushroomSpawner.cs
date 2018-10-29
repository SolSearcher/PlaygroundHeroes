using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour {

    //Mushroom Prefab to Spawn
    public GameObject m_MushroomPrefab;
    private GameObject mushroom;
    private List<GameObject> caps;
    private float waited = 0f;

    // Use this for initialization
    void Start()
    {
        //SpawnMushroom(transform.position);
        //caps = GameObject.FindGameObjectsWithTag("Mushroom");
    }
	// Update is called once per frame
	void Update ()
    {
        waited += Time.deltaTime;
        caps = new List<GameObject>(GameObject.FindGameObjectsWithTag("Mushroom"));

        if(waited > 10f)
        {
            for (int i = 0; i < 3; i++)
            {
                RandomRemove();
            }
            waited = 0f;
        }
    }

    private void RandomRemove()
    {
        int index = Random.Range(0, caps.Count);

        SpawnMushroom(caps[index].transform.position);

        Destroy(caps[index]);
        caps.RemoveAt(index);
    }

    public void SpawnMushroom(Vector3 position)
    {
        mushroom = m_MushroomPrefab;

        Instantiate(mushroom, position, Quaternion.identity);
        mushroom.GetComponent<EnemyFollow>().enabled = true;
    }


}
