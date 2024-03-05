using System.Collections.Generic;

var users = GenerateUsers();

var countByTypeOld = users.GroupBy(x => x.Type).Select(x => new KeyValuePair<UserType, int>(x.Key, x.Count()));
Console.WriteLine("count by type, old:");
Print(countByTypeOld);

var countByTypeNew = users.CountBy(x => x.Type);
Console.WriteLine("count by type, new:");
Print(countByTypeNew);

Console.ReadLine();

static List<User> GenerateUsers()
{
    return
    [
        new() {
            Id = 1,
            Type = UserType.A
        },
        new() {
            Id = 2,
            Type = UserType.A
        },
        new() {
            Id = 3,
            Type = UserType.A
        },
        new() {
            Id = 4,
            Type = UserType.B
        },
        new() {
            Id = 5,
            Type = UserType.C
        },
        new() {
            Id = 4,
            Type = UserType.C
        },
    ];
}

static void Print(IEnumerable<KeyValuePair<UserType, int>> countByType)
{
    foreach (var item in countByType)
    {
        Console.WriteLine($"Type {item.Key}, count {item.Value}");
    }
    Console.WriteLine();
}

class User
{
    public int Id { get; set; }
    public UserType Type { get; set; }
}

enum UserType
{
    A,
    B,
    C
}