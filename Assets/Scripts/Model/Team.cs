using System.Collections.Generic;

public class Team
{
    public int id;
    public string name;
    public List<int> players = new List<int>();
    public long money = 5_000_000;

    public bool isInChamps = false;
    public bool isInGA = false;
    public bool isInChallange = false;
}
