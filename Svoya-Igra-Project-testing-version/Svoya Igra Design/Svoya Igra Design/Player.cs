using System;
namespace Svoya_Igra_Design
{
    [Serializable]
    public class Player: IComparable<Player>
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string NameOfTheGame { get; set; }
        public Player (string name, string nameofthegame, int score)
        {
            Name = name;
            NameOfTheGame = nameofthegame;
            Score = score;
        }
        public int CompareTo(Player player)
        {
            if (player.NameOfTheGame == this.NameOfTheGame)
            {
                return player.Score.CompareTo(this.Score);
            }
            else
            {
                return this.NameOfTheGame.CompareTo(player.NameOfTheGame);
            }
        }
    }
}
