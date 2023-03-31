using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousee : MonoBehaviour
{

    private GameObject _Child;
    [SerializeField,Range(0,10),Header("配置できる回数だよ")]
    private int limit = 0;

    [SerializeField,Header("回転するやつの名前")]
    private string mirrorName = "";

    [SerializeField, Header("床につける  タグの名前")]
    private string tagName = "";

    enum MODE 
    {
        Normal =0, 
        Haiti,
    }

    MODE mode = MODE.Normal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mirror();
    }

    void Mirror()
    {
        // マウス左ボタンをクリックした時
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("押した");
            // スクリーン位置から3Dオブジェクトに対してRay（光線）を発射
            Ray rayOrigine = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Rayがオブジェクトにヒットした場合
            if (Physics.Raycast(rayOrigine, out RaycastHit hitInfo))
            {
                // タグがCubeの場合（このif文を削除すると、全てのゲームオブジェクトに対する処理になります）
                if (hitInfo.collider.CompareTag(tagName))
                {
                    _Child = hitInfo.collider.gameObject.transform.Find(mirrorName).gameObject;

                    if (mode == MODE.Haiti && limit > 0 && _Child != null)
                    {
                        _Child.SetActive(true);
                        limit--;
                        Debug.Log("残り" + limit + "回");
                    }
                    else
                    {
                        Debug.Log("ない");
                    }

                                        // ランダムな色に変更する場合
                    //hitInfo.collider.GetComponent<MeshRenderer>().material.color =
                    //    new Color(Random.value, Random.value, Random.value);
                }
            }
        }
    }

    public void Button()
    {
        if(mode == MODE.Normal)
        {
            mode = MODE.Haiti;
            Debug.Log("配置");
        }
        else if(mode == MODE.Haiti)
        {
            mode=MODE.Normal;
            Debug.Log("ふつう");
        }
    }
}
