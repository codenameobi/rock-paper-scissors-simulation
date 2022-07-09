// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using rock_paper_scissors_simulation;

Random random = new Random();
String playerA;
String playerB;
string _saveFileName = "todo.json";
List<SavedGameModel> savedGames;
string json;


int Draws = 0;
int PlayerAScore = 0;
int PlayerBScore = 0;

for (int i = 0; i < 100; i++)
{

    playerA = "";
    playerB = "";

    playerA = "ROCK";

    switch (random.Next(1, 4))
    {
        case 1:
            playerB = "ROCK";
            break;
        case 2:
            playerB = "PAPER";
            break;
        case 3:
            playerB = "SCISSORS";
            break;
    }

    Console.WriteLine("PlayerA: " + playerA);
    Console.WriteLine("PlayerB: " + playerB);

    switch (playerA)
    {
        case "ROCK":
            if (playerB == "ROCK")
            {
                Console.WriteLine("It's a draw!");
                Draws++;
                savedGames = new List<SavedGameModel>
                {
                    new SavedGameModel { PlayerAWon = false, PlayerBWon = false, GameID = i },
                };

            }
            else if (playerB == "PAPER")
            {
                Console.WriteLine("Player B Win!");
                PlayerBScore++;
                savedGames = new List<SavedGameModel>
                {
                    new SavedGameModel { PlayerAWon = false, PlayerBWon = true, GameID = i }, 
                };
            }
            else
            {
                Console.WriteLine("Player A Win!");
                PlayerAScore++;
                savedGames = new List<SavedGameModel>
                {
                    new SavedGameModel { PlayerAWon = true, PlayerBWon = false, GameID = i },
                };
            }
            break;
        case "PAPER":
            if (playerB == "ROCK")
            {
                Console.WriteLine("Player A Win!");
                PlayerAScore++;
                savedGames = new List<SavedGameModel>
                {
                    new SavedGameModel { PlayerAWon = true, PlayerBWon = false, GameID = i },
                };
            }
            else if (playerB == "PAPER")
            {
                Console.WriteLine("It's a draw!");
                Draws++;
                savedGames = new List<SavedGameModel>
                {
                    new SavedGameModel { PlayerAWon = false, PlayerBWon = false, GameID = i },
                };
            }
            else
            {
                Console.WriteLine("Player B Win!");
                PlayerBScore++;
                savedGames = new List<SavedGameModel>
                {
                    new SavedGameModel { PlayerAWon = false, PlayerBWon = true, GameID = i },
                };
            }
            break;
        case "SCISSORS":
            if (playerB == "ROCK")
            {
                Console.WriteLine("Player B Win!");
                PlayerBScore++;
                savedGames = new List<SavedGameModel>
                {
                    new SavedGameModel { PlayerAWon = false, PlayerBWon= true, GameID = i },
                };
            }
            else if (playerB == "PAPER")
            {
                Console.WriteLine("Player A Win!");
                PlayerBScore++;
                savedGames = new List<SavedGameModel>
                {
                    new SavedGameModel { PlayerAWon = true, PlayerBWon = false, GameID = i },
                };
            }
            else
            {
                Console.WriteLine("It's a draw!");
                Draws++;
                savedGames = new List<SavedGameModel>
                {
                    new SavedGameModel { PlayerAWon = false, PlayerBWon = false, GameID = i },
                };
            }
            break;

            // Serialize it to JSON
            json = JsonSerializer.Serialize(savedGames, new JsonSerializerOptions() { WriteIndented = true });

            // Save it to a file
            File.WriteAllText(_saveFileName, json);
    }


}

Console.WriteLine("Draws: " + Draws);
Console.WriteLine("PlayerA: " + PlayerAScore);
Console.WriteLine("PlayerB: " + PlayerBScore);


Console.WriteLine("Thanks for Playing!");

