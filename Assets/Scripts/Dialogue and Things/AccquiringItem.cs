using UnityEngine;
using UnityEngine.UI;

public class AccquiringItem : MonoBehaviour
{

    public Image qiCollector;

    private void Start()
    {
        if (qiCollector == null)
        {
            qiCollector = GameObject.Find("Image_Q").GetComponent<Image>();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        SceneChanger.Instance.collectionNumber ++;
    //        Destroy(gameObject);
    //        if (SceneChanger.Instance.collectionNumber == 1)
    //        {
    //            collision.gameObject.transform.Find("Acquired_Items").GetChild(0).gameObject.SetActive(true); 
    //            qiCollector.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    //        }
    //        else if (SceneChanger.Instance.collectionNumber == 2)
    //        {
    //            collision.gameObject.transform.Find("Acquired_Items").GetChild(1).gameObject.SetActive(true);
    //            qiCollector.gameObject.transform.GetChild(1).gameObject.SetActive(true);
    //        }
    //        else if (SceneChanger.Instance.collectionNumber == 3)
    //        {
    //            collision.gameObject.transform.Find("Acquired_Items").GetChild(2).gameObject.SetActive(true);
    //            qiCollector.gameObject.transform.GetChild(2).gameObject.SetActive(true);
    //        }
    //        else
    //        {
    //            Debug.LogWarning("All Items Collected !!");
    //        }
    //    }
    //}
}
