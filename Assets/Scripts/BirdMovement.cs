using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdMovement : MonoBehaviour
{
  public Animator BirdAnimator;
  public TextMeshProUGUI ScoreText;
  public AudioSource swooshSound;
  public AudioSource hitSound;
  public AudioSource pointSound;

  private CharacterController Controller;
  private Vector3 Velocity;
  private bool IsOnCooldown;
  private bool IsDead;
  private GameObject LookAt;
  public GameObject Cube1;
  public GameObject Cube2;
  private int Speed;
  private int Score;


  private void OnTriggerEnter(Collider collider)
  {
    if (IsDead) return;

    if (collider.CompareTag("Score"))
    {
      pointSound.Play();
      Score++;
    }

    if (collider.CompareTag("Obstacle"))
    {
      IsDead = true;
      Fall();
      Invoke(nameof(Restart), 0.1f);
    }
  }

  private void Restart()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("Scene");
  }

  private void Fall()
  {
    Time.timeScale = 0.05f;
    hitSound.Play();
    Velocity.y = -40f;
  }

  private void Start()
  {
    Controller = gameObject.GetComponent<CharacterController>();
  }

  private void Update()
  {
    ScoreText.text = Score.ToString();

    Velocity.y += -40 * Time.deltaTime;

    if (Input.touchCount > 0 && !IsOnCooldown)
    {
      Touch touch = Input.GetTouch(0);

      if (touch.phase == TouchPhase.Began)
      {
        IsOnCooldown = true;
        Velocity.y = 16f;
        BirdAnimator.SetBool("Fly", true);
        swooshSound.Play();
        StartCoroutine(CooldownRefresh());
      }
    }

    if (Velocity.y > 0)
    {
      LookAt = Cube1;
      Speed = 8;
    }
    else
    {
      LookAt = Cube2;
      Speed = 16;
    }

    Quaternion lookOnLook =
    Quaternion.LookRotation(-LookAt.transform.position - transform.position);

    transform.rotation =
    Quaternion.Slerp(transform.rotation, lookOnLook, Speed * Time.deltaTime);

    Controller.Move(Velocity * Time.deltaTime);
  }

  private IEnumerator CooldownRefresh()
  {
    yield return new WaitForSeconds(0.4f);
    IsOnCooldown = false;
    BirdAnimator.SetBool("Fly", false);
  }
}
