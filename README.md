# Quini6CLI

Quini6CLI is a the CLI implementation (as close to the real game as possible) of Argentina's **"Quini 6"** lottery game.
  
  

## Installation

Just download the published executable and run it in your Windows 10 system.
It was built using `.net5.0` as the project's framework and published with the `--self-contained` `-p:PublishSingleFile=true` `-p:IncludeNativeLibrariesForSelfExtract=true` parameters available in `dotnet`.  
Bottomline: there is only one file _(a large .exe)_ but that's all you need to run the game!
  
  
  
## Usage
```Quini6CLI.exe [Number of players as integer (optional)] [Iterate until jackpot command '--jackpot' (optional)]```
  
```
Number of players: optional parameter
    determine how many random-generated players there will be in the quini 6 game being executed
    if this is not provided there will only be one player
```  
```
Iterate until jackpot: optional parameter
    Important: to be able to use this parameter, the number of players must be explicitly defined in the "number of players" parameter
    determine if the game should be executed repeatedly until there is a jackpot (a.k.a. first prize) winner
    if this is not provided the game will only run once
```  
  
  
### Usage examples  
Start a single game with `1` player only (randomly generated just like when using the "Number of players" optional parameter):  
```Quini6CLI.exe```
  
Start a single game with `300000` players:  
```Quini6CLI.exe 300000```
  
Start a `jackpot-mode` series of games with `25` players:  
```Quini6CLI.exe 25 --jackpot```
  
Start a `jackpot-mode` series of games with `10000` players:  
```Quini6CLI.exe 10000 --jackpot```
  
  

## Contributing
**Pull requests are absolutely welcome.**  
For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
  
  

## License
[MIT](https://choosealicense.com/licenses/mit/)
  
  
## TBD
- Tests
- Update README with game description/rules in English (documentation in this repo is in Spanish)
