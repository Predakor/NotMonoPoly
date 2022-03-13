using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{

    [SerializeField] List<GameObject> dices;
    [SerializeField] float throwStrength = 1f;
    [SerializeField] Vector3 throwStart;


    private Quaternion randomRotation =>
        Quaternion.Euler(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f));


    void Start()
    {
        if (throwStart == null)
            throwStart = transform.position;


        ThrowAllDices();

    }

    void ThrowDice(GameObject dice)
    {
        Instantiate(dice, throwStart, randomRotation);
    }

    void ThrowAllDices()
    {
        foreach (var dice in dices)
            ThrowDice(dice);

    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(throwStart, .1f);
    }



}