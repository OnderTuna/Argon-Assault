using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 15f;
    private float xClampFactor = 7.5f;
    private float yClampFactor = 7.5f;
    private float controlPitchFactor = -50f;
    private float positionalPitchFactor = -2f;
    private float controlRollFactor = -75f;
    private float positionalYawFactor = 2.5f;
    [SerializeField] private GameObject[] laserBeams;

    void Update()
    {
        Movement();
        Rotation();
        Fire();
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        float rawXpos = transform.localPosition.x + horizontalInput;
        float rawYpos = transform.localPosition.y + verticalInput;

        float clampedHorizontal = Mathf.Clamp(rawXpos, -xClampFactor, xClampFactor);
        float clampedVertical = Mathf.Clamp(rawYpos, Mathf.Epsilon, yClampFactor);

        transform.localPosition = new Vector3(clampedHorizontal, clampedVertical, 0f);
    }

    private void Rotation()
    {
        float positionOverPitch = transform.localPosition.y * positionalPitchFactor; //Pozisyonun rotasyona etkisi
        float inputOverPitch = verticalInput * controlPitchFactor; //Kontrolcunun rotasyona etkisi. Tuslarin etkisi.

        float pitch = positionOverPitch + inputOverPitch;
        float yaw = transform.localPosition.x * positionalYawFactor;
        float roll = horizontalInput * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void Fire()
    {
        if (Input.GetButton("Fire1"))
        {
            FireSystem(true);
        }
        else
        {
            FireSystem(false);
        }
    }

    private void FireSystem(bool value)
    {
        for (int i = 0; i < laserBeams.Length; i++)
        {
            var emissionModule = laserBeams[i].GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = value;
        }
    }
}
