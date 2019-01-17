﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour {

    public EyeAttack eyeAttack;
    public EnemyLegAttack enemyLegAttack;
    public GameObject EnemyLeg;
    public GameObject TempEnemy;

    void Scripts()
    {
        GameObject finder = GameObject.Find("TempEnemy");
        eyeAttack = finder.GetComponent<EyeAttack>();
        GameObject finder2 = GameObject.Find("TempManager");
        enemyLegAttack = finder2.GetComponent<EnemyLegAttack>();
    }

    private void Start()
    {
        StartCoroutine(LegAttackTimer(EnemyLeg));
    }

    void StartTimer()
    {
        StartCoroutine(EyeAttackTimer(TempEnemy));
    }

    public IEnumerator EyeAttackTimer(GameObject TempEnemy)
    {
        yield return new WaitForSeconds(3.5f);
        eyeAttack.ShootProjectile(); Debug.Log("That's a lot of damage");
    }

    public IEnumerator LegAttackTimer(GameObject EnemyLeg)
    {
        enemyLegAttack.LegAttack(); 
        yield return new WaitForSeconds(3.5f);
        enemyLegAttack.LegRetreat(); 
        StartTimer();
    }

}
