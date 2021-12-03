using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino : MonoBehaviour
{
    // �����_���ϐ�
    public int randomNum;

    // �X�v���C�g
    public Sprite[] numPic = new Sprite[6];

    // �����鑬��
    public float previousTime;
    public float fallTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // �����_���Ȓl���擾
        randomNum = UnityEngine.Random.Range(0, 6);

        // �����_���Ȓl�ɍ��킹�ăX�v���C�g��ύX
        switch (randomNum)
        {
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[0];
                break;

            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[1];
                break;

            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[2];
                break;

            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[3];
                break;

            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[4];
                break;

            case 5:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[5];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MinoMove();
    }

    // Mino�ړ�����
    private void MinoMove()
    {
        // ���Ɉړ�
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
        }

        // �E�Ɉړ�
        else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
        }

        // ���Ɉړ� & �����ŉ��Ɉړ�
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)
            || Time.time - previousTime >= fallTime)
        {
            transform.position += new Vector3(0, -1, 0);
            previousTime = Time.time;
        }
    }
}
