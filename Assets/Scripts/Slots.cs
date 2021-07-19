using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    
    public GameObject planta;

    public int sinergia;
    public GameObject infoPlanta;
    private bool infoPlantaActiva;
    public InventarioDePlantas inventarioDePlantas;
    private Instanciador i;


    void Start() 
    {
        i = GameObject.Find("Instanciador").GetComponent<Instanciador>();
        inventarioDePlantas = GameObject.Find("InventarioDePlantas").GetComponent<InventarioDePlantas>();
        infoPlantaActiva = false;
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && infoPlantaActiva)
        {
            infoPlanta.SetActive(false);
            infoPlantaActiva = false;
            inventarioDePlantas.ActivarInventarioDePlantas();
        }
    }

    public void instanciaPlanta()
    {
        i.instanciacionPlanta(planta, sinergia);
        inventarioDePlantas.ActivarInventarioDePlantas();
    }

    public void activaInfoPlanta()
    {
        if(!infoPlantaActiva)
        {
            infoPlanta.SetActive(true);
            infoPlantaActiva = true;
        }
    }
}
