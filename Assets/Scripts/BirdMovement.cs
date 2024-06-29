using System.Collections;
using System.Collections.Generic;
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
  private bool Cooldown;
  private GameObject LookAt;
  public GameObject Cube1;
  public GameObject Cube2;
  private int Speed;
  private int Score;


  private void OnTriggerEnter(Collider collider)
  {
    if (collider.CompareTag("Score"))
    {
      Score++;
      pointSound.Play();
    }

    if (collider.CompareTag("Obstacle"))
    {
      hitSound.Play();
      SceneManager.LoadScene("Scene");
    }
  }

  private void Start()
  {
    Controller = gameObject.GetComponent<CharacterController>();
  }

  private void Update()
  {
    ScoreText.text = Score.ToString();

    Velocity.y += -15 * Time.deltaTime;

    if (Input.GetKey(KeyCode.Space) && Cooldown == false)
    {
      Cooldown = true;
      Velocity.y = 0;
      Velocity.y = Mathf.Sqrt(60);
      BirdAnimator.SetBool("Fly", true);
      swooshSound.Play();
      StartCoroutine(CooldownRefresh());
    }

    if (Velocity.y > 0)
    {
      LookAt = Cube1;
      Speed = 5;
    }
    else
    {
      LookAt = Cube2;
      Speed = 10;
    }

    Quaternion lookOnLook =
    Quaternion.LookRotation(-LookAt.transform.position - transform.position);

    transform.rotation =
    Quaternion.Slerp(transform.rotation, lookOnLook, Speed * Time.deltaTime);

    Controller.Move(Velocity * Time.deltaTime);
  }

  private IEnumerator CooldownRefresh()
  {
    yield return new WaitForSeconds(0.3f);
    Cooldown = false;
    BirdAnimator.SetBool("Fly", false);
  }
}
