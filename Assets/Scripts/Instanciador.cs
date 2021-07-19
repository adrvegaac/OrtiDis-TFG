using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.SceneManagement;
public class Instanciador : MonoBehaviour
{
    public Controlador control;
    private bool riegoActivo;
    public GameObject idPlanta1;
    public GameObject idPlanta2;
    public GameObject idPlanta3;
    public GameObject idPlanta4;
    public GameObject idPlanta5;
    public GameObject idPlanta6;
    public GameObject idPlanta7;
    public GameObject idPlanta8;
    public GameObject idPlanta9;
    public GameObject idPlanta10;
    public GameObject idPlanta11;
    public GameObject idPlanta12;
    public GameObject idPlanta13;
    public GameObject idPlanta14;
    public GameObject idPlanta15;
    public GameObject idPlanta16;
    public GameObject idPlanta17;
    public GameObject idPlanta18;
    public GameObject idPlanta19;
    public GameObject idPlanta20;

    private string nombreEscena;

//-------------------MODIFICACIÓN----------------------------------------------
    private Vector3[,] casillas;
    public GameObject cesped;
    public GameObject tierra;
    public GameObject aguaPrincipal;
    public GameObject aguaSecundaria;
    private int [,] posicionesPlantas;

//-------------------MODIFICACIÓN----------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        //busca la clase Controlador (el script) dentro del gameObject Controlador
        control = GameObject.Find("Controlador").GetComponent<Controlador>();
        casillas = control.getCasillas();
        crearPlano(casillas);
        posicionesPlantas = control.getPosicionesPlantas();
        if(posicionesPlantas!=null)
        {
            for(int x = 0; x<control.getAncho(); x++)
            {
                for(int y = 0; y<control.getLargo(); y++)
                {
                    intanciaPlantasDesdeFichero(posicionesPlantas[x,y], casillas[x,y]);
                    //Añadir que la casilla debe ponerse en ocupada y pasarle su sinergia
                    GameObject cesped = GameObject.Find("Cesped"+x+y);
                    Casilla casillaCesped = cesped.GetComponent<Casilla>();
                    casillaCesped.setSinergia(posicionesPlantas[x,y]);
                    if(casillaCesped.getSinergia()!=0)
                    {
                        casillaCesped.setOcupada(true);
                    }
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instanciacionPlanta(GameObject planta, int sinergia)
    {
        bool salida = false;
        int ancho = control.getAncho();
        int largo = control.getLargo();
        Vector3 [,] posiciones = control.getCasillas();
        for(int y=(largo-1); y>=0; y--)
        {
            for(int x=0; x<ancho; x++)
            {
                String nombreCasilla = "Cesped" + x + y;
                Casilla casilla = GameObject.Find(nombreCasilla).GetComponent<Casilla>();
                if (!casilla.getOcupada())
                {  
                    GameObject gameObject1 = (GameObject) Instantiate(planta, posiciones[x,y], Quaternion.identity);
                    casilla.setOcupada(true);
                    casilla.setSinergia(sinergia);
                    salida = true;
                    break;
                }
            }
            if(salida)
            {
                break;
            }
        }
    }
    public void activaRiego()
    {
        int anchoN = control.getAncho();
        int largoN = control.getLargo();
        /*Buscamos y activamos el agua principal*/
        if(largoN >= anchoN)
        {
            for(int y=0; y<largoN; y++)
            {
                SpriteRenderer sr = GameObject.Find("AguaPrincipal"+y).GetComponent<SpriteRenderer>();
                if(!riegoActivo)
                {
                    sr.enabled = true;
                }
                else
                {
                    sr.enabled = false;
                }
            }
        }
        else
        {
            for(int x=0; x<anchoN; x++)
            {
                SpriteRenderer sr = GameObject.Find("AguaPrincipal"+x).GetComponent<SpriteRenderer>();
                if(!riegoActivo)
                {
                    sr.enabled = true;
                }
                else
                {
                    sr.enabled = false;
                }
            }
        }
        /*Buscamos y activamos el agua secundaria*/
        for(int x = 0; x<anchoN; x++)
        {
            for(int y = 0; y<largoN; y++)
            {
                GameObject aguaSecundaria = GameObject.Find("AguaSecundaria"+ x + y);
                if(aguaSecundaria!=null)
                {
                    SpriteRenderer sr = aguaSecundaria.GetComponent<SpriteRenderer>();
                    if(!riegoActivo)
                    {
                    sr.enabled = true;
                    }
                    else
                    {
                        sr.enabled = false;
                    }
                }
            }
        }
        riegoActivo = !riegoActivo;
    }
    public void guardaEscenario()
    {
        string nombreJardin = control.getNombreJardin();
        //string rutaFicheroSalida = @"/users/adrian/desktop/"+ nombreJardin + ".txt";
        string rutaFicheroSalida = Application.persistentDataPath + nombreJardin + ".txt";
        Debug.Log("RUTAFICHERO DE SALIDA: " + rutaFicheroSalida);
        StreamWriter streamWriter = new StreamWriter(rutaFicheroSalida);
        int anchoN = control.getAncho();
        int largoN = control.getLargo();
        //escenarioGuardado = new int[anchoN,largoN];

        streamWriter.WriteLine(anchoN);
        streamWriter.WriteLine(largoN);
        for(int x =0; x<anchoN;x++)
        {
            for(int y =0; y<largoN;y++)
            {
                String nombreCasilla = "Cesped" + x + y;
                GameObject casilla = GameObject.Find(nombreCasilla);
                if(casilla!=null)
                {
                    Casilla casillaCesped = casilla.GetComponent<Casilla>();
                    //escenarioGuardado[x,y] = casillaCesped.getSinergia();
                    streamWriter.WriteLine(casillaCesped.getSinergia());
                }
            }
        }
        streamWriter.Close();
    }

    public void intanciaPlantasDesdeFichero(int idPlanta, Vector3 posicion)
    {
        switch (idPlanta)
        {
            case 0:
                break;
            case 1:
                GameObject gameObject1 = (GameObject) Instantiate(idPlanta1, posicion, Quaternion.identity);
                break;
            case 2:
                GameObject gameObject2 = (GameObject) Instantiate(idPlanta2, posicion, Quaternion.identity);
                break;
            case 3:
                GameObject gameObject3 = (GameObject) Instantiate(idPlanta3, posicion, Quaternion.identity);
                break;
            case 4:
                GameObject gameObject4 = (GameObject) Instantiate(idPlanta4, posicion, Quaternion.identity);
                break;
            case 5:
                GameObject gameObject5 = (GameObject) Instantiate(idPlanta5, posicion, Quaternion.identity);
                break;
            case 6:
                GameObject gameObject6 = (GameObject) Instantiate(idPlanta6, posicion, Quaternion.identity);
                break;
            case 7:
                GameObject gameObject7 = (GameObject) Instantiate(idPlanta7, posicion, Quaternion.identity);
                break;
            case 8:
                GameObject gameObject8 = (GameObject) Instantiate(idPlanta8, posicion, Quaternion.identity);
                break;
            case 9:
                GameObject gameObject9 = (GameObject) Instantiate(idPlanta9, posicion, Quaternion.identity);
                break;
            case 10:
                GameObject gameObject10 = (GameObject) Instantiate(idPlanta10, posicion, Quaternion.identity);
                break;
            case 11:
                GameObject gameObject11 = (GameObject) Instantiate(idPlanta11, posicion, Quaternion.identity);
                break;
            case 12:
                GameObject gameObject12 = (GameObject) Instantiate(idPlanta12, posicion, Quaternion.identity);
                break;
            case 13:
                GameObject gameObject13 = (GameObject) Instantiate(idPlanta13, posicion, Quaternion.identity);
                break;
            case 14:
                GameObject gameObject14 = (GameObject) Instantiate(idPlanta14, posicion, Quaternion.identity);
                break;
            case 15:
                GameObject gameObject15 = (GameObject) Instantiate(idPlanta15, posicion, Quaternion.identity);
                break;
            case 16:
                GameObject gameObject16 = (GameObject) Instantiate(idPlanta16, posicion, Quaternion.identity);
                break;
            case 17:
                GameObject gameObject17 = (GameObject) Instantiate(idPlanta17, posicion, Quaternion.identity);
                break;
            case 18:
                GameObject gameObject18 = (GameObject) Instantiate(idPlanta18, posicion, Quaternion.identity);
                break;
            case 19:
                GameObject gameObject19 = (GameObject) Instantiate(idPlanta19, posicion, Quaternion.identity);
                break;
            case 20:
                GameObject gameObject20 = (GameObject) Instantiate(idPlanta20, posicion, Quaternion.identity);
                break;
                //AÑADIR UN CASO POR CADA PLANTA CON SU ID Y AÑADIR LA PLANTA COMO OBJETO GLOBAL DE LA CLASE
            default:
                
                break;
        }
    }
    public void crearPlano(Vector3[,] casillas)
    {
        int anchoN = control.getAncho();
        int largoN = control.getLargo();
        //generador = GameObject.Find("Instanciador").GetComponent<Instanciador>();
        /*Genera el plano de tierra y césped con las dimensiones establecidas por el usuario y los nombra con
        sus coordenadas*/

        for(int x=0; x<anchoN; x++)
        {
            for(int y=0; y<largoN; y++)
            {
                GameObject planoCesped = (GameObject) Instantiate(cesped, casillas[x,y], Quaternion.identity);
                planoCesped.name = "Cesped" + x + y;
                GameObject planoTierra = (GameObject) Instantiate(tierra, casillas[x,y], Quaternion.identity);
                planoTierra.name = "Tierra" + x + y;
                /*Se genera el riego secundario*/
                if(largoN >= anchoN)
                {
                    if(y<(largoN -1))
                    {
                        Vector3 posicionAguaSecundaria = casillas[x,y];
                        posicionAguaSecundaria.Set(posicionAguaSecundaria.x, posicionAguaSecundaria.y+0.16f, posicionAguaSecundaria.z);
                        GameObject planoAguaSecundaria = (GameObject) Instantiate(aguaSecundaria, posicionAguaSecundaria, Quaternion.identity);
                        planoAguaSecundaria.name = "AguaSecundaria" + x + y;
                    }
                }
                else
                {
                    if(x<(anchoN-1))
                    {
                        Vector3 posicionAguaSecundaria = casillas[x,y];
                        posicionAguaSecundaria.Set(posicionAguaSecundaria.x+0.16f, posicionAguaSecundaria.y, posicionAguaSecundaria.z);
                        GameObject planoAguaSecundaria = (GameObject) Instantiate(aguaSecundaria, posicionAguaSecundaria, Quaternion.Euler(0,0,90));
                        planoAguaSecundaria.name = "AguaSecundaria" + x + y;
                    }
                }
            }
        }
        /*genera el borde de agua principal que se va a establecer dependiendo de cuál es el eje más largo,
        si el ancho "x" o el largo "y"*/
        if(largoN >= anchoN)
        {
            for(int y=0; y<largoN; y++)
            {
                Vector3 posicionAguaPrincipal = casillas[0,y];
                posicionAguaPrincipal.Set(posicionAguaPrincipal.x-0.305f, posicionAguaPrincipal.y, posicionAguaPrincipal.z);
                GameObject planoAguaPrincipal = (GameObject) Instantiate(aguaPrincipal, posicionAguaPrincipal, Quaternion.identity);
                planoAguaPrincipal.name = "AguaPrincipal" + y;
            }
        }
        else
        {
            for(int x=0; x<anchoN; x++)
            {
                Vector3 posicionAguaPrincipal = casillas[x,0];
                posicionAguaPrincipal.Set(posicionAguaPrincipal.x, posicionAguaPrincipal.y-0.305f, posicionAguaPrincipal.z);
                GameObject planoAguaPrincipal = (GameObject) Instantiate(aguaPrincipal, posicionAguaPrincipal, Quaternion.identity);
                planoAguaPrincipal.name = "AguaPrincipal" + x;
            }
        }

        Camera.main.GetComponent<Transform>().position = new Vector3((anchoN/2)*0.32f, (largoN/2)*0.32f, -1.2f);
    }

    public void escenaNuevoJardin()
    {
        GameObject controlador = GameObject.Find("Controlador");
        Destroy(controlador);
        guardaEscenario();
        SceneManager.LoadScene("NuevoJardin");
    }
}
