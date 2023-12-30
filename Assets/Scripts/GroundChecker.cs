using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public float groundedRayLength = 0.1f; // Yerden ayrılıp ayrılmadığını kontrol etmek için kullanılan ray uzunluğu

    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true; // Rotasyonun dondurulması, eğer gerekliyse
    }

    void Update()
    {
        CheckGrounded();
    }

    void CheckGrounded()
    {
        // Objeden aşağıya bir ray çizerek yerden ayrılıp ayrılmadığını kontrol et
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundedRayLength))
        {
            // Yerden ayrılmamışsa, Rigidbody'yi kinematik yaparak yer çekimine karşı sabitlenmesini sağla
            rigidbody.isKinematic = true;
        }
        else
        {
            // Yerden ayrılmışsa, Rigidbody'yi kinematik yapma ve yer çekimine serbest bırak
            rigidbody.isKinematic = false;
        }
    }
}