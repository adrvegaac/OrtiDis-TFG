using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovimientoCamara : MonoBehaviour
{
    public Controlador control;

    public GameObject inventarioPlantas;

    void Start(){
        control = GameObject.Find("Controlador").GetComponent<Controlador>();
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (transform.position.x<=-0.32f)
            {
                Vector3 retorno = new Vector3(0.0f, transform.position.y, -1.2f); 
                transform.SetPositionAndRotation(retorno, Quaternion.identity);
            }
            if(transform.position.x>=(control.getAncho()*0.32f))
            {
                Vector3 retorno = new Vector3(control.getAncho()*0.32f-0.32f, transform.position.y, -1.2f); 
                transform.SetPositionAndRotation(retorno, Quaternion.identity);
            }
            if(transform.position.y<=-0.32f)
            {
                Vector3 retorno = new Vector3(transform.position.x, 0.0f, -1.2f); 
                transform.SetPositionAndRotation(retorno, Quaternion.identity);
            }
            if(transform.position.y>=(control.getLargo()*0.32f))
            {
                Vector3 retorno = new Vector3(transform.position.x, control.getLargo()*0.32f-0.32f, -1.2f); 
                transform.SetPositionAndRotation(retorno, Quaternion.identity);
            }
        }

        if(Input.GetMouseButton(0)) 
        {
            if(!inventarioPlantas.activeSelf){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out RaycastHit info) == false)
                {
                    float pointer_x = Input.touches[0].deltaPosition.x;
                    float pointer_y = Input.touches[0].deltaPosition.y;
                    transform.Translate(-pointer_x * 0.0008f, -pointer_y * 0.0008f, 0); //Los valores son para la velocidad estaba en 0.055f
                } 
            }
        }
    }
}
