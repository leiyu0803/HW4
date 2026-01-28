# HW4
## Devlog
### The **`GameController`** is used to manage game logic and game state. 

- Controls game state through the `_isGameOver` variable
- `_score` and `_maxScore` track current and maximum scores
- In the `Update()` method, uses a cooldown timer create pipes at random heights
- Uses ***Singleton***

### While **`Player`** class used to catch player input and **4** events：

- `OnPlayerDead` - player death

- `OnPlayerScore` - player scoring

- `OnPlayerJump` - player jump

- `OnGameStart` - game start

This makes `Player` class don't need to set a references to other classes, which is **decoupled**.

## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
- [Industrial Pipe Platformer Tileset](https://wwolf-w.itch.io/industrial-pipe-platformer-tileset) - pipe