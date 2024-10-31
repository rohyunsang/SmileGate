using System.Collections;
using UnityEngine;
using UnityEngine.UI;

enum Type
{   // Init HP 
    Basic = 1, 
    Blue = 3,
    Sparkling = 4,
    Red = 5 
}

public class Ghost : MonoBehaviour
{
    private int HP = 0;
    private int curHP = 0;


    [SerializeField] private Type type;


    private bool spakling = false;
    [SerializeField] private SpriteRenderer ghostImage; // ���� �̹���


    void Awake()
    {
        switch (type)
        {
            case Type.Basic:
                Init(1);
                break;
            case Type.Blue:
                Init(3);
                break;
            case Type.Sparkling:
                ghostImage = GetComponent<SpriteRenderer>();
                Init(4);
                break;
            case Type.Red:
                Init(5);
                break;
            default:
                break;

        }
    }

    void Start()
    {
        if (type == Type.Sparkling)
        {
            // ����Ŭ�� ȿ���� ����
            StartCoroutine(Spakling());
        }
    }

    IEnumerator Spakling()
    {
        while (true)
        {
            // ������ 20%�� ����
            SetAlpha(0.2f);
            spakling = true;
            yield return new WaitForSeconds(1f);

            // ������ 100%�� ����
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
