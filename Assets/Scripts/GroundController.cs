using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public KeyCode teleportKey = KeyCode.F; // Işınlama tuşu
    public Transform teleportTarget; // Işınlama hedefi

    void Update()
    {
        if (Input.GetKeyDown(teleportKey))
        {
            Teleport();
        }
    }

    void Teleport()
    {
        if (teleportTarget != null)
        {
            // Işınlama işlemi
            transform.position = teleportTarget.position;
            Debug.Log("Işınlama gerçekleşti!");
        }
        else
        {
            Debug.LogWarning("Işınlama hedefi belirlenmemiş!");
        }
    }
}
