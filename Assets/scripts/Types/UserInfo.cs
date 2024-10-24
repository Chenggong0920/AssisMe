[System.Serializable]
public struct UserInfo
{
    public string Nickname;
    public string Gender;
    public string Age;
    public string Occupation;
    public string Major;
    public string Future;
    public string Health;
    public string Hobby;
    public string Help;

    public bool Equals(UserInfo other)
    {
        return Nickname == other.Nickname 
                && Gender == other.Gender
                && Age == other.Age
                && Occupation == other.Occupation
                && Major == other.Major
                && Future == other.Future
                && Health == other.Health
                && Hobby == other.Hobby
                && Help == other.Help;
    }

    public bool isEmpty()
    {
        return this.Equals(new UserInfo());
    }
}
