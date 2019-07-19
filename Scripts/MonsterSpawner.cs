using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    void Start()
    {
        StartCoroutine(ObjectRandomGenerator());
    }

    IEnumerator ObjectRandomGenerator()
    {
        GameObject[] tempGO = new GameObject[3];

        tempGO[0] = object1;
        tempGO[1] = object2;
        tempGO[2] = object3;

        while (true)
        {
            Instantiate(tempGO[Random.Range(0, 3)]);
            yield return new WaitForSeconds(4f);
        }
    }
}
