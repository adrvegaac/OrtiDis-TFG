using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Casilla : MonoBehaviour//, IDropHandler
{
    public bool ocupada = false;

    public int sinergia = 0;

    public GameObject flechaDerecha;
    public GameObject flechaIzquierda;
    public GameObject flechaArriba;
    public GameObject flechaAbajo;
    public GameObject flechaDArribaDerecha;
    public GameObject flechaDArribaIzquierda;
    public GameObject flechaDAbajoDerecha;
    public GameObject flechaDAbajoIzquierda;

    public void setOcupada(bool estaOcupada)
    {
        ocupada = estaOcupada;
    }

    public bool getOcupada()
    {
        return ocupada;
    }

    public void setSinergia(int s)
    {
        sinergia = s;
    }

    public int getSinergia()
    {
        return sinergia;
    }

    public void activarFlechaArriba(Color color)
    {
        flechaArriba.SetActive(true);
        SpriteRenderer sr = flechaArriba.GetComponent<SpriteRenderer>();
        sr.color = color;
    }
    public void activarFlechaAbajo(Color color)
    {
        flechaAbajo.SetActive(true);
        SpriteRenderer sr = flechaAbajo.GetComponent<SpriteRenderer>();
        sr.color = color;
    }
    public void activarFlechaDerecha(Color color)
    {
        flechaDerecha.SetActive(true);
        SpriteRenderer sr = flechaDerecha.GetComponent<SpriteRenderer>();
        sr.color = color;
    }
    public void activarFlechaIzquierda(Color color)
    {
        flechaIzquierda.SetActive(true);
        SpriteRenderer sr = flechaIzquierda.GetComponent<SpriteRenderer>();
        sr.color = color;
    }

    public void desactivarFlechaArriba()
    {
        flechaArriba.SetActive(false);
    }

    public void desactivarFlechaAbajo()
    {
        flechaAbajo.SetActive(false);
    }

    public void desactivarFlechaIzquierda()
    {
        flechaIzquierda.SetActive(false);
    }

    public void desactivarFlechaDerecha()
    {
        flechaDerecha.SetActive(false);
    }

    public void activarFlechaArribaDerecha(Color color)
    {
        flechaDArribaDerecha.SetActive(true);
        SpriteRenderer sr = flechaDArribaDerecha.GetComponent<SpriteRenderer>();
        sr.color = color;
    }
    public void activarFlechaAbajoDerecha(Color color)
    {
        flechaDAbajoDerecha.SetActive(true);
        SpriteRenderer sr = flechaDAbajoDerecha.GetComponent<SpriteRenderer>();
        sr.color = color;
    }
    public void activarFlechaArribaIzquierda(Color color)
    {
        flechaDArribaIzquierda.SetActive(true);
        SpriteRenderer sr = flechaDArribaIzquierda.GetComponent<SpriteRenderer>();
        sr.color = color;
    }
    public void activarFlechaAbajoIzquierda(Color color)
    {
        flechaDAbajoIzquierda.SetActive(true);
        SpriteRenderer sr = flechaDAbajoIzquierda.GetComponent<SpriteRenderer>();
        sr.color = color;
    }

    public void desactivarFlechaArribaDerecha()
    {
        flechaDArribaDerecha.SetActive(false);
    }

    public void desactivarFlechaAbajoDerecha()
    {
        flechaDAbajoDerecha.SetActive(false);
    }

    public void desactivarFlechaArribaIzquierda()
    {
        flechaDArribaIzquierda.SetActive(false);
    }

    public void desactivarFlechaAbajoIzquierda()
    {
        flechaDAbajoIzquierda.SetActive(false);
    }
}
