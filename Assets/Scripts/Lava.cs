using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lava : MonoBehaviour
{
   [SerializeField]private PlayerController _player;

   public void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
           _player.Death();
       }
   }
}
