using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using InGame.Player.Model;
public class PlayerView : MonoBehaviour
{
    [SerializeField] private Text testBullet;
    [SerializeField] private Slider slider;
    private PlayerModel _model; 
    public UnityAction ChangeScene;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SynModel(PlayerModel model)
    {
        _model = model;
        Show(_model.Bullet);
    }
    private void Show(int bullet)
    {
        testBullet.text = bullet.ToString();
    }
    //敵から攻撃を受けたときの関数
    public void Damage(float damage)
    {
        slider.value -= 0.1f;
        
        if(slider.value == 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
