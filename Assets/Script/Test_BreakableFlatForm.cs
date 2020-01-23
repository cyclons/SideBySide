using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test_BreakableFlatForm : MonoBehaviour {
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            transform.DOShakePosition(1.5f, 0.08f,8,30);
            StartCoroutine("BreakCount");
        }
    }
    private IEnumerator BreakCount()
    {
        yield return new WaitForSeconds(1.5f);
        //Destroy(this.gameObject);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(5);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        GetComponent<Collider2D>().enabled = true;
    }
}
