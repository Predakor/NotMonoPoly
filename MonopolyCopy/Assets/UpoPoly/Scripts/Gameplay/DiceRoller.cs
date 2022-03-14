using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{

    [SerializeField] int diceAmount = 2;
    [SerializeField] GameObject dicePrefab;
    [SerializeField] Transform diceParent;
    [SerializeField] List<GameObject> dices;
    [SerializeField] float throwStrength = 1f;
    [SerializeField] Vector3 throwStart;


    private Quaternion randomRotation =>
        Quaternion.Euler(Random.Range(-270f, 270f), Random.Range(-270f, 270f), Random.Range(-270f, 270f));


    void Awake()
    {
        if (throwStart == null)
            throwStart = transform.position;
        if (dicePrefab == null) Debug.LogError("No dice prefab");
    }
    void Start()
    {
        SpawnDices();
    }

    void SpawnDices()
    {
        for (int i = 0; i < diceAmount; i++)
        {
            GameObject dice = Instantiate(dicePrefab, throwStart, randomRotation, diceParent);
            dices.Add(dice);
        }

        Invoke("GetRollResults", 5);
    }
    int GetRollResults()
    {
        int sum = 0;
        foreach (var dice in dices)
            sum += checkDiceRoll(dice);

        return sum;
    }

    int checkDiceRoll(GameObject dice)
    {
        Vector3 RayStart = dice.transform.position + Vector3.up;
        RaycastHit hit;
        Physics.Raycast(RayStart, Vector3.down, out hit, 1.4f);
        return int.Parse(hit.collider.gameObject.name);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(throwStart, .1f);
    }
}