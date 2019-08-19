using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class MVPExample : MonoBehaviour
{
    //View
    public Button Button;
    public Text Text;

    Enemy enemyModel = new Enemy(200);

    //Persenter
    // Start is called before the first frame update
    void Start()
    {
        //按钮绑定
        Button.OnClickAsObservable()
            .Subscribe(_ =>
            {
                enemyModel.CurrentHP.Value -= 90;
            })
            .AddTo(this);

        //敌人的血量（Model）绑定到Text（View）
        enemyModel.CurrentHP
            .SubscribeToText(Text)
            .AddTo(this);

        //敌人的死亡状态（Model）绑定到Button（View）
        enemyModel.IsDead
            .Where(isDead => isDead)
            .Select(isDead => !isDead)
            .SubscribeToInteractable(Button)
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//Model
public class Enemy
{
    public ReactiveProperty<int> CurrentHP;

    public IReadOnlyReactiveProperty<bool> IsDead;

    public Enemy(int initialHP)
    {
        CurrentHP = new ReactiveProperty<int>(initialHP);

        IsDead = CurrentHP.Select(hp => hp < 0).ToReactiveProperty();
    }
}
