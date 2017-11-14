using UnityEngine;
using UnityEngine.Assertions; // подключаем для уведомления о нулле Обьекта

public class addingForceWithPhysics : MonoBehaviour {

    Rigidbody rb;
    bool jump;
    [SerializeField]
    float jumpForce;

    private AudioClip sfxjump;
    private AudioSource audioSource;

    private void Awake()
    {
        //Assert.IsNotNull(sfxjump); // Выдает ошибку при Нулл этого обьекта
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(sfxjump);
            rb.useGravity = true;
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if(jump)
        {
            jump = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }
}
