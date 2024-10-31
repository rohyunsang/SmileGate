using System.Collections;
using UnityEngine;
using UnityEngine.UI;

enum Type
{   // Init HP 
    Blue = 1,
    Sparkling = 2,
    Green = 3 
}

public class Ghost : MonoBehaviour
{
    private int HP = 0;
    private int curHP = 0;


    [SerializeField] private Type type;


    private bool spakling = false;
    [SerializeField] private SpriteRenderer ghostImage; // 유령 이미지


    void Awake()
    {
        switch (type)
        {
            case Type.Blue:
                Init(1);
                break;
            case Type.Sparkling:
                ghostImage = GetComponent<SpriteRenderer>();
                Init(1);
                break;
            case Type.Green:
                Init(2);
                break;
            default:
                break;

        }
    }

    void Start()
    {
        if (type == Type.Sparkling)
        {
            // 스파클링 효과를 시작
            StartCoroutine(Spakling());
        }
    }

    IEnumerator Spakling()
    {
        while (true)
        {
            // 투명도를 20%로 설정
            SetAlpha(0.2f);
            spakling = true;
            yield return new WaitForSeconds(1f);

            // 투명도를 100%로 설정
            SetAlpha(1f);
            spakling = false;
            yield return new WaitForSeconds(1f);
        }
    }

    private void SetAlpha(float alpha)
    {
        Color color = ghostImage.color;
        color.a = alpha;
        ghostImage.color = color;
    }


    private void Init(int HP)
    {
        this.HP = HP;
        this.curHP = HP;
    }

    public void TakeDamage(int damage)
    {
        if (spakling) return;
        curHP = curHP - damage;
        Debug.Log("curHP : " + curHP);

        if (curHP <= 0)
        {
            // Death Animation 
            Debug.Log("Death Ghost");
            Destroy(gameObject);
        }
    }
}
