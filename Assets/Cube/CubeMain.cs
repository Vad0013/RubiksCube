using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMain : MonoBehaviour
{
    
    //Ссылка на ось вращения
    public Transform axisZ;
    public Transform axisX;
    public Transform axisY;

    //Названия осей
    public string _nameZ;
    public string _nameX;
    public string _nameY;

    //Смещения осей коллайдера
    public int _offsetZ;
    public int _offsetX;
    public int _offsetY;

    //Отрицательные или не отрицательные
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Получение оси по стороне и смещению
    public string GetAxis(string side, string vector){

        switch(side){
            case "Side1":
                if(vector[0] == 'Y') return this._nameX + "|" + vector[1].TryChangeChar("P:M", "M:P");
                else return this._nameY + "|" + vector[1];
            case "Side2":
                if(vector[0] == 'Y') return this._nameZ + "|" + vector[1];
                else return this._nameY + "|" + vector[1];
            case "Side3":
                if(vector[0] == 'Y') return this._nameX + "|" + vector[1];
                else return this._nameY + "|" + vector[1].TryChangeChar("P:M", "M:P");
            case "Side4":
                if(vector[0] == 'Y') return this._nameZ + "|" + vector[1].TryChangeChar("P:M", "M:P");
                else return this._nameY + "|" + vector[1].TryChangeChar("P:M", "M:P");
            case "Top":
                if(vector[0] == 'Y') return this._nameZ + "|" + vector[1];
                else return this._nameX + "|" + vector[1];
            case "Bottom":
                if(vector[0] == 'Y') return this._nameZ + "|" + vector[1].TryChangeChar("P:M", "M:P");
                else return this._nameX + "|" + vector[1].TryChangeChar("P:M", "M:P");
            default:
                return null;
        }

    }


    //Устанавливает коллайдер в нужное месте
    public void CreateCollider(string side){
        switch(side){
            case "Side1":
                CubeGenerator.MColliderStatic.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.51f);
                CubeGenerator.MColliderStatic.rotation = Quaternion.Euler(-90, 90, 90);
                break;
            case "Side2":
                CubeGenerator.MColliderStatic.position = new Vector3(transform.position.x - 0.51f, transform.position.y, transform.position.z);
                CubeGenerator.MColliderStatic.rotation = Quaternion.Euler(-90, 90, 0);
                break;
            case "Side3":
                CubeGenerator.MColliderStatic.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.51f);
                CubeGenerator.MColliderStatic.rotation = Quaternion.Euler(-90, 0, 0);
                break;
            case "Side4":
                CubeGenerator.MColliderStatic.position = new Vector3(transform.position.x + 0.51f, transform.position.y, transform.position.z);
                CubeGenerator.MColliderStatic.rotation = Quaternion.Euler(-90, -90, 0);
                break;
            case "Top":
                CubeGenerator.MColliderStatic.position = new Vector3(transform.position.x, transform.position.y + 0.51f, transform.position.z);
                CubeGenerator.MColliderStatic.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "Bottom":
                CubeGenerator.MColliderStatic.position = new Vector3(transform.position.x, transform.position.y - 0.51f, transform.position.z);
                CubeGenerator.MColliderStatic.rotation = Quaternion.Euler(0, 0, 180);
                break;
            default:
                CubeGenerator.MColliderStatic.position = Vector3.zero;
                CubeGenerator.MColliderStatic.rotation = new Quaternion();
                break;
        }
    }


    
}
