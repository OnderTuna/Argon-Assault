using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private PlayerController playerControlScript;
    private float loadDelay = 1f;
    [SerializeField] private ParticleSystem explosionEffect;

    private void Awake()
    {
        playerControlScript = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CrashSequence();
    }

    private void CrashSequence()
    {
        playerControlScript.enabled = false;
        explosionEffect.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke(nameof(RestartScene), loadDelay);
    }

    private void RestartScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
}
