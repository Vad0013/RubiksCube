using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    
    //Размер кубика
    public int size = 5;

    //Трансформ самого куба
    public Transform Rubik;
    public Transform MCollider;

    //Трансформ, хранящий кубики
    public Transform Cubes;

    public static Transform CubesStatic;
    public static Transform MColliderStatic;

    //Трансформы осей; X1 или Z1
    public static Dictionary<string, Transform> axis = new Dictionary<string, Transform>();
    public static List<CubeMain> cubiks = new List<CubeMain>(); //Содержит все кубики
    
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateAxis();
        GenerateCubes();

        CubesStatic = Cubes; 
        MColliderStatic = MCollider;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Создание кубиков
    public void GenerateCubes(){
        //Загружает префаб куба
        GameObject axis = Resources.Load<GameObject>("Prefabs/OneCube");

        GenerateCubesTop(axis);
        GenerateCubesBottom(axis);
        GenerateCubesSide1(axis);
        GenerateCubesSide2(axis);
        GenerateCubesSide3(axis);
        GenerateCubesSide4(axis);
    }

    //Генерирует кубики сверху
    void GenerateCubesTop(GameObject obj){

        //Границы кубика
        int min = -(int)size/2;
        int max = (int)size/2;
        
        //Заполняет полость кубиками
        for(int i = min; i <= max; i++){
            for(int j = min; j <= max; j++){
                
                GameObject cube = Instantiate(obj, new Vector3(i, max, j), new Quaternion());

                //Установка родителя
                cube.transform.SetParent(Cubes);

                //Получение данных о кубике
                CubeMain cubem = cube.GetComponent<CubeMain>();

                cubem.axisX = CubeGenerator.axis["X" + i];
                cubem.axisZ = CubeGenerator.axis["Z" + j];
                cubem.axisY = CubeGenerator.axis["Y" + max];

                cubem._nameX = "X" + i;
                cubem._nameZ = "Z" + j;
                cubem._nameY = "Y" + max;

                CubeGenerator.cubiks.Add(cubem);
            }
        }

    }

    //Генерирует кубики cнизу
    void GenerateCubesBottom(GameObject obj){

        //Границы кубика
        int min = -(int)size/2;
        int max = (int)size/2;
        
        //Заполняет полость кубиками
        for(int i = min; i <= max; i++){
            for(int j = min; j <= max; j++){
                
                GameObject cube = Instantiate(obj, new Vector3(i, min, j), new Quaternion());

                //Установка родителя
                cube.transform.SetParent(Cubes);

                //Получение данных о кубике
                CubeMain cubem = cube.GetComponent<CubeMain>();

                cubem.axisX = CubeGenerator.axis["X" + i];
                cubem.axisZ = CubeGenerator.axis["Z" + j];
                cubem.axisY = CubeGenerator.axis["Y" + min];

                cubem._nameX = "X" + i;
                cubem._nameZ = "Z" + j;
                cubem._nameY = "Y" + min;

                CubeGenerator.cubiks.Add(cubem);
            }
        }

    }

    //Генерирует кубики c одного бока
    void GenerateCubesSide1(GameObject obj){

        //Границы кубика
        int min = -(int)size/2;
        int max = (int)size/2;
        
        //Заполняет полость кубиками
        for(int i = min + 1; i <= max - 1; i++){
            for(int j = min; j <= max; j++){
                
                GameObject cube = Instantiate(obj, new Vector3(j, i, max), new Quaternion());

                //Установка родителя
                cube.transform.SetParent(Cubes);

                //Получение данных о кубике
                CubeMain cubem = cube.GetComponent<CubeMain>();

                cubem.axisX = CubeGenerator.axis["X" + j];
                cubem.axisZ = CubeGenerator.axis["Z" + max];
                cubem.axisY = CubeGenerator.axis["Y" + i];

                cubem._nameX = "X" + j;
                cubem._nameZ = "Z" + max;
                cubem._nameY = "Y" + i;

                CubeGenerator.cubiks.Add(cubem);
            }
        }

    }

    //Генерирует кубики c третьего бока
    void GenerateCubesSide3(GameObject obj){

        //Границы кубика
        int min = -(int)size/2;
        int max = (int)size/2;
        
        //Заполняет полость кубиками
        for(int i = min + 1; i <= max - 1; i++){
            for(int j = min; j <= max; j++){
                
                GameObject cube = Instantiate(obj, new Vector3(j, i, min), new Quaternion());

                //Установка родителя
                cube.transform.SetParent(Cubes);

                //Получение данных о кубике
                CubeMain cubem = cube.GetComponent<CubeMain>();

                cubem.axisX = CubeGenerator.axis["X" + j];
                cubem.axisZ = CubeGenerator.axis["Z" + min];
                cubem.axisY = CubeGenerator.axis["Y" + i];

                cubem._nameX = "X" + j;
                cubem._nameZ = "Z" + min;
                cubem._nameY = "Y" + i;

                CubeGenerator.cubiks.Add(cubem);
            }
        }

    }

    //Генерирует кубики со второго бока
    void GenerateCubesSide2(GameObject obj){

        //Границы кубика
        int min = -(int)size/2;
        int max = (int)size/2;
        
        //Заполняет полость кубиками
        for(int i = min + 1; i <= max - 1; i++){
            for(int j = min + 1; j <= max - 1; j++){
                
                GameObject cube = Instantiate(obj, new Vector3(max, i, j), new Quaternion());

                //Установка родителя
                cube.transform.SetParent(Cubes);

                //Получение данных о кубике
                CubeMain cubem = cube.GetComponent<CubeMain>();

                cubem.axisX = CubeGenerator.axis["X" + max];
                cubem.axisZ = CubeGenerator.axis["Z" + j];
                cubem.axisY = CubeGenerator.axis["Y" + i];

                cubem._nameX = "X" + max;
                cubem._nameZ = "Z" + j;
                cubem._nameY = "Y" + i;

                CubeGenerator.cubiks.Add(cubem);
            }
        }

    }

    //Генерирует кубики с четвёртого бока
    void GenerateCubesSide4(GameObject obj){

        //Границы кубика
        int min = -(int)size/2;
        int max = (int)size/2;
        
        //Заполняет полость кубиками
        for(int i = min + 1; i <= max - 1; i++){
            for(int j = min + 1; j <= max - 1; j++){
                
                GameObject cube = Instantiate(obj, new Vector3(min, i, j), new Quaternion());

                //Установка родителя
                cube.transform.SetParent(Cubes);

                //Получение данных о кубике
                CubeMain cubem = cube.GetComponent<CubeMain>();

                cubem.axisX = CubeGenerator.axis["X" + min];
                cubem.axisZ = CubeGenerator.axis["Z" + j];
                cubem.axisY = CubeGenerator.axis["Y" + i];

                cubem._nameX = "X" + min;
                cubem._nameZ = "Z" + j;
                cubem._nameY = "Y" + i;

                CubeGenerator.cubiks.Add(cubem);
            }
        }

    }


    //Создание осей
    public void GenerateAxis()
    {
        //Загружает префаб оси
        GameObject axis = Resources.Load<GameObject>("Prefabs/Axis");
        axis.transform.localScale = new Vector3(1, size, size); //Устанавливает размер

        //Генерирует оси по X
        for(int i = -(int)size/2; i <= (int)size/2; i++){
            GameObject ax = Instantiate(axis, new Vector3(i, 0, 0), new Quaternion());

            //Установка родителя
            ax.transform.SetParent(Rubik);

            //Добавляет в данные об осях
            CubeGenerator.axis.Add("X" + i, ax.transform);

            ax.GetComponent<Axis>().Name = "X" + i;
        }

        //Генерирует оси по Z
        for(int i = -(int)size/2; i <= (int)size/2; i++){
            GameObject ax = Instantiate(axis, new Vector3(0, 0, i), Quaternion.Euler(0, 90, 0));

            //Установка родителя
            ax.transform.SetParent(Rubik);

            //Добавляет в данные об осях
            CubeGenerator.axis.Add("Z" + i, ax.transform);

            ax.GetComponent<Axis>().Name = "Z" + i;

            ax.GetComponent<Axis>().name = "Z" + i;
        }

        //Генерирует оси по y
        for(int i = -(int)size/2; i <= (int)size/2; i++){
            GameObject ax = Instantiate(axis, new Vector3(0, i, 0), Quaternion.Euler(0, 0, 90));

            //Установка родителя
            ax.transform.SetParent(Rubik);

            //Добавляет в данные об осях
            CubeGenerator.axis.Add("Y" + i, ax.transform);

            ax.GetComponent<Axis>().Name = "Y" + i;
            ax.GetComponent<Axis>().name = "Y" + i;
        }
    }


    //Получение всех данных о кубиках на оси
    public static List<CubeMain> GetCubiksOnAxis(string axis){

        List<CubeMain> a = CubeGenerator.cubiks.FindAll(x => x._nameX == axis || x._nameY == axis || x._nameZ == axis);
        Debug.Log(axis);
        return a;
    }
}



public static class Extra
{
    ///<summary>
    ///Возвращает список всех дочерних трансформов у родителя
    ///</summary>
    public static List<Transform> GetChilds(this Transform transform){

        List<Transform> childs = new List<Transform>();
        
        for(int i = 0; i != transform.childCount; i++){
            childs.Add(transform.GetChild(i));
        }

        return childs;

    }

    

    ///<summary>
    ///Меняет имя, если оно равно первому значению
    ///</summary>
    public static void TryChangeName(this Transform transform, params string[] keyVal){
        
        foreach(string str in keyVal){
            var v = str.Split(':');
            if(transform.name == v[0]){
                transform.name = v[1];
                break;
            }
        }

    }

    public static string TryChangeChar(this char str, params string[] keyVal){
        
        foreach(string stre in keyVal){
            var v = stre.Split(':');

            if("" + str == v[0]){
                return v[1];
            }


        }

        return str.ToString();
    }
}
