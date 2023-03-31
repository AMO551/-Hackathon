using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kousen : MonoBehaviour
{
    public GameObject vas;
    private void OnParticleCollision(GameObject other)
    {
        vas.SetActive(true);
    }
}
