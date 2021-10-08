using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Procedural : MonoBehaviour
{
    public int x, z;
    public int[,] matrizJuego;
    public int[,] matrizBloques;
    public Vector2 distancias;
    public Transform jugador;
    public Transform posLlave;
    public GameObject cuarto;
    public string nombre;
    public int nombreSemilla;
    public System.Random r;

    void Start(){
        crearMundo();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void crearMundo(){
        GeneradorSemilla();
        matrizJuego = new int[x, z];
        matrizBloques = new int[x, z];
        TrazarRuta();
        DeterminarHabitaciones();
        CrearHabitaciones();
    }

    void TrazarRuta(){
        int puntoInicio = Aleatorio(0, x);   //acá usariamos la semilla CAMBIAR     
        int puntoFinal = Aleatorio(0, x);

        int[] puntoFlotante = { puntoInicio, z - 1 };
        while (!(puntoFlotante[0] == puntoFinal && puntoFlotante[1] == 0)){ //sigo moviendo hasta encontrar la meta
            int movimiento;
            bool repetir = false;
            do
            {
                repetir = false;
                movimiento = Aleatorio(1, 4);

                if (movimiento == 1) { //movimiento a la derecha
                    puntoFlotante[0]++;
                    if (puntoFlotante[0] >= x){
                        puntoFlotante[0]--;
                        repetir = true;
                    }
                } else if (movimiento==2){//movimiento abajo
                    puntoFlotante[1]--;
                    if (puntoFlotante[1] < 0)
                    {
                        puntoFlotante[1]++;
                        repetir = true;
                    }
                }
                else if (movimiento == 3){//movimiento izquierda
                    puntoFlotante[0]--;
                    if (puntoFlotante[0] < 0)
                    {
                        puntoFlotante[0]++;
                        repetir = true;
                    }
                }

            } while (repetir);
            matrizJuego[puntoFlotante[0], puntoFlotante[1]] = 3;
        }

        int[] llave = { Aleatorio(0, x), Aleatorio(0, z-1) }; //genero una posicion para la llave
        matrizJuego[llave[0], llave[1]] = 4;

        if (ValorHabitaciones(llave[0],llave[1])==0){//creo habitacion con llave
            int col = -1;
            for (int i = 0; i < x; i++){
                if (matrizJuego[i,llave[1]] != 0 && i != llave[0]){
                    col = i;
                    break;
                }
            }
            if (col > llave[0])
            {
                for (int i = llave[0]+1; i < col; i++)
                {
                    matrizJuego[i, llave[1]] = 3;
                }
            } else {
                for (int i = col; i < llave[0]; i++)
                {
                    matrizJuego[i, llave[1]] = 3;
                }
            }
        }

        matrizJuego[puntoInicio, z - 1] = 1;
        matrizJuego[puntoFinal, 0] = 2;

        jugador.position = new Vector3(puntoInicio * distancias.x, 0.5f, (z - 1) * distancias.y); //llevo al jugador a la habitacion inicial
        posLlave.position = new Vector3(llave[0] * distancias.x, 0.5f, llave[1] * distancias.y);
    }

    private void OnDrawGizmos(){
        if (matrizJuego == null){
            return;
        }
        for (int i = 0; i < x; i++){
            for (int j = 0; j < z; j++){
                if (matrizJuego[i,j] == 0){ //pinto dependiendo del valor que encuentre
                    Gizmos.color = Color.black;  
                }else if((matrizJuego[i, j] == 1)){
                    Gizmos.color = Color.green;
                }else if ((matrizJuego[i, j] == 2)){
                    Gizmos.color = Color.red;
                }else if ((matrizJuego[i, j] == 3)){
                    Gizmos.color = Color.white;
                }else if ((matrizJuego[i, j] == 4))
                {
                    Gizmos.color = Color.blue;
                }
                //Gizmos.DrawCube(new Vector3(i * 1, 0, j * 1), Vector3.one * 1);
            }
        }
    }

    void DeterminarHabitaciones(){// calculo la habitacion necesaria para el camino
        for (int i = 0; i < x; i++){
            for (int j = 0; j < z; j++){
                matrizBloques[i, j] = ValorHabitaciones(i, j);
            }
        }
    }

    public int ValorHabitaciones(int i, int j){
        int resultado = 0;
        resultado += 1 * saberSihayBloque(i, j + 1);
        resultado += 2 * saberSihayBloque(i + 1, j);
        resultado += 4 * saberSihayBloque(i, j - 1);
        resultado += 8 * saberSihayBloque(i - 1, j);
        return resultado;
    }

    void CrearHabitaciones(){
        for (int i = 0; i < x; i++){
            for (int j = 0; j < z; j++){
                if (matrizJuego[i,j]!=0){
                    GameObject objetoCuarto = Instantiate(cuarto, new Vector3(i * distancias.x, 0, j * distancias.y), Quaternion.identity) as GameObject;
                    objetoCuarto.GetComponent<Habitaciones>().Inicializar(matrizBloques[i,j]);
                }
            }
        }
    }

    public int saberSihayBloque(int _x, int _z){
        if (_x < 0 || _z < 0 || _x >= x || _z >= z){
            return 0;
        }
        if (matrizJuego[_x,_z] == 0){
            return 0;
        }
        return 1;
    }


    public void GeneradorSemilla() {
        for (int i = 0; i < nombre.Length; i++)
        {
            nombreSemilla += (int)nombre[i];
        }
        r = new System.Random(nombreSemilla);
    }

    public int Aleatorio(int x, int y){
        //int random = new Random();
        return r.Next(x, y);
    }
}

