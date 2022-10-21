using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bullet : MonoBehaviour
{
    public string nextScene;
    Rigidbody rb;
    float lifeTime = 0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 100;

        // IEnumerator mc = MyCoroutine();

        // StartCoroutine(mc);
        // StopCoroutine(mc);
    }

    void Update()
    {
         lifeTime += Time.deltaTime;
        
        if (lifeTime > 0.3f)
        {
            Destroy(gameObject);
        }
    }
// IEnumerator MyCoroutine()
// {
//     StartCoroutine(mc);
//     // 直接執行這裡...

//     // 停兩秒
//     yield return new WaitForSeconds(2);

//     // 兩秒之後才執行這裡
//     StopCoroutine(mc);
// }
    //  IEnumerator DestroySelf()
    // {
    //     yield return new WaitForSeconds(2);
    //     gameObject.SetActive(false);
    //     Destroy(gameObject);
    // }
    private void OnCollisionEnter(Collision other)
    {
          if (other.gameObject.tag == "Monster")
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);

            GameObject[] objs = GameObject.FindGameObjectsWithTag("Monster");

            if (objs.Length == 0)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}

