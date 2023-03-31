using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousee : MonoBehaviour
{

    private GameObject _Child;
    [SerializeField,Range(0,10),Header("�z�u�ł���񐔂���")]
    private int limit = 0;

    [SerializeField,Header("��]�����̖��O")]
    private string mirrorName = "";

    [SerializeField, Header("���ɂ���  �^�O�̖��O")]
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
                    _Child = hitInfo.collider.gameObject.transform.Find(mirrorName).gameObject;

                    if (mode == MODE.Haiti && limit > 0 && _Child != null)
                    {
                        _Child.SetActive(true);
                        limit--;
                        Debug.Log("�c��" + limit + "��");
                    }
                    else
                    {
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
        if(mode == MODE.Normal)
        {
            mode = MODE.Haiti;
            Debug.Log("�z�u");
        }
        else if(mode == MODE.Haiti)
        {
            mode=MODE.Normal;
            Debug.Log("�ӂ�");
        }
    }
}
