using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

    //効果音を再生するためのコンポーネントを入れる
    AudioSource audioSource;

    void Start()
    {
        //AudioSourceのコンポーネントを取得する
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //当たったものがキューブか地面だったら効果音を再生する
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CubeTag" || collision.gameObject.tag == "GroundTag")
        {
            audioSource.Play();
        }
    }
}
