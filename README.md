# TPS Shooter Controller Unity

Work in progress 3rd person Character controller, being developed mostly for learning more about Unity.

Unity packages used:
  - Input System
  - Cinemachine
  - TextMeshPro

Basic character model and movement animations from Mixamo.
Weapon models from Opengameart.


So far it includes:

### Movement

8-way locomotion, sprinting, crouching, jumping all the usual stuff

Smooth start/stop/transition, character controlled based.

### Animation
blend trees and animation layers to reduce the number of required animation clips.

Ik for aiming the body and hands in the direction of the target.

### Combat
shooting, reloading, weapon switching. Particles for muzzle flash, bullet tracers ect..

Pick up new weapons.

Raycasts for hit detection. Applies dmg, knockback, bleed/hit effect depending on target hit.

Ik for differend hand positions for each weapon, so i wont need a sepparate animation.

### Audio
Only basic for now, gunshot, reload, gun empty.

### Camera
2 camera modes
- free look/rotate mode
- aiming mode where character faces camera direction and aims the weapon using Ik.

Camera Zoom
### Health system and basic Ai
Very basic state based ai (static, roaming atm, chase and attack coming soon)


### Inventory system and UI
displays weapon/ammo health etc

interact, drop weapons and basic UI.

full ui and inventory coming soon





