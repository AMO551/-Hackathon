using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hoge : MonoBehaviour
{
    public GameObject map;
    public Vector3 hei = Vector3.zero;
    //private GameObject _Child;
    [SerializeField, Range(0, 10), Header("�z�u�ł���񐔂���")]
    private int limit = 0;
    [SerializeField]
    private TextMeshProUGUI _text = null;

    [SerializeField, Header("��x�ɉ�]����p�x")]
    private int _rotateAngle = 90;

    [SerializeField, Header("���ɂ���  �^�O�̖��O")]
    private string tagName = "";

    enum MODE
    {
        Normal = 0,
        Haiti,
    }

    MODE mode = MODE.Normal;
    // Start is called before the first frame update
    void Start()
    {
        //_text.text = "x"+limit.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Mirror();
        _text.text = "x" + limit.ToString();
    }

    void Mirror()
    {
        // �}�E�X���{�^�����N���b�N������
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("������");
            // �X�N���[���ʒu����3D�I�u�W�F�N�g�ɑ΂���Ray�i�����j�𔭎�
            Ray rayOrigine = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Ray���I�u�W�F�N�g�Ƀq�b�g�����ꍇ
            if (Physics.Raycast(rayOrigine, out RaycastHit hitInfo))
            {
                // �^�O��Cube�̏ꍇ�i����if�����폜����ƁA�S�ẴQ�[���I�u�W�F�N�g�ɑ΂��鏈���ɂȂ�܂��j
                if (hitInfo.collider.CompareTag(tagName))
                {
                    //_Child = hitInfo.collider.gameObject.transform.Find(mirrorName).gameObject;
                    //map = hitInfo.collider.gameObject;

                    if (mode == MODE.Haiti && limit > 0 && map != null)
                    {
                        //_Child.SetActive(true);
                        var obj = Instantiate(map, hitInfo.collider.gameObject.transform.position + hei, Quaternion.identity);
                        obj.transform.Rotate(0, 45, 0);
                        hitInfo.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                        limit--;
                        Debug.Log("�c��" + limit + "��");
                    }
                    else
                    {
                        //Ray�����������I�u�W�F�N�g�̖��O���w�肵�������������]������
                        if (hitInfo.collider.gameObject.tag == "mirror")
                        {
                            hitInfo.collider.gameObject.transform.Rotate(0, _rotateAngle, 0);
                        }
                        Debug.Log("�Ȃ�");
                    }

                    // �����_���ȐF�ɕύX����ꍇ
                    //hitInfo.collider.GetComponent<MeshRenderer>().material.color =
                    //    new Color(Random.value, Random.value, Random.value);
                }
            }
        }
    }

    public void Button()
    {
        if (mode == MODE.Normal)
        {
            mode = MODE.Haiti;
            Debug.Log("�z�u");
        }
        else if (mode == MODE.Haiti)
        {
            mode = MODE.Normal;
            Debug.Log("�ӂ�");
        }
    }
}
