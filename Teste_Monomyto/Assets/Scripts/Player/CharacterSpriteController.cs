using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class CharacterSpriteController : MonoBehaviour {
    [SerializeField] Sprite unarmedSprite;
    [SerializeField] Sprite punchSprite;
    [SerializeField] Sprite pistolSprite;
    [SerializeField] Sprite shotgunSprite;
    [SerializeField] Sprite machinegunSprite;
    [SerializeField] Sprite idleSprite;

    SpriteRenderer spriteRenderer;

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        GetComponentInChildren<Gun> ().GunOnChange.AddListener (ChangeGun_UpdateSprite);
    }

    void ChangeGun_UpdateSprite (GunData gunData) {
        SetSprite (GetSpriteTypeByGunName (gunData.GunName));
    }

    public void SetSprite (CharacterSpriteType spriteType) {
        switch (spriteType) {
            case CharacterSpriteType.Unarmed:
                spriteRenderer.sprite = unarmedSprite;
                break;
            case CharacterSpriteType.Punch:
                spriteRenderer.sprite = punchSprite;
                break;
            case CharacterSpriteType.Pistol:
                spriteRenderer.sprite = pistolSprite;
                break;
            case CharacterSpriteType.Shotgun:
                spriteRenderer.sprite = shotgunSprite;
                break;
            case CharacterSpriteType.Machinegun:
                spriteRenderer.sprite = machinegunSprite;
                break;
            case CharacterSpriteType.Idle:
                spriteRenderer.sprite = CheckWeaponEquiped () ? idleSprite : unarmedSprite;
                break;
        }
    }

    public CharacterSpriteType GetSpriteTypeByGunName (string gunName) {
        if (gunName == "Pistol") return CharacterSpriteType.Pistol;
        else if (gunName == "Shotgun") return CharacterSpriteType.Shotgun;
        else if (gunName == "Machinegun") return CharacterSpriteType.Machinegun;
        else return CharacterSpriteType.Unarmed;
    }

    bool CheckWeaponEquiped () {
        return spriteRenderer.sprite.name == pistolSprite.name ||
            spriteRenderer.sprite.name == shotgunSprite.name ||
            spriteRenderer.sprite.name == machinegunSprite.name;
    }
}
public enum CharacterSpriteType {
    Unarmed,
    Punch,
    Pistol,
    Shotgun,
    Machinegun,
    Idle
}