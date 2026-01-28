# HW4
## Devlog
The GameController class defines the control side, and the ViewController handles the view side. The logic of the game stays entirely within the Bird (player code), Pipe, and GameController
classes. They are decoupled from the view, which knows nothing about the current game state. GameController handles pipe spawning in _Update(), and the Pipes and Bird handle their own movement.
The view only listens for when the player jumps, collides, restarts, or earns a point, and plays the appropriate sound effect (via _playJump(), _playCollide(), etc), but it never
directly references a variable stored by the player. The view also updates the score text, but it never tracks the current or high score; all of that is done within the _addScore()
and _updateScore() methods of GameController. 
The GameController singleton keeps the view isolated from the controller with events. For example, when the Bird collides with a pipe, the view only knows of the collision due to the player's BirdDied event being linked to 
ViewController's _playCollect() method, a link formed through the GameController singleton. The view never has any direct contact with the Bird or 
any other controller-side gameobject. The view only receives events from them. It does not store anything but its own children in serialized fields. It relies on the GameController singleton to subscribe to controller events, and thus
it only takes directives from the controller. Controller-side game objects also store no reference to the view; controller objects do not even know the view exists. 

## Open-Source Assets
If you added any other assets, list them here!
- [2d bird sprites](https://carysaurus.itch.io/bird-sprites) - bird sprites
- [2d pipe sprites](https://wwolf-w.itch.io/industrial-pipe-platformer-tileset) - pipe sprites
- [2d ground sprites](https://sanctumpixel.itch.io/forest-lite-pixel-art-tileset) - ground sprites
- [8-bit / 16-bit SFX pack](https://jdwasabi.itch.io/8-bit-16-bit-sound-effects-pack) - sound effects

