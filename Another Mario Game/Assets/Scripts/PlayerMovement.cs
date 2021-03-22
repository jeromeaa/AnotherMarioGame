using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource jumpsound;
    public CharacterController2D controller;
    public Animator animator;
    public Transform spawn;
    public GameObject GameOverPanel;
    public Text text;
    public AudioSource main;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    // Update is called once per frame

    void Update()
    {
        horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            jumpsound.Play();
            jump = true;
            crouch = false;
            animator.SetBool("IsJumping", true);
            
        }
        if (CrossPlatformInputManager.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (CrossPlatformInputManager.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name.ToString()+" in");
        if (collision.gameObject.tag.Equals("Balloon"))
        {
            transform.parent = collision.transform;
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            text.text = ScoreCount.score.ToString();
            main.mute= true;
            if (ScoreCount.score > PlayerPrefs.GetInt("HighScore", 0))
                PlayerPrefs.SetInt("HighScore", ScoreCount.score);
        }
            
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name.ToString()+" out");
        if (collision.gameObject.tag.Equals("Balloon"))
        {
            transform.parent = null;
        }
    }


}