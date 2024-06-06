using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Colider : MonoBehaviour
{

    public ParticleSystem LoseParticles;

    float Retardtime = 1f;

    bool IsTransition = false;
    bool Cheat = false;
    void OnTriggerEnter(Collider other) 
    {
        if (!IsTransition || !Cheat)
        {
            switch(other.gameObject.tag)
            {
                case "Enemy":
                    CrashSecuence();
                break;

                case "MayorEnemy":
                    CrashSecuence();
                break;

                case "MainEnemy":
                    CrashSecuence();
                break;

                case "Finish":
                    Ifend();
                break;
            }
        }
    }

    void Ifend()
    {
        SuccesSecuence();
    }

    void CrashSecuence()
    {
        LoseParticles.Play();
        GetComponent<PlayerMover>().enabled = false;
        Invoke("Disapair", 0.2f);
        Invoke("ResetLevel", Retardtime);
    }

    void SuccesSecuence()
    {
        Debug.Log("Lo lograste");
        Invoke("NextLevel", Retardtime);
    }

    void ResetLevel()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene);
    }

    void NextLevel()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        int LevelChanger = CurrentScene + 1;
        if (LevelChanger == SceneManager.sceneCountInBuildSettings)
        {
            LevelChanger = 0;
        }
        SceneManager.LoadScene(LevelChanger);
    }
    void Disapair()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
