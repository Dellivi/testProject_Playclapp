using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;

    private float delay = 1f;
    private float distance = 30f;
    private float speed = 5f;

    public float Speed { get => speed; set => speed = value; }
    public float Distance { get => distance; set => distance = value; }
    public float Delay { get => delay; set => delay = value; }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    public IEnumerator SpawnCoroutine()
    {

        while (true)
        {
            MovementObject moveObject =  Instantiate(spawnObject, this.transform.position, Quaternion.identity).GetComponent<MovementObject>();

            moveObject.Speed = this.Speed;
            moveObject.Distance = this.Distance;

            yield return new WaitForSeconds(Delay);
        }
    }
}
