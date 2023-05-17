using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : Manager {
    public int a;

    public void Creat(GameObject obj) //括號內不能是空的會跳錯
    {
        objPre = obj;
        //Debug.Log("xd");
        a = Random.Range(-5, 8);
        Instantiate(objPre, new Vector3(15, a, 0), Quaternion.identity);
        Debug.Log("預製物(Prefab)物件複製並創建 - 給予位置、旋轉角度");       
    }

}
