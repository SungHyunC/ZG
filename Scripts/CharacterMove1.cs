using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMove1 : MonoBehaviour
{
    public static CharacterMove1 instance; //어디서나 접근할 수 있도록 static(정적)으로 자기 자신을 저장할 변수를 만듭니다.
    public Text scoreText; //점수를 표시하는 Text객체를 에디터에서 받아옵니다.
    public Button btn1;
    public Button btn2;
    public GameObject PlayerMissile; // 복제할 미사일 오브젝트
    public Transform MissileLocation; // 미사일이 발사될 위치
    public float FireDelay; // 미사일 발사 속도(미사일이 날라가는 속도x) 
    [SerializeField]
    private bool FireState; // 미사일 발사 속도를 제어할 변수

    public int score = 0;

    public GameObject playerModel;
    
    public float movePower = 1f;

    AudioSource audioSource;
    Rigidbody2D rigid;
    Animator anim;

    Vector3 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        btn1.interactable = true;
        btn2.interactable = true;
        FireState = true;
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (!instance) //정적으로 자신을 체크합니다.
            instance = this; //정적으로 자신을 저장합니다.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (Input.GetKey(KeyCode.J))
        { 
            //playerFire();
            anim.SetBool("isGun", true);
            Debug.Log("gi");
        }
        else
        {
            anim.SetBool("isGun", false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetBool("isKnife", true);
        }
        else
        {
            anim.SetBool("isKnife", false);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            anim.SetBool("isSumen", true);
        }
        else
        {
            anim.SetBool("isSumen", false);
        }

        if(score == 10)
        {
            btn1.interactable = true;
            btn2.interactable = true;
        }
    }

    public void AddScore(int num) //점수를 추가해주는 함수를 만들어 줍니다.
    {
        score += num; //점수를 더해줍니다.
        scoreText.text = "Score : " + score; //텍스트에 반영합니다.
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            audioSource.Play();
            moveVelocity = Vector3.left;

            transform.localScale = new Vector3(1f, 1f, 0);
            //playerModel.transform.localScale = new Vector3(-2.3f, 2.3f, 0);
            anim.SetBool("isRunning", true);
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            audioSource.Play();
            moveVelocity = Vector3.right;

            transform.localScale = new Vector3(1f, 1f, 0);
            //playerModel.transform.localScale = new Vector3(-2.3f, 2.3f, 0);
            anim.SetBool("isRunning", true);
        }
        else
        {
            audioSource.Stop();
            anim.SetBool("isRunning", false);
            //playerModel.transform.localScale = new Vector3(-2.3f, 2.3f, 0);
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;


    }
    public void playerFire()
    {
        Debug.Log("shoot1");
        // 제어변수가 true일때만 발동
        if (FireState)
        {
            // 키보드의 "A"를 누르면
            if (Input.GetKey(KeyCode.J))
            {
                // 코루틴 "FireCycleControl"이 실행되며
                StartCoroutine(FireCycleControl());
                // "PlayerMissile"을 "MissileLocation"의 위치에 "MissileLocation"의 방향으로 복제한다.
                Instantiate(PlayerMissile, MissileLocation.position, MissileLocation.rotation);
            }
        }
    }

    public void Fire()
    {
        audioSource.Play();
        Instantiate(PlayerMissile, MissileLocation.position, MissileLocation.rotation);
    }

    // 코루틴 함수
    IEnumerator FireCycleControl()
    {
        // 처음에 FireState를 false로 만들고
        FireState = false;
        // FireDelay초 후에
        yield return new WaitForSeconds(FireDelay);
        // FireState를 true로 만든다.
        FireState = true;
    }


}
