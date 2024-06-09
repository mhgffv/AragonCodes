using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    ScoreManager scoreManager;
    BossHPscript BossHPManager;
    public ParticleSystem Explosion;
    public ParticleSystem HitExplosion;
    GameObject parent;
    int Hitamount;
    int Killamount;
    int hp;
    int BossHP;

    void Start()
    {
        Sorter();
        scoreManager = FindObjectOfType<ScoreManager>();
        BossHPManager = FindObjectOfType<BossHPscript>();
        parent = GameObject.FindWithTag("VFXparent");
    }

    void OnParticleCollision(GameObject other)
    {        
        ScoreIncrease();
        if (hp<1)
        {
            EnemyDesapier();
        }
    }

    void ScoreIncrease()
    {
        if (gameObject.tag == "MainEnemy")
        {
            BossHP--;
            BossHPManager.MinusBossHP(BossHP);
        }
        hp--;
        scoreManager.plusScore(Hitamount);
        ParticleSystem vfx = Instantiate(HitExplosion, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
    }

    void EnemyDesapier()
    {
        scoreManager.plusScore(Killamount);
        Destroy(gameObject);
        ParticleSystem vfx = Instantiate(Explosion, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
    }

    void Sorter()
    {
        switch (gameObject.tag)
        {
            case "Enemy":
                hp = 3;
                Hitamount = 5;
                Killamount = 20;
            break;

            case "MayorEnemy":
                hp = 5;
                Hitamount = 15;
                Killamount = 50;
            break;

            case "MainEnemy":
                hp = 20;
                BossHP = 20;
                Hitamount = 30;
                Killamount = 300;
            break;
        }
    }
}
