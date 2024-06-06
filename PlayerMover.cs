using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float controlSpeed = 50f;
    [SerializeField] float xRange = 32.5f;
    [SerializeField] float yRange = 22f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -30f;

    [SerializeField] GameObject[] Lasers;


    float yControl, xControl, fire;

    void Update()
    {
        ProcessControl();
        ProccesRotation();
        ProccesFiring();
    }

    void ProcessControl()
    {
        xControl = Input.GetAxis("Horizontal");
        yControl = Input.GetAxis("Vertical");

        float xOffset = xControl * Time.deltaTime * controlSpeed;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedX = Mathf.Clamp(newXPos, -xRange, xRange);

        float yOffset = yControl * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedY = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3 (clampedX, clampedY, transform.localPosition.z); 
    }

    void ProccesRotation()
    {
        xControl = Input.GetAxis("Horizontal");
        yControl = Input.GetAxis("Vertical");

        float pitch = transform.localPosition.y * positionPitchFactor + yControl * controlPitchFactor;
        float yaw = transform.localPosition.x * -positionPitchFactor + xControl * -controlPitchFactor;
        float roll = xControl * controlPitchFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        
    }

    void ProccesFiring()
    {
        fire = Input.GetAxis("Fire1");
        if (fire != 1)
        {
            SetLaserActive(false);
        }
        else
        {
            SetLaserActive(true);
        }
        void SetLaserActive(bool IsActive)
        {
           foreach (GameObject Laser in Lasers)
           {
                var laserEmmision = Laser.GetComponent<ParticleSystem>().emission;
                laserEmmision.enabled = IsActive;
           }
        }
    }
}
