using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartImageController : MonoBehaviour
{
    [SerializeField] List<Image> heartImage;


    private PlayerStat stat;

    private void Start()
    {
        stat = MainManager.instance.playerController.stat;
    }

    private void Update()
    {
        for (int i = 0; i < heartImage.Count; i++)
        {
            if(i < stat.healthCount)
                heartImage[i].gameObject.SetActive(true);
            else
                heartImage[i].gameObject.SetActive(false);
        }
    }

}
