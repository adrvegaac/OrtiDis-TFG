using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioDePlantas : MonoBehaviour
{
    private bool activarInventarioDePlantas;

    public GameObject inventarioDePlantas;

    private int allSlots;

    private GameObject[] slot;

    public GameObject gestorDeSlots;

    void Start()
    {
    }

    
    void Update()
    {

    }

    public void ActivarInventarioDePlantas()
    {
        activarInventarioDePlantas = !activarInventarioDePlantas;
        if (activarInventarioDePlantas)
        {
            inventarioDePlantas.SetActive(true);
        }
        else
        {
            inventarioDePlantas.SetActive(false);
        }
    }
}
