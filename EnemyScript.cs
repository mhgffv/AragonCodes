using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    ScoreManager scoreManager;
    public ParticleSystem Explosion;
    public ParticleSystem HitExplosion;
    [SerializeField] GameObject parent;
    int amount;
    int hp;

    void Start()
    {
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
        scoreManager = FindObjectOfType<ScoreManager>();
        parent = GameObject.FindWithTag("VFXparent");
        //Sorter();
    }

    /*void Sorter()
    {
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
    }*/

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
        Destroy(gameObject);
        ParticleSystem vfx = Instantiate(Explosion, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
    }

    void ScoreIncrease()
    {
        //ParticleSystem vfx = Instantiate(HitExplosion, transform.position, Quaternion.identity);
        //vfx.transform.parent = parent.transform;
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
