using ExampleClassLibrary;

var users = new List<User>()
{
    new("Sam", 23),
    new("Bob", 31),
    new("Tim", 29),
    new("Joe", 42),
    new("Leo", 35),
};

var companies = new List<Company>()
{
    new(){ Title = "Yandex", Users = new List<User>(){ users[0], users[1] } },
    new(){ Title = "Mail Group", Users = new List<User>(){ users[2], users[3], users[4] } },
    new(){ Title = "Ozon", Users = new List<User>(){ new("Jim", 25), new("Tom", 44)  } },
};

var cities = new List<string>(){"Moscow", "Orel", "Tula"};

var usersCities = from u in users
                  from c in cities
                  select new
                  {
                      Name = u.Name,
                      City = c,
                  };

//foreach(var item in usersCities)
//    Console.WriteLine($"Name: {item.Name}, City: {item.City}");


var usersAll = companies.SelectMany(c => c.Users!);
//var usersAllSelect = companies.Select(c => c.Users!);

var usersAllO = from c in companies
                from u in c.Users!
                select u;

//foreach (var item in usersAllO)
//    Console.WriteLine($"User: name {item.Name}, age {item.Age}");

//foreach(var list in usersAllSelect)
//    foreach(var user in list)
//        Console.WriteLine($"User: name {user.Name}, age {user.Age}");

var usersCompAllM = companies.SelectMany(c => c.Users,
                                        (c, u) => new
                                        {
                                            CompanyTitle = c.Title,
                                            UserName = u.Name,
                                        });

var usersCompAllO = from c in companies
                    from u in c.Users!
                    select new 
                    {
                        CompanyTitle = c.Title,
                        UserName = u.Name,
                    };

foreach(var user in usersCompAllO)
    Console.WriteLine($"Company: {user.CompanyTitle}, name: {user.UserName}");


class Company
{
    public string? Title { set; get; }
    public List<User>? Users { set; get; }
}