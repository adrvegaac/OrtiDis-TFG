using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlantaGenerica : MonoBehaviour ,IDragHandler, /*IBeginDragHandler,*/ /*IEndDragHandler, */
IPointerDownHandler, IPointerUpHandler
{

    public int sinergia;
    public string description;
    public Sprite icon;
    public Controlador control;
    public int inicioX;
    public int inicioY;
    //de prueba


    void Start()
    {
        //busca la clase Controlador (el script) dentro del gameObject Controlador
        control = GameObject.Find("Controlador").GetComponent<Controlador>();
    }

    /*Realiza la acción mientras se mantenga pulsado el objeto */
    public void OnDrag(PointerEventData data)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 0, 0, 255);

        //===========DRAGSCENEOBJECT.CS===========//
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z * -1.0f;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        //===========DRAGSCENEOBJECT.CS===========//
        Transform tr = GetComponent<Transform>(); //Obtengo el componente transform del objeto
        if(tr.transform.position.x >-0.16f && tr.transform.position.x < (control.getAncho()*0.32f)-0.16f
        && tr.transform.position.y >-0.16f && tr.transform.position.y < (control.getLargo()*0.32f)-0.16f)
        {
            //Importante el +0,16 es igual a sumar la mitad de la longitud de la casilla y el 0,32 la longitud total
            sr.color = new Color(255, 0, 0, 255);
            float posX = tr.transform.position.x + 0.16f;
            float posY = tr.transform.position.y + 0.16f;
            int casillaX = Convert.ToInt32(Math.Truncate(posX/0.32f));
            int casillaY = Convert.ToInt32(Math.Truncate(posY/0.32f));
            iluminaCasilla(casillaX,casillaY);
            apagaTablero(casillaX,casillaY);
        }
        else{
            sr.color = new Color(0, 0, 0, 255);
        }
    }

    /*public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 0, 0, 1);
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 0, 0, 255);
        Transform tr = GetComponent<Transform>();
        float posX = tr.transform.position.x + 0.16f;
        float posY = tr.transform.position.y + 0.16f;
        int casillaX = Convert.ToInt32(Math.Truncate(posX/0.32f));
        int casillaY = Convert.ToInt32(Math.Truncate(posY/0.32f));
        inicioX = casillaX; //almacena coordenada X inicial
        inicioY = casillaY; //almacena coordenada Y inicial
        Vector3 [,] posiciones = control.getCasillas();
        String nombreCasilla = "Cesped" + casillaX + casillaY;
        Casilla casilla = GameObject.Find(nombreCasilla).GetComponent<Casilla>();
        casilla.setOcupada(false);
        casilla.setSinergia(0);
        iluminaCasilla(casillaX, casillaY);
    }

    /*public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 255);
    }*/

    public void OnPointerUp(PointerEventData eventData)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 255);
        Transform tr = GetComponent<Transform>();
        float posX = tr.transform.position.x + 0.16f;
        float posY = tr.transform.position.y + 0.16f;
        int casillaX = Convert.ToInt32(Math.Truncate(posX/0.32f));
        int casillaY = Convert.ToInt32(Math.Truncate(posY/0.32f)); 
        Vector3 [,] posiciones = control.getCasillas();
        String nombreCasillaI = "Cesped" + inicioX + inicioY;
        Casilla casillaI = GameObject.Find(nombreCasillaI).GetComponent<Casilla>();
        if(tr.transform.position.x >-0.16f && tr.transform.position.x < (control.getAncho()*0.32f)-0.16f
        && tr.transform.position.y >-0.16f && tr.transform.position.y < (control.getLargo()*0.32f)-0.16f){
            String nombreCasilla = "Cesped" + casillaX + casillaY;
            Casilla casilla = GameObject.Find(nombreCasilla).GetComponent<Casilla>();
            apagaCasilla(casillaX, casillaY);
            if(!casilla.getOcupada()) //mueve la planta a la casilla nueva y la marca como ocupada
            {
                tr.transform.position = posiciones[casillaX, casillaY];
                casilla.setOcupada(true);
                casilla.setSinergia(sinergia);
            }
            else //mueve la planta a la casilla inicial y la vuelve a marcar como ocupada
            {
                casillaI.setOcupada(true);
                casillaI.setSinergia(sinergia);
                tr.transform.position = posiciones[inicioX, inicioY];
            }
        }
        else
        {
            apagaTablero(inicioX, inicioY);
            apagaCasilla(inicioX, inicioY);
            Destroy(this.gameObject);

            //ESTA PARTE DEVUELVE LA PLANTA A SU CASILLA INICIAL SI SE LA SACA DEL TABLERO
            /*
            casillaI.setOcupada(true);
            tr.transform.position = posiciones[inicioX, inicioY];
            apagaTablero(inicioX, inicioY);
            apagaCasilla(inicioX, inicioY);
            */
        }
    }

    //Se va encargar de iluminar la casilla donde se va a colocar la planta una vez se suelte.
    public void iluminaCasilla(int x, int y)
    {
        //Si el valor que le pasas es mayor o igual al ancho o al largo introducido por el usuario no se ejecuta
        if(x < control.getAncho() && x >=0 && y < control.getLargo() && y>=0){
            String nombreCasilla = "Cesped" + x + y;
            GameObject cesped = GameObject.Find(nombreCasilla);
            Casilla casillaCesped = cesped.GetComponent<Casilla>();
            if(casillaCesped.getOcupada()){
                SpriteRenderer sr = cesped.GetComponent<SpriteRenderer>();
                sr.color = new Color(255, 0, 0, 255);
            }
            else
            {
                SpriteRenderer sr = cesped.GetComponent<SpriteRenderer>();
                sr.color = new Color(0, 255, 255, 255);
            }
        }
    }

    public void apagaCasilla(int x, int y)
    {
        String nombreCasilla = "Cesped" + x + y;
        GameObject cesped = GameObject.Find(nombreCasilla);
        SpriteRenderer sr = cesped.GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 255);
    }

    public void apagaTablero(int x, int y)
    {
        if(x < control.getAncho() && x >=0 && y < control.getLargo() && y>=0){
            int anchoA = control.getAncho();
            int largoA = control.getLargo();
            for(int i = 0; i < anchoA; i++)
            {
                for(int j = 0; j < largoA; j++)
                {
                    if(x!=i | y!=j)
                    {
                        String nombreCasilla = "Cesped" + i + j;
                        GameObject cesped = GameObject.Find(nombreCasilla);
                        SpriteRenderer sr = cesped.GetComponent<SpriteRenderer>();
                        sr.color = new Color(255, 255, 255, 255);
                    }
                }
            }
        } 
    }

    public int getCoordenadaX ()
    {
        Transform tr = GetComponent<Transform>();
        float posX = tr.transform.position.x + 0.16f;
        int casillaX = Convert.ToInt32(Math.Truncate(posX/0.32f));
        return casillaX;
    }

    public int getCoordenadaY ()
    {
        Transform tr = GetComponent<Transform>();
        float posY = tr.transform.position.y + 0.16f;
        int casillaY = Convert.ToInt32(Math.Truncate(posY/0.32f));
        return casillaY;
    }
}
