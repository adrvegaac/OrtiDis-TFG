using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;
using System.Threading;

public class Controlador : MonoBehaviour
{
    public static Controlador controlador;
    private Vector3[,] casillas;
    private string nombreJardin;
    private string ancho;
    private string largo;
    private int contador = 0;
    public GameObject panelPrincipal;
    public GameObject formularioNuevoJardin;
    public GameObject textoError;
//-----------------------------------------------------------------------------------------
//Lista de buenos y malos vecinos provisional
    private int [,] listaBuenosVecinos = { {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                            {7,13,8,2,3,21,12,9,11,-1,-1,-1,-1,-1,-1,-1,-1},     //Tomate
                                          {1,8,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},   //PimientoV
                                          {1,8,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},   //pimientoR
                                          {7,10,14,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},  //patata
                                          {9,8,5,11,12,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},    //pepino
                                          {8,10,11,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},  //calabacin
                                          {1,4,5,13,8,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},     //ajo
                                          {1,2,3,5,6,7,13,12,-1,-1,-1,-1,-1,-1,-1,-1,-1},       //cebolla
                                          {5,13,10,1,11,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},   //lechuga
                                          {4,6,9,13,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},    //guisantes
                                          {6,13,9,5,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},     //judiasV
                                          {1,13,5,8,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},    //puerros
                                          {1,7,8,9,12,10,11,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},     //zanahorias
                                          {4,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},  //coliflor
                                          {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}, //romero
                                          {1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},  //perejil
                                          {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}};//Lavanda
    private int [,] listaMalosVecinos = {{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                        {4,5,14,10,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {1,6,5,8,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {1,4,6,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {4,5,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {11,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {4,10,11,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {21,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {1,12,8,11,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {7,12,8,10,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {10,11,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {9,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
                                          {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}};
//------------------------------------------------------------------------------------------
    private int [,] escenarioGuardado; 

    private int [,] posicionesPlantas;
//------------------------------------------------------------------------------------------
    private void Awake() {
        Scene escenaActual = SceneManager.GetActiveScene ();
        string nombreEscena = escenaActual.name;
        Debug.Log("Escena actual: "+ nombreEscena);
        if(controlador == null)
        {
            controlador = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Escena actual1: "+ nombreEscena);
        }
        else if(controlador!=this)
        {
            Debug.Log("Escena actual2: "+ nombreEscena);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (contador == 0)
        {
            Scene escenaActual = SceneManager.GetActiveScene ();
            string nombreEscena = escenaActual.name;
            if(nombreEscena == "GameScene")
            {
                
                contador = 1;
                //crearPlano(casillas);
            }
        } 
        else
        {
            compruebaSinergias();
        }
    }

    //Ación al pulsar el botón Aceptar de Añadir nuevo jardín, cambia a la escena de juego y llama a crear plano
    public void escenaJuego()
    {
        int anchoN = getAncho();
        int largoN = getLargo();
        if(anchoN>10 || largoN>10 || nombreJardin==null || nombreJardin=="" || anchoN==0 || largoN==0)
        {
            textoError.SetActive(true);
        }
        else
        {
            float posX = 0;
            float posY = 0;
            float posZ = 0;
            casillas = new Vector3[anchoN,largoN];
            for(int x=0; x<anchoN; x++)
            {
                posY = 0;
                for(int y=0; y<largoN; y++)
                {
                    casillas[x,y] = new Vector3 (posX, posY, posZ);
                    posY = posY + 0.32f;
                }
                posX = posX + 0.32f;
            }
            
            bool correcto = panelPrincipal.GetComponent<PanelPrincipal>().activaSlot(nombreJardin, ancho + " X " + largo);

            if(correcto)
            {
                Debug.Log("ANTES");
                SceneManager.LoadScene("GameScene");
                Scene escenaActual = SceneManager.GetActiveScene();

                
                
                //crearPlano(casillas);

                Debug.Log("DESPUES");
                string nombreEscena = escenaActual.name;

                    
            }
            else
            {
                textoError.SetActive(true);
            }
            
        }
    }

    public void salir()
    {
        Application.Quit();
    }

    public void leerNombreJardin(string nj){
        nombreJardin = nj;
        Debug.Log("guardado en nombreJardin: "+nombreJardin);
    }

    //Método que utiliza el inputfiedl "ancho" y que obtiene un string del número que se ha introducido en ancho
    public void leerAncho(string a){
        ancho = a;
    }

    //Método que utiliza el inputfiedl "largo" y que obtiene un string del número que se ha introducido en largo
    public void leerLargo(string l){
        largo = l;
    }

    public Vector3[,] getCasillas()
    {
        return casillas;
    }

    public int getAncho()
    {
        if(ancho == null)
        {
            return 0;
        }
        try
        {
            return int.Parse(ancho);
        }
        catch (FormatException)
        {
            textoError.SetActive(true);
        }
        return 0;
    }

    public int getLargo()
    {
        if(largo == null)
        {
            return 0;
        }
        try
        {
            return int.Parse(largo);
        }
        catch (FormatException)
        {
            textoError.SetActive(true);
        }
        return 0;
    }

    public string getNombreJardin()
    {
        return nombreJardin;
    }

    public void anadirJardin()
    {
        formularioNuevoJardin.SetActive(true);
        panelPrincipal.SetActive(false);
    }

    public void cancelar()
    {
        panelPrincipal.SetActive(true);
        formularioNuevoJardin.SetActive(false);
    }
 
//------------------------------------------------------------------------------------------------------------
    public void compruebaSinergias()
    {
        int anchoN = getAncho();
        int largoN = getLargo();
        for(int x=0; x<anchoN; x++)
        {
            for(int y=0; y<largoN; y++)
            {
                String nombreCasillaActual = "Cesped" + x + y;
                GameObject casillaActual = GameObject.Find(nombreCasillaActual);
                Casilla casillaCespedActual = casillaActual.GetComponent<Casilla>();

                String nombreCasillaArriba = "Cesped" + x + (y+1);
                String nombreCasillaAbajo = "Cesped" + x + (y-1);
                String nombreCasillaDerecha = "Cesped" + (x+1) + y;
                String nombreCasillaIzquierda = "Cesped" + (x-1) + y;

                String nombreCasillaArribaDerecha = "Cesped" + (x+1) + (y+1);
                String nombreCasillaAbajoDerecha = "Cesped" + (x+1) + (y-1);
                String nombreCasillaArribaIzquierda = "Cesped" + (x-1) + (y+1);
                String nombreCasillaAbajoIzquierda = "Cesped" + (x-1) + (y-1);

                GameObject casillaArriba = GameObject.Find(nombreCasillaArriba);
                GameObject casillaAbajo = GameObject.Find(nombreCasillaAbajo);
                GameObject casillaDerecha = GameObject.Find(nombreCasillaDerecha);
                GameObject casillaIzquierda = GameObject.Find(nombreCasillaIzquierda);

                GameObject casillaArribaDerecha = GameObject.Find(nombreCasillaArribaDerecha);
                GameObject casillaAbajoDerecha = GameObject.Find(nombreCasillaAbajoDerecha);
                GameObject casillaArribaIzquierda = GameObject.Find(nombreCasillaArribaIzquierda);
                GameObject casillaAbajoIzquierda = GameObject.Find(nombreCasillaAbajoIzquierda);

                if(casillaAbajo!=null)
                {
                    Casilla casillaCespedAbajo = casillaAbajo.GetComponent<Casilla>();
                    int flechaAbajo = evaluaSinergias(casillaCespedActual, casillaCespedAbajo);
                    if(flechaAbajo == 1)
                    {
                        Color buena = new Color(0, 255, 255, 255);
                        casillaCespedActual.activarFlechaAbajo(buena);
                    }else if(flechaAbajo == 2)
                    {
                        Color mala = new Color(255, 0, 0, 255);
                        casillaCespedActual.activarFlechaAbajo(mala);
                    }
                    else if(flechaAbajo == 0)
                    {
                        casillaCespedActual.desactivarFlechaAbajo();
                    }
                }
                if(casillaDerecha!=null)
                {
                    Casilla casillaCespedDerecha = casillaDerecha.GetComponent<Casilla>();
                    int flechaDerecha = evaluaSinergias(casillaCespedActual, casillaCespedDerecha);
                    if(flechaDerecha == 1)
                    {
                        Color buena = new Color(0, 255, 255, 255);
                        casillaCespedActual.activarFlechaDerecha(buena);
                    }else if(flechaDerecha == 2)
                    {
                        Color mala = new Color(255, 0, 0, 255);
                        casillaCespedActual.activarFlechaDerecha(mala);
                    }
                    else if(flechaDerecha == 0)
                    {
                        casillaCespedActual.desactivarFlechaDerecha();
                    }
                }
                if(casillaArribaDerecha!=null)
                {
                    Casilla casillaCespedArribaDerecha = casillaArribaDerecha.GetComponent<Casilla>();
                    int flechaDArribaDerecha = evaluaSinergias(casillaCespedActual, casillaCespedArribaDerecha);
                    if(flechaDArribaDerecha == 1)
                    {
                        Color buena = new Color(0, 255, 255, 255);
                        casillaCespedActual.activarFlechaArribaDerecha(buena);
                    }else if(flechaDArribaDerecha == 2)
                    {
                        Color mala = new Color(255, 0, 0, 255);
                        casillaCespedActual.activarFlechaArribaDerecha(mala);
                    }
                    else if(flechaDArribaDerecha == 0)
                    {
                        casillaCespedActual.desactivarFlechaArribaDerecha();
                    }
                }
                if(casillaAbajoDerecha!=null)
                {
                    Casilla casillaCespedAbajoDerecha = casillaAbajoDerecha.GetComponent<Casilla>();
                    int flechaDAbajoDerecha = evaluaSinergias(casillaCespedActual, casillaCespedAbajoDerecha);
                    if(flechaDAbajoDerecha == 1)
                    {
                        Color buena = new Color(0, 255, 255, 255);
                        casillaCespedActual.activarFlechaAbajoDerecha(buena);
                    }else if(flechaDAbajoDerecha == 2)
                    {
                        Color mala = new Color(255, 0, 0, 255);
                        casillaCespedActual.activarFlechaAbajoDerecha(mala);
                    }
                    else if(flechaDAbajoDerecha == 0)
                    {
                        casillaCespedActual.desactivarFlechaAbajoDerecha();
                    }
                }
            }
        }
    }

    public int evaluaSinergias(Casilla a, Casilla b)
    {
        int sinergiaA = a.getSinergia();
        int sinergiaB = b.getSinergia();

        int [] listaBuenosVecinos = devuelveArrayBuenosVecinos(sinergiaA);
        int [] listaMalosVecinos = devuelveArrayMalosVecinos(sinergiaA);

        //Comprobamos si sinergiaB está dentro de la lista de buenos vecinos y si está devolvemos 1

        for(int x = 0; x<listaBuenosVecinos.Length; x++)
        {
            if(sinergiaB == listaBuenosVecinos[x])
            {
                return 1;
            }
        }

        //Comprobamos si sinergiaB está dentro de la lista de malos vecinos y si está devolvemos 2

        for(int x = 0; x<listaMalosVecinos.Length; x++)
        {
            if(sinergiaB == listaMalosVecinos[x])
            {
                return 2;
            }
        }
        return 0;
    }

    /*IMPORTANTE: El 17 es el tamaño de los arrays dentro del array general de vecinos, tanto buenos como malos
    por lo que si se añaden más plantas habría que aumentar este valor*/
    public int[] devuelveArrayMalosVecinos(int i)
    {
        int [] nuevaListaMalosVecinos = new int[17];
        for (int x = 0; x < 17; x++)
        {
            nuevaListaMalosVecinos [x] = listaMalosVecinos[i, x];
        }
        return nuevaListaMalosVecinos;
    }
    public int[] devuelveArrayBuenosVecinos(int i)
    {
        int [] nuevaListaBuenosVecinos = new int[17];
        for (int x = 0; x < 17; x++)
        {
            nuevaListaBuenosVecinos [x] = listaBuenosVecinos[i, x];
        }
        return nuevaListaBuenosVecinos;
    }

    public void leerFicheroYCargar(int numeroSlot)
    {
        //string linea ="";
        switch (numeroSlot)
        {
            case 1:
                //StreamReader streamReader1 = new StreamReader("/users/****/desktop/"+ PlayerPrefs.GetString("nombreJardin1") + ".txt");
                StreamReader streamReader1 = new StreamReader(Application.persistentDataPath + PlayerPrefs.GetString("nombreJardin1") + ".txt");
                nombreJardin = PlayerPrefs.GetString("nombreJardin1");
                for(int x = 0; x<2; x++)
                {
                    if(x==0)
                    {
                        ancho = streamReader1.ReadLine();
                    }
                    else
                    {
                        largo = streamReader1.ReadLine();
                    }
                }              
                escenaJuego();
                int[,] posicionesPlantasFichero = new int[getAncho(),getLargo()];
                for(int x = 0; x < getAncho(); x++)
                {
                    for(int y = 0; y < getLargo(); y++)
                    {
                        int id = int.Parse(streamReader1.ReadLine());
                        posicionesPlantasFichero[x,y] = id;
                    }
                }
                posicionesPlantas = posicionesPlantasFichero;
                break;
            case 2:
                //StreamReader streamReader2 = new StreamReader("/users/****/desktop/"+ PlayerPrefs.GetString("nombreJardin2") + ".txt");
                StreamReader streamReader2 = new StreamReader(Application.persistentDataPath + PlayerPrefs.GetString("nombreJardin2") + ".txt");
                nombreJardin = PlayerPrefs.GetString("nombreJardin2");
                for(int x = 0; x<2; x++)
                {
                    if(x==0)
                    {
                        ancho = streamReader2.ReadLine();
                    }
                    else
                    {
                        largo = streamReader2.ReadLine();
                    }
                }              
                escenaJuego();
                int[,] posicionesPlantasFichero2 = new int[getAncho(),getLargo()];
                for(int x = 0; x < getAncho(); x++)
                {
                    for(int y = 0; y < getLargo(); y++)
                    {
                        int id = int.Parse(streamReader2.ReadLine());
                        posicionesPlantasFichero2[x,y] = id;
                    }
                }
                posicionesPlantas = posicionesPlantasFichero2;
                break;
            case 3:
                //StreamReader streamReader3 = new StreamReader("/users/****/desktop/"+ PlayerPrefs.GetString("nombreJardin3") + ".txt");
                StreamReader streamReader3 = new StreamReader(Application.persistentDataPath + PlayerPrefs.GetString("nombreJardin3") + ".txt");
                nombreJardin = PlayerPrefs.GetString("nombreJardin3");
                for(int x = 0; x<2; x++)
                {
                    if(x==0)
                    {
                        ancho = streamReader3.ReadLine();
                    }
                    else
                    {
                        largo = streamReader3.ReadLine();
                    }
                }              
                escenaJuego();
                int[,] posicionesPlantasFichero3 = new int[getAncho(),getLargo()];
                for(int x = 0; x < getAncho(); x++)
                {
                    for(int y = 0; y < getLargo(); y++)
                    {
                        int id = int.Parse(streamReader3.ReadLine());
                        posicionesPlantasFichero3[x,y] = id;
                    }
                }
                posicionesPlantas = posicionesPlantasFichero3;
                break;
            case 4:
                //StreamReader streamReader4 = new StreamReader("/users/****/desktop/"+ PlayerPrefs.GetString("nombreJardin4") + ".txt");
                StreamReader streamReader4 = new StreamReader(Application.persistentDataPath + PlayerPrefs.GetString("nombreJardin4") + ".txt");
                nombreJardin = PlayerPrefs.GetString("nombreJardin4");
                for(int x = 0; x<2; x++)
                {
                    if(x==0)
                    {
                        ancho = streamReader4.ReadLine();
                    }
                    else
                    {
                        largo = streamReader4.ReadLine();
                    }
                }              
                escenaJuego();
                int[,] posicionesPlantasFichero4 = new int[getAncho(),getLargo()];
                for(int x = 0; x < getAncho(); x++)
                {
                    for(int y = 0; y < getLargo(); y++)
                    {
                        int id = int.Parse(streamReader4.ReadLine());
                        posicionesPlantasFichero4[x,y] = id;
                    }
                }
                posicionesPlantas = posicionesPlantasFichero4;
                break;
            case 5:
                //StreamReader streamReader5 = new StreamReader("/users/****/desktop/"+ PlayerPrefs.GetString("nombreJardin5") + ".txt");
                StreamReader streamReader5 = new StreamReader(Application.persistentDataPath + PlayerPrefs.GetString("nombreJardin5") + ".txt");
                nombreJardin = PlayerPrefs.GetString("nombreJardin5");
                for(int x = 0; x<2; x++)
                {
                    if(x==0)
                    {
                        ancho = streamReader5.ReadLine();
                    }
                    else
                    {
                        largo = streamReader5.ReadLine();
                    }
                }              
                escenaJuego();
                int[,] posicionesPlantasFichero5 = new int[getAncho(),getLargo()];
                for(int x = 0; x < getAncho(); x++)
                {
                    for(int y = 0; y < getLargo(); y++)
                    {
                        int id = int.Parse(streamReader5.ReadLine());
                        posicionesPlantasFichero5[x,y] = id;
                    }
                }
                posicionesPlantas = posicionesPlantasFichero5;
                break;
            default:
                break;
        }
    }

    public int [,] getPosicionesPlantas()
    {
        return posicionesPlantas;
    }
}