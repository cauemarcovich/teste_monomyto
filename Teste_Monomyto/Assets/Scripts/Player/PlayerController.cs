using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float speed = 5f;
    [SerializeField] float punchDamage = 50f;

    Vector2 input;
    bool isPunching;

    Rigidbody2D _rigidbody;
    PolygonCollider2D _punchCollider;
    CharacterSpriteController _spriteController;
    Gun _gun;

    void Start () {
        _rigidbody = GetComponent<Rigidbody2D> ();
        _punchCollider = GetComponent<PolygonCollider2D> ();
        _spriteController = GetComponent<CharacterSpriteController> ();
        _gun = GetComponentInChildren<Gun> ();
    }

    void Update () {
        input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));

        if (Input.GetButtonDown ("Fire2") && !isPunching)
            Punch ();
    }

    void FixedUpdate () {
        _rigidbody.velocity = input * speed;
        Look ();
    }

    void Look () {
        var position = Camera.main.WorldToViewportPoint (transform.position);
        var mousePosition = (Vector2) Camera.main.ScreenToViewportPoint (Input.mousePosition);

        var angle = Mathf.Atan2 (position.y - mousePosition.y, position.x - mousePosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.otherCollider is PolygonCollider2D) {
            var enemyHealth = collision.collider.GetComponent<Health> ();
            if (enemyHealth != null)
                enemyHealth.DealDamage (punchDamage);
        }
    }

    void Punch () {
        isPunching = true;
        _punchCollider.enabled = true;
        _spriteController.SetSprite (CharacterSpriteType.Punch);

        StartCoroutine (ResetPunch ());
    }

    IEnumerator ResetPunch () {
        yield return new WaitForSeconds (.1f);

        var charSprite = _spriteController.GetSpriteTypeByGunName (_gun.GetCurrentGunName ());
        _spriteController.SetSprite (charSprite);
        _punchCollider.enabled = false;
        isPunching = false;
    }
}