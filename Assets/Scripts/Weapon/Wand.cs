using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public List<Sprite> wandImages;
    public SpriteRenderer spriteRend;
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    public Transform target;
    public Weapon weapon;

    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeStaff();
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }

    private void ChangeStaff()
    {
        switch (weapon.myWeapon)
        {
            case Weapon.Weapons.Fire:
                spriteRend.sprite = wandImages[0];
                break;
            case Weapon.Weapons.Ice:
                spriteRend.sprite = wandImages[1];
                break;
            case Weapon.Weapons.Wind:
                spriteRend.sprite = wandImages[2];
                break;
        }
        
    }
}
