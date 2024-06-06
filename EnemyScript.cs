using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    ScoreManager scoreManager;
    public ParticleSystem Explosion;
    public ParticleSystem HitExplosion;
    int amount;
    int hp;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        switch (gameObject.tag)
        {
            case "Enemy":
                hp = 3;
            break;
            
            case "MayorEnemy":
                hp = 6;
            break;

            case "MainEnemy":
                hp = 20;
            break;
        }
    }

    void OnParticleCollision(GameObject other)
    {        
        ScoreIncrease();
        if (hp<1)
        {
            EnemyDesapier();
        }
    }

    void EnemyDesapier()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Explosion.Play();
    }

    void ScoreIncrease()
    {
        HitExplosion.Play();
        hp--;
        switch (gameObject.tag)
        {
            case "Enemy":
                amount = 5;
                break;

            case "MayorEnemy":
                amount = 15;
            break;
            case "MainEnemy":
                amount = 30;
            break;
        }
        scoreManager.plusScore(amount);
    }
}
