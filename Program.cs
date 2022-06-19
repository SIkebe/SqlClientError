using SqlClientError;

var context = new MyDbContext();

Console.WriteLine("EnsureDeleted");
context.Database.EnsureDeleted();

Console.WriteLine("EnsureCreated");
context.Database.EnsureCreated();

context.Composers.Add(new Composer { ComposerId = 1, Name = "Johann Sebastian Bach", });
context.SaveChanges();

var bach = context.Composers.FirstOrDefault(c => c.Name == "Johann Sebastian Bach");
Console.WriteLine($"Composer ID: {bach?.ComposerId}");
Console.WriteLine($"Name: {bach?.Name}");
