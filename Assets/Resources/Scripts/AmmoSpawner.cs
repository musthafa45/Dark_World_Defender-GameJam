using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] WeaponsPrefabs;
    [SerializeField] float SecondToSpawn;
    [SerializeField] float MinX;
    [SerializeField] float MaxX;
    [SerializeField] float ObjectDestroytime;
    void Start()
    {
        StartCoroutine(WeoponSpawning());
    }


    void Update()
    {

    }
    IEnumerator WeoponSpawning()
    {
        while (true)
        {
            var Wanted = Random.Range(MinX, MaxX);
            var Position = new Vector3(Wanted, transform.position.y);
            GameObject gameObject = Instantiate(WeaponsPrefabs[Random.Range(0, WeaponsPrefabs.Length)], Position, Quaternion.identity);
            yield return new WaitForSeconds(SecondToSpawn);
            Destroy(gameObject, ObjectDestroytime);
        }

    }
}
