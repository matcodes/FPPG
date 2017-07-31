# FPPG, a coding challenge test demonstrating coding ability, SOLID adherence, and testing
Application-game.
The user must select from the proposed players the player with the best fppg. They can choose 2 players to 5 players (for a greater challenge)

1. The first page loads data. If a failure occurs during download (for example, a bad Internet connection),
An error message is displayed and you were prompted to retry. To unload the data, press the Reload button.

2. On the second page you could read the rules of the game, as well as select the "Number of players to determine the player with the best fppg."
The minimum number of players is 2, the maximum is 5. The more the numbers of players in a choice, the more difficult it is is to make a choice.
To start the game, press the Start button.

3. At each iteration, the user is asked to select the player with the best fppg. If the user select is the player with the best fppg,
The's card changes to green. If the choice is not correct, then the's card becomes red. In the lower part, the screen displays information for the number of questions asked and the numbers of correct answers. After 10 correct answers, the game ends.

4. After 10 correct answers, the user will receive a message about the end of the game and receive statistics: the numbers of questions asked and the number of correct answers.
To return to page 2, press the Continue button.

Platforms: Android, iOS
Development: Xamarin (C #) Visual Studion 2015 Windows and Visual Studio for Mac
Libraries: Newtonsoft JSON
