using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject patientPrefab;
    public int numPatients;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numPatients; i++)
        {
            Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
        }

        Invoke("SpawnPatient", 5);
    }

    void SpawnPatient()
    {
        SpawnOne();
        Invoke("SpawnPatient", Random.Range(2, 10));
    }

    [ContextMenu(nameof(SpawnOne))]
    public void SpawnOne()
    {
        Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
    }
}
