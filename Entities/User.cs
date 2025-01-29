namespace BackEnd.Entities;

public class User
{
    private long _id;
    private string _username;

    public long Id
    {
        set => _id = value;
        get => _id;
    }

    public string Username
    {
        get => _username;
        set => _username = value;
    }
    
}