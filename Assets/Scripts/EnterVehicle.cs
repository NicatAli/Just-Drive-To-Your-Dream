using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVehicle : MonoBehaviour
{
    public GameObject car; // Araba objesi
    public KeyCode interactionKey = KeyCode.F; // Arabaya binme tuşu
    public GameObject carCamera; // Araba içindeki kamera
    public GameObject player; // Oyuncu karakteri
    public float interactionDistance = 3f; // Yakınlık mesafesi

    private bool isInsideCar = false;

    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            float distanceToCar = Vector3.Distance(transform.position, car.transform.position);

            if (distanceToCar < interactionDistance)
            {
                ToggleCarControl();
            }
        }
    }

    void ToggleCarControl()
    {
        isInsideCar = !isInsideCar;

        if (isInsideCar)
        {
            EnterCar();
        }
        else
        {
            ExitCar();
        }
    }

    void EnterCar()
    {
        // Kamera geçişleri
        carCamera.SetActive(true);
        // Oyuncunun karakter controller, mesh renderer ve collider'ını kapat
        car.GetComponent<CarController>().enabled = false;
        player.GetComponent<MeshRenderer>().enabled = false;
        player.GetComponent<Collider>().enabled = false;

        // Araba kontrol scriptini aktif et
        car.GetComponent<CarController>().enabled = true;

        // Oyuncuyu aracın içine yerleştir
        player.transform.parent = car.transform;
        player.transform.localPosition = Vector3.zero;
    }

    void ExitCar()
    {
        // Kamera geçişleri
        carCamera.SetActive(false);

        // Oyuncunun karakter controller, mesh renderer ve collider'ını aç
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<MeshRenderer>().enabled = true;
        player.GetComponent<Collider>().enabled = true;

        // Araba kontrol scriptini devre dışı bırak
        car.GetComponent<CarController>().enabled = false;

        // Oyuncuyu aracın dışına yerleştir
        player.transform.parent = null;
    }
}