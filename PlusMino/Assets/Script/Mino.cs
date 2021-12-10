using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino : MonoBehaviour
{
    // ランダム変数
    public int randomNum;

    // スプライト
    public Sprite[] numPic = new Sprite[6];

    // Minoの落ちる速さ
    public float previousTime;
    public float fallTime = 1f;

    // ステージの大きさ
    private static int width = 10;
    private static int height = 20;

    private static Transform[,] grid = new Transform[width, height];

    // Start is called before the first frame update
    void Start()
    {
        // ランダムな値を取得
        randomNum = UnityEngine.Random.Range(0, 6);

        // ランダムな値に合わせてスプライトを変更
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
        NumChange();
    }

    // Mino移動処理
    private void MinoMove()
    {
        // 左に移動
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            // 移動制御
            if(!ValidMovement())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }

        // 右に移動
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            // 移動制御
            if(!ValidMovement())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }

        // 下に移動 & 自動で下に移動
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Time.time - previousTime >= fallTime)
        {
            transform.position += new Vector3(0, -1, 0);
            // 移動制御
            if(!ValidMovement())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                this.enabled = false;
                FindObjectOfType<SpawnMino>().NewMino();
            }
            previousTime = Time.time;
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundX, roundY] = children;
        }
    }

    bool ValidMovement()
    {
        foreach(Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            // Minoがはみ出さないようにする
            if(roundX < 0 || roundX >= width || roundY < 0 || roundY >= height)
            {
                return false;
            }
            if(grid[roundX,roundY] != null)
            {
                return false;
            }
        }
        return true;
    }

    // Minoの値をWASDで変更して、その値に合わせたスプライトを変更する
    private void NumChange()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            switch (randomNum)
            {
                case 0:
                    randomNum = 2;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[2];
                    break;

                case 1:
                    randomNum = 0;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[0];
                    break;

                case 2:
                    randomNum = 5;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[5];
                    break;

                case 3:
                    randomNum = 0;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[0];
                    break;

                case 4:
                    randomNum = 0;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[0];
                    break;

                case 5:
                    randomNum = 3;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[3];
                    break;
            }
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            switch (randomNum)
            {
                case 0:
                    randomNum = 4;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[4];
                    break;

                case 1:
                    randomNum = 3;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[3];
                    break;

                case 2:
                    randomNum = 4;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[4];
                    break;

                case 3:
                    randomNum = 4;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[4];
                    break;

                case 4:
                    randomNum = 0;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[0];
                    break;

                case 5:
                    randomNum = 4;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[4];
                    break;
            }
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            switch (randomNum)
            {
                case 0:
                    randomNum = 3;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[3];
                    break;

                case 1:
                    randomNum = 5;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[5];
                    break;

                case 2:
                    randomNum = 0;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[0];
                    break;

                case 3:
                    randomNum = 5;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[5];
                    break;

                case 4:
                    randomNum = 5;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[5];
                    break;

                case 5:
                    randomNum = 2;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[2];
                    break;
            }
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            switch (randomNum)
            {
                case 0:
                    randomNum = 1;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[1];
                    break;

                case 1:
                    randomNum = 0;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[0];
                    break;

                case 2:
                    randomNum = 1;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[1];
                    break;

                case 3:
                    randomNum = 1;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[1];
                    break;

                case 4:
                    randomNum = 3;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[3];
                    break;

                case 5:
                    randomNum = 1;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = numPic[1];
                    break;
            }
        }
    }
}
