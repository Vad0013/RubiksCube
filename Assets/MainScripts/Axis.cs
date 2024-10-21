using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    
    private bool IsHit = false;

    public string Name; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetRay();
    }

    //
    public void SetRay(){
        IsHit = true;
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
    }

    //Получает информацию о наведении
    void GetRay()
    {
        if(IsHit){
            IsHit = false;
        }
        else{
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0);
        }
    }


    //Вращение оси
    public void RotateAxis(string MoP){
        

        
        
        //transform.Rotate(90, 0, 0);
        if(MoP == "P")
            StartCoroutine(ChangeRotatePlus());
        else StartCoroutine(ChangeRotateMinus());

        
    }

    //Установка парентов
    public void SetCubeParent(List<CubeMain> cubes){

        cubes.ForEach(x => x.transform.SetParent(transform));

    }


    //Уборка парэнтов
    public void DesetCubeParent(List<CubeMain> cubes){
        
        cubes.ForEach(x => x.transform.SetParent(CubeGenerator.CubesStatic));

    }


    //Изменение положения у всех кубиков
    public void ChangeCubePositions(List<CubeMain> cubes){

        foreach(CubeMain x in cubes){

            

            x._nameX = "X" + Mathf.Round(x.transform.position.x);
            x._nameZ = "Z" + Mathf.Round(x.transform.position.z);
            x._nameY = "Y" + Mathf.Round(x.transform.position.y);

            Debug.Log(x._nameY);

            x.axisX = CubeGenerator.axis[x._nameX];
            x.axisZ = CubeGenerator.axis[x._nameZ];
            x.axisY = CubeGenerator.axis[x._nameY];

        }


    }


    public void ChangeSides(List<CubeMain> cubes, string MoP){

        switch(Name[0] + MoP){
            case "YM":
                 cubes.ForEach(x => {
                    var y = x.transform;
                    y.GetChilds().ForEach(a => {
                        a.TryChangeName("Side1:Side2", "Side2:Side3", "Side3:Side4", "Side4:Side1");
                    });
                 });
                 break;
            case "ZP":
                 cubes.ForEach(x => {
                    var y = x.transform;
                    y.GetChilds().ForEach(a => {
                        a.TryChangeName("Top:Side4", "Side4:Bottom", "Bottom:Side2", "Side2:Top");
                    });
                 });
                 break;
            case "XP":
                 cubes.ForEach(x => {
                    var y = x.transform;
                    y.GetChilds().ForEach(a => {
                        a.TryChangeName("Top:Side1", "Side1:Bottom", "Bottom:Side3", "Side3:Top");
                    });
                 });
                 break;
            case "YP":
                 cubes.ForEach(x => {
                    var y = x.transform;
                    y.GetChilds().ForEach(a => {
                        a.TryChangeName("Side1:Side4", "Side4:Side3", "Side3:Side2", "Side2:Side1");
                    });
                 });
                 break;
            case "ZM":
                 cubes.ForEach(x => {
                    var y = x.transform;
                    y.GetChilds().ForEach(a => {
                        a.TryChangeName("Top:Side2", "Side2:Bottom", "Bottom:Side4", "Side4:Top");
                    });
                 });
                 break;
            case "XM":
                 cubes.ForEach(x => {
                    var y = x.transform;
                    y.GetChilds().ForEach(a => {
                        a.TryChangeName("Top:Side3", "Side3:Bottom", "Bottom:Side1", "Side1:Top");
                    });
                 });
                 break;
        }

    }


    IEnumerator ChangeRotatePlus(){

        int r = 0;
        
        List<CubeMain> cubes = CubeGenerator.GetCubiksOnAxis(Name);

        //Установка кубиков во вращательный объект
        this.SetCubeParent(cubes);

        while(r != 90){
            transform.Rotate(5, 0, 0);

            r += 5;
            yield return null;
        }


        DesetCubeParent(cubes);

        ChangeCubePositions(cubes);

        ChangeSides(cubes, "P");

        transform.Rotate(-90, 0, 0);

        yield break;


    }

    IEnumerator ChangeRotateMinus(){

        int r = 0;
        
        List<CubeMain> cubes = CubeGenerator.GetCubiksOnAxis(Name);

        //Установка кубиков во вращательный объект
        this.SetCubeParent(cubes);

        while(r != 90){
            transform.Rotate(-5, 0, 0);

            r += 5;
            yield return null;
        }


        DesetCubeParent(cubes);

        ChangeCubePositions(cubes);

        ChangeSides(cubes, "M");

        transform.Rotate(90, 0, 0);

        yield break;


    }
}
