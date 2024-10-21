using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAxis : MonoBehaviour
{
    
    public Camera mainCamera;


    public Vector2 startHitPos; //Начальная позиция рейкаста
    public Vector2 secondHitPos; //Начальная позиция рейкаста

    public bool CanBeClicked = true;

    public string side; // Имя стороны кубика
    public GameObject cube; //Ссылка на куб

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        //if(Physics.Raycast(ray, out RaycastHit hit)){
        //    hit.collider.transform.GetComponent<Axis>().SetRay();

            
        //}

        CalculateOffset();
    }

    //Получение смещения луча мыши
    void GetStartOffset(){
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        //Получение кубика и коллайдера
        if(Physics.Raycast(ray, out RaycastHit hit)){
            //startHitPos = hit.textureCoord;
            side = hit.collider.gameObject.name;
            cube = hit.collider.transform.parent.gameObject;

            cube.GetComponent<CubeMain>().CreateCollider(side);
            
        }

        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //Получение смещения кубика
        if(Physics.Raycast(ray, out RaycastHit hit2)){
            startHitPos = ChangePos(hit2.point);

            Debug.Log(startHitPos);
        }
    }


    //Получение второй точки для высчитывания смещения
    void GetSecondOffset(){
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out RaycastHit hit)){
            secondHitPos = ChangePos(hit.point);

            Debug.Log(secondHitPos);
        }
    }

    //Получение смещения
    public string GetOffsetChange(){

        Vector2 newvector = secondHitPos - startHitPos;

        Vector2 absV = new Vector2(Mathf.Abs(newvector.x), Mathf.Abs(newvector.y));
        
        float x = Mathf.Max(absV.x, absV.y);

        if(x == absV.x) return "X" + GetPlusOrMinusV(startHitPos.x, secondHitPos.x);
        else return "Y" + GetPlusOrMinusV(startHitPos.y, secondHitPos.y);
    }


    //Вычисление смещения
    public void CalculateOffset(){
        //Нажатие на кнопку
        if(Input.GetMouseButtonDown(0)){
            GetStartOffset();

            CanBeClicked = true;
        }

        //Кнопка зажата
        if(Input.GetMouseButton(0) & CanBeClicked){
            GetSecondOffset();
            if((secondHitPos - startHitPos).magnitude > 0.5f){
                //Debug.Log(GetOffsetChange());

                //Получение названия трансформа вращения
                string a = cube.GetComponent<CubeMain>().GetAxis(side, GetOffsetChange());

                Debug.Log(a);

                //Поворот 
                CubeGenerator.axis[a.Split('|')[0]].GetComponent<Axis>().RotateAxis(a.Split('|')[1]);

                CanBeClicked = false;

                CubeGenerator.MColliderStatic.position = new Vector3(0, -100, 0);
            }   
            
        }
    }


    //Получение стороны перемещения
    public string GetPlusOrMinus(float f){

        if(f > 0) return "M";
        else return "P";
    }

    public string GetPlusOrMinusV(float one, float sec){

        if(one > sec) return "M";
        else return "P";
    }


    public Vector2 ChangePos(Vector3 vector){

        switch(side){
            case "Side2":
                return new Vector2(vector.z, vector.y);
            case "Side4":
                return new Vector2(vector.z, vector.y);
            case "Side1":
                return new Vector2(vector.x, vector.y);
            case "Side3":
                return new Vector2(vector.x, vector.y);
            case "Top":
                return new Vector2(vector.z, vector.x);
            case "Bottom":
                return new Vector2(vector.z, vector.x);
            default:
                return new Vector2();
        }

    }

}
