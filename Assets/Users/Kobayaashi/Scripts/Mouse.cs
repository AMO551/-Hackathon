using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField, Header("一度に回転する角度")]
    private int _rotateAngle = 45;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //メインカメラ上のマウスポインタのある位置からrayを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //Rayが当たったオブジェクトの名前が指定した物だったら回転させる
                if (hit.collider.gameObject.tag == "mirror")
                {
                    hit.collider.gameObject.transform.Rotate(0, _rotateAngle, 0);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            //メインカメラ上のマウスポインタのある位置からrayを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //Rayが当たったオブジェクトの名前が指定した物だったら回転させる
                if (hit.collider.gameObject.tag == "mirror")
                {
                    hit.collider.gameObject.transform.Rotate(0, _rotateAngle*-1, 0);
                }
            }
        }
    }
}