using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShips : MonoBehaviour
{

    public GameObject shipPrefab;
    public int numberOfShips;
    public float offset;

    public GameObject emptyPos;

    FleetLeader leader;
    // Use this for initialization
    void Start()
    {
        leader = this.GetComponent<FleetLeader>();

        SpawnLeft();
        SpawnRight();
        SpawnEmpties();
    }

    void SpawnEmpties()
    {
        foreach (Vector3 pos in leader.shipPositions)
        {
            GameObject emptyPosInstance;
            emptyPosInstance = Instantiate(emptyPos, pos, Quaternion.identity) as GameObject;
        }
    }

    void SpawnLeft()
    {
        Vector3 spawnPos;
        spawnPos = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z - offset);

        for (int i = 0; i < numberOfShips; i++)
        {
            GameObject shipInstance;
            shipInstance = Instantiate(shipPrefab, spawnPos, Quaternion.identity) as GameObject;

            spawnPos = new Vector3(spawnPos.x + offset, spawnPos.y, spawnPos.z - offset);

            shipInstance.name = "LeftShip_" + i.ToString();

            leader.ships.Add(shipInstance.gameObject);
            leader.shipPositions.Add(shipInstance.transform.position);
        }
    }

    void SpawnRight()
    {
        Vector3 spawnPos;
        spawnPos = new Vector3(transform.position.x - offset, transform.position.y, transform.position.z - offset);

        for (int i = 0; i < numberOfShips; i++)
        {
            GameObject shipInstance;
            shipInstance = Instantiate(shipPrefab, spawnPos, Quaternion.identity) as GameObject;

            spawnPos = new Vector3(spawnPos.x - offset, spawnPos.y, spawnPos.z - offset);

            leader.ships.Add(shipInstance.gameObject);
            leader.shipPositions.Add(shipInstance.transform.position);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
