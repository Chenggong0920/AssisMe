using System.Diagnostics;

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

    public static UserInfo CreateDefault()
    {
        return new UserInfo
        {
            Nickname = string.Empty,
            Gender = string.Empty,
            Age = string.Empty,
            Occupation = string.Empty,
            Major = string.Empty,
            Future = string.Empty,
            Health = string.Empty,
            Hobby = string.Empty,
            Help = string.Empty
        };
    }

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
        return this.Equals(CreateDefault());
    }
}
