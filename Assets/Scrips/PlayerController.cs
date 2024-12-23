using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static bool GAMEOVER = false;
    private Rigidbody _rb;
    public float jumpForce = 2;
    private bool _onGrounded = true;
    private Animator _playerAnim;
    public ParticleSystem exsplosionParticle;
    public ParticleSystem dustParticle;
    public AudioClip jumpSound;
    public AudioClip boomSound;
    public AudioClip deathSound;
    public AudioSource playerAudio;
    // public AudioSource musicAudio;
    public Text displayText;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _onGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            _onGrounded = false;
            _playerAnim.SetTrigger("Jump_trig");
            dustParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 10);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver!");
            exsplosionParticle.Play();
            _playerAnim.SetTrigger("Death_b");
            Destroy(collision.gameObject);
            GAMEOVER = true;
            dustParticle.Stop();
            playerAudio.PlayOneShot(boomSound, 10);
            playerAudio.Stop();
            canvas.SetActive(true);
            playerAudio.PlayOneShot(deathSound, 10);
        }

        if (collision.gameObject.CompareTag("Ground") && !GAMEOVER)
        {
            Debug.Log("Коснулись " + collision.gameObject.tag);
            _onGrounded = true;
            dustParticle.Play();
        }
    }
}
