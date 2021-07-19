using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PanelPrincipal : MonoBehaviour
{
    public GameObject controlador;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;

    public Text nombreJardin1;
    public Text dimensionJardin1;
    public Text nombreJardin2;
    public Text dimensionJardin2;
    public Text nombreJardin3;
    public Text dimensionJardin3;
    public Text nombreJardin4;
    public Text dimensionJardin4;
    public Text nombreJardin5;
    public Text dimensionJardin5;

    private int slot1Ocupado = 0;
    private int slot2Ocupado = 0;
    private int slot3Ocupado = 0;
    private int slot4Ocupado = 0;
    private int slot5Ocupado = 0;


    void Start()
    {
        cargar1();
        cargar2();
        cargar3();
        cargar4();
        cargar5();
        compruebaEstadoSlots();
    }
    public bool activaSlot(string nombre, string dimensiones)
    {
        if(nombre!=getNombre1() && nombre!=getNombre2() && nombre!=getNombre3() && nombre!=getNombre4() && nombre!=getNombre5())
        {
            if(slot1Ocupado==0)
            {
                slot1.SetActive(true);
                setNombre1(nombre);
                setDimensiones1(dimensiones);
                slot1Ocupado = 1;
                guardar1();
                return true;
            }
            if(slot2Ocupado==0)
            {
                slot2.SetActive(true);
                setNombre2(nombre);
                setDimensiones2(dimensiones);
                slot2Ocupado = 1;
                guardar2();
                return true;
            } 
            if(slot3Ocupado==0)
            {
                slot3.SetActive(true);
                setNombre3(nombre);
                setDimensiones3(dimensiones);
                slot3Ocupado = 1;
                guardar3();
                return true;
            } 
            if(slot4Ocupado==0)
            {
                slot4.SetActive(true);
                setNombre4(nombre);
                setDimensiones4(dimensiones);
                slot4Ocupado = 1;
                guardar4();
                return true;
            } 
            if(slot5Ocupado==0)
            {
                slot5.SetActive(true);
                setNombre5(nombre);
                setDimensiones5(dimensiones);
                slot5Ocupado = 1;
                guardar5();
                return true;
            }
            return false;
        }
        else{
            return true;
        } 
    }


    public void setNombre1(string nombre)
    {
        nombreJardin1.text = nombre;
    }

    public string getNombre1()
    {
        return nombreJardin1.text;
    }

    public void setDimensiones1(string dimensiones)
    {
        dimensionJardin1.text = dimensiones;
    }

    public string getDimensiones1()
    {
        return dimensionJardin1.text;
    }

    public void setNombre2(string nombre)
    {
        nombreJardin2.text = nombre;
    }

    public string getNombre2()
    {
        return nombreJardin2.text;
    }

    public void setDimensiones2(string dimensiones)
    {
        dimensionJardin2.text = dimensiones;
    }

    public string getDimensiones2()
    {
        return dimensionJardin2.text;
    }

    public void setNombre3(string nombre)
    {
        nombreJardin3.text = nombre;
    }

    public string getNombre3()
    {
        return nombreJardin3.text;
    }

    public void setDimensiones3(string dimensiones)
    {
        dimensionJardin3.text = dimensiones;
    }

    public string getDimensiones3()
    {
        return dimensionJardin3.text;
    }

    public void setNombre4(string nombre)
    {
        nombreJardin4.text = nombre;
    }

    public string getNombre4()
    {
        return nombreJardin4.text;
    }

    public void setDimensiones4(string dimensiones)
    {
        dimensionJardin4.text = dimensiones;
    }

    public string getDimensiones4()
    {
        return dimensionJardin4.text;
    }

    public void setNombre5(string nombre)
    {
        nombreJardin5.text = nombre;
    }

    public string getNombre5()
    {
        return nombreJardin5.text;
    }

    public void setDimensiones5(string dimensiones)
    {
        dimensionJardin5.text = dimensiones;
    }

    public string getDimensiones5()
    {
        return dimensionJardin5.text;
    }

    public void guardar1()
    {
        PlayerPrefs.SetString("nombreJardin1", nombreJardin1.text);
        PlayerPrefs.SetString("dimensionJardin1", dimensionJardin1.text);
        PlayerPrefs.SetInt("slot1Ocupado", slot1Ocupado);
        PlayerPrefs.Save();
    }
    public void guardar2()
    {
        PlayerPrefs.SetString("nombreJardin2", nombreJardin2.text);
        PlayerPrefs.SetString("dimensionJardin2", dimensionJardin2.text);
        PlayerPrefs.SetInt("slot2Ocupado", slot2Ocupado);
        PlayerPrefs.Save();
    }
    public void guardar3()
    {
        PlayerPrefs.SetString("nombreJardin3", nombreJardin3.text);
        PlayerPrefs.SetString("dimensionJardin3", dimensionJardin3.text);
        PlayerPrefs.SetInt("slot3Ocupado", slot3Ocupado);
        PlayerPrefs.Save();
    }
    public void guardar4()
    {
        PlayerPrefs.SetString("nombreJardin4", nombreJardin4.text);
        PlayerPrefs.SetString("dimensionJardin4", dimensionJardin4.text);
        PlayerPrefs.SetInt("slot4Ocupado", slot4Ocupado);
        PlayerPrefs.Save();
    }
    public void guardar5()
    {
        PlayerPrefs.SetString("nombreJardin5", nombreJardin5.text);
        PlayerPrefs.SetString("dimensionJardin5", dimensionJardin5.text);
        PlayerPrefs.SetInt("slot5Ocupado", slot5Ocupado);
        PlayerPrefs.Save();
    }

    public void cargar1()
    {
        nombreJardin1.text = PlayerPrefs.GetString("nombreJardin1");
        dimensionJardin1.text = PlayerPrefs.GetString("dimensionJardin1");
        slot1Ocupado = PlayerPrefs.GetInt("slot1Ocupado");
        if(slot1Ocupado==0)
        {
            slot1.SetActive(false);
        }
    }

    public void cargar2()
    {
        nombreJardin2.text = PlayerPrefs.GetString("nombreJardin2");
        dimensionJardin2.text = PlayerPrefs.GetString("dimensionJardin2");
        slot2Ocupado = PlayerPrefs.GetInt("slot2Ocupado");
        if(slot2Ocupado==0)
        {
            slot2.SetActive(false);
        }
    }
    public void cargar3()
    {
        nombreJardin3.text = PlayerPrefs.GetString("nombreJardin3");
        dimensionJardin3.text = PlayerPrefs.GetString("dimensionJardin3");
        slot3Ocupado = PlayerPrefs.GetInt("slot3Ocupado");
        if(slot3Ocupado==0)
        {
            slot3.SetActive(false);
        }
    }
    public void cargar4()
    {
        nombreJardin4.text = PlayerPrefs.GetString("nombreJardin4");
        dimensionJardin4.text = PlayerPrefs.GetString("dimensionJardin4");
        slot4Ocupado = PlayerPrefs.GetInt("slot4Ocupado");
        if(slot4Ocupado==0)
        {
            slot4.SetActive(false);
        }
    }
    public void cargar5()
    {
        nombreJardin5.text = PlayerPrefs.GetString("nombreJardin5");
        dimensionJardin5.text = PlayerPrefs.GetString("dimensionJardin5");
        slot5Ocupado = PlayerPrefs.GetInt("slot5Ocupado");
        if(slot5Ocupado==0)
        {
            slot5.SetActive(false);
        }
    }

    public void compruebaEstadoSlots()
    {
        if(slot1Ocupado==1)
        {
            slot1.SetActive(true);
        }
        if(slot2Ocupado==1)
        {
            slot2.SetActive(true);
        }
        if(slot3Ocupado==1)
        {
            slot3.SetActive(true);
        }
        if(slot4Ocupado==1)
        {
            slot4.SetActive(true);
        }
        if(slot5Ocupado==1)
        {
            slot5.SetActive(true);
        }
    }

    public void borrarPlayerPref(int numeroSlot)
    {
        switch (numeroSlot)
        {
            case 1:
                //File.Delete("/users/****/desktop/"+ PlayerPrefs.GetString("nombreJardin1") + ".txt");
                File.Delete(Application.persistentDataPath + PlayerPrefs.GetString("nombreJardin1") + ".txt");
                PlayerPrefs.DeleteKey("nombreJardin1");
                PlayerPrefs.DeleteKey("dimensionJardin1");
                PlayerPrefs.DeleteKey("slot1Ocupado");
                slot1.SetActive(false);
                slot1Ocupado=0;
                break;
            case 2:
                //File.Delete("/users/****/desktop/"+ PlayerPrefs.GetString("nombreJardin2") + ".txt");
                File.Delete(Application.persistentDataPath + PlayerPrefs.GetString("nombreJardin2") + ".txt");
                PlayerPrefs.DeleteKey("nombreJardin2");
                PlayerPrefs.DeleteKey("dimensionJardin2");
                PlayerPrefs.DeleteKey("slot2Ocupado");
                slot2.SetActive(false);
                slot2Ocupado=0;
                break;
            case 3:
                //File.Delete("/users/****/desktop/"+ PlayerPrefs.GetString("nombreJardin3") + ".txt");
                File.Delete(Application.persistentDataPath + PlayerPrefs.GetString("nombreJardin3") + ".txt");
                PlayerPrefs.DeleteKey("nombreJardin3");
                PlayerPrefs.DeleteKey("dimensionJardin3");
                PlayerPrefs.DeleteKey("slot3Ocupado");
                slot3.SetActive(false);
                slot3Ocupado=0;
                break;
            case 4:
                //File.Delete("/users/****/desktop/"+ PlayerPrefs.GetString("nombreJardin4") + ".txt");
                File.Delete(Application.persistentDataPath + PlayerPrefs.GetString("nombreJardin4") + ".txt");
                PlayerPrefs.DeleteKey("nombreJardin4");
                PlayerPrefs.DeleteKey("dimensionJardin4");
                PlayerPrefs.DeleteKey("slot4Ocupado");
                slot4.SetActive(false);
                slot4Ocupado=0;
                break;
            case 5:
                //File.Delete("/users/****/desktop/"+ PlayerPrefs.GetString("nombreJardin5") + ".txt");
                File.Delete(Application.persistentDataPath + PlayerPrefs.GetString("nombreJardin5") + ".txt");
                PlayerPrefs.DeleteKey("nombreJardin5");
                PlayerPrefs.DeleteKey("dimensionJardin5");
                PlayerPrefs.DeleteKey("slot5Ocupado");
                slot5.SetActive(false);
                slot5Ocupado=0;
                break;
            default:
                
                break;
        }

    }
    
}
