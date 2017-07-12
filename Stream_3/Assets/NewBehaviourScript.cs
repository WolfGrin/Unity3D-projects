using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public Rigidbody ball;
    public Transform platform;

    public float speedMove = 30f;
    public float speedRotate = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //получение значения виртульаной оси, по имени установленному в Edit->Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //если значение оси изменилось (кнопка нажата)
        if(horizontal != 0 || vertical != 0)
        {   
            //направления движеняи оси
            Vector3 move = new Vector3(horizontal, 0f, vertical);
            //применение силы к объекту ball
            ball.AddForce(move * speedMove * Time.deltaTime, ForceMode.Impulse);
        }
        //получение значения виртульаной оси, по имени установленному в Edit->Input
        float mHorizontal = Input.GetAxis("MHorizontal");
        float mVertical = Input.GetAxis("MVertical");
        //если значение оси изменилось (кнопка нажата)
        if (mHorizontal != 0 || mVertical != 0)
        {
            //направления движеняи оси
            Vector3 rotate = new Vector3(mVertical, 0f, mHorizontal * -1);
            //плавное вращение объекта platform
            platform.rotation = Quaternion.Slerp(platform.rotation, platform.rotation * Quaternion.Euler(rotate), Time.deltaTime * speedRotate);
        }
        //если нажата виртуальная кнопка, указаная в Edit->Input "Jump"
        if (Input.GetButtonDown("Jump"))
        {
            //применение силы к объекту ball
            ball.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        //если кнопка клавиатуры Esc отпущена
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
