using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    int size = 32;
    int verticies = 4;

    [SerializeField]
    GameObject tile;

    void Awake()
    {
        Generate();
    }
    void Start()
    {

    }

    void Generate()
    {
        int rowSize = size / verticies;

        Vector3 position = transform.position;
        int offset = 1;

        for (int i = 0; i < rowSize; i++)
        {
            position.z += offset;
            Instantiate(tile, position, transform.rotation, parent: transform);
        }
        for (int i = 0; i < rowSize; i++)
        {
            position.x += offset;
            Instantiate(tile, position, transform.rotation, parent: transform);
        }

        for (int i = 0; i < rowSize; i++)
        {
            position.z -= offset;
            Instantiate(tile, position, transform.rotation, parent: transform);
        }
        for (int i = 0; i < rowSize; i++)
        {
            position.x -= offset;
            Instantiate(tile, position, transform.rotation, parent: transform);
        }
    }
}