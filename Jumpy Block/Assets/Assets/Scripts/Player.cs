﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] public float speed = 3;
	[SerializeField] public float jumpPower = 200;
	[SerializeField] private float grappleTimer = 10;
	[SerializeField] private ParticleSystem wallParticle = null;
	[SerializeField] private TextMeshProUGUI jumpUIText = null;
	[SerializeField] private Image jumpUIImage = null;
	[SerializeField] private Image grappleUIImage = null;
	[SerializeField] private TextMeshProUGUI grappleUIText = null;
	[SerializeField] private AudioClip[] playerSounds = null;

	private int jumpsLeft = 0;
	public int grapplesLeft = 15;
	private Camera playerCamera;
    [HideInInspector] public AudioSource playerAudio;
	private DistanceJoint2D distanceJoint;
	private Rigidbody2D playerRigidbody;
	private Animator playerAnimator;
	private LineRenderer lineRenderer;
	private Vector2 grapplePoint;
	private float grappleTime;
	private bool grappled;

	private void Awake()
	{
		playerAnimator = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody2D>();
		playerAudio = GetComponent<AudioSource>();
		distanceJoint = GetComponent<DistanceJoint2D>();
		lineRenderer = GetComponent<LineRenderer>();
		playerCamera = Camera.main;
		lineRenderer.positionCount = 0;
		jumpUIText.text = jumpsLeft.ToString();
		grappleUIText.text = grapplesLeft.ToString();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
		{
			playerRigidbody.AddForce(Vector3.up * jumpPower);
			jumpsLeft--;
			playerAudio.PlayOneShot(playerSounds[0]);
			jumpUIImage.GetComponent<Animator>().SetTrigger("Trigger");
			jumpUIText.text = jumpsLeft.ToString();
			playerAnimator.SetTrigger("Jump");
		}

		if (Input.GetMouseButtonDown(0))
		{
			if (grapplesLeft > 0)
			{
				grapplePoint = playerCamera.ScreenToWorldPoint(Input.mousePosition);
				distanceJoint.enabled = true;
				grapplesLeft--;
				grappled = true;
				lineRenderer.positionCount = 2;
				distanceJoint.connectedAnchor = grapplePoint;
				playerRigidbody.AddForce((grapplePoint - (Vector2)transform.position).normalized * 15500);
				grappleUIText.text = grapplesLeft.ToString();
				grappleUIImage.GetComponent<Animator>().SetTrigger("Trigger");
				playerAudio.PlayOneShot(playerSounds[2]);
				Instantiate(wallParticle, grapplePoint, Quaternion.identity);
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			distanceJoint.enabled = false;
			grappled = false;
			lineRenderer.positionCount = 0;
			playerAudio.PlayOneShot(playerSounds[3]);
		}

		if (grappled == true)
		{
			grappleTime -= Time.deltaTime;
			if (grappleTime <= 0)
			{
				distanceJoint.enabled = false;
				grappled = false;
				lineRenderer.positionCount = 0;
				grappled = false;
			}
		}
		else
		{
			grappleTime = grappleTimer;
		}

		DrawLine();

	}

	private void FixedUpdate()
	{
		Vector2 forceDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
		playerRigidbody.AddForce(forceDirection * speed);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Ground"))
		{
			playerAudio.PlayOneShot(playerSounds[1]);
			jumpsLeft = 2;
			jumpUIText.text = jumpsLeft.ToString();
		}
	}

	private void DrawLine()
	{
		if (lineRenderer.positionCount <= 0) return;
		lineRenderer.SetPosition(0, grapplePoint);
		lineRenderer.SetPosition(1, transform.position);
		distanceJoint.distance = Mathf.Lerp(distanceJoint.distance , 0 , Time.deltaTime* 1.5f);
	}	

	public void UpdateStats()
	{
		jumpUIText.text = jumpsLeft.ToString();
		grappleUIText.text = grapplesLeft.ToString();
	}
}
