using Microsoft.EntityFrameworkCore;
using UniDash.API.Models.Domain;

namespace UniDash.API.Data
{
    public class UniDashDbContext : DbContext
    {
        public UniDashDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relations 
            modelBuilder.Entity<Friendship>()
                .Property(fs => fs.IsAccepted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Friendship>()
                .HasKey(fs => new { fs.UserId, fs.FriendId });

            modelBuilder.Entity<Friendship>()
                .HasOne(fs => fs.User)
                .WithMany(u => u.Inviters)
                .HasForeignKey(fs => fs.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Friendship>()
                .HasOne(fs => fs.Friend)
                .WithMany(u => u.Invitees)
                .HasForeignKey(fs => fs.FriendId)
                .OnDelete(DeleteBehavior.ClientCascade);

            // Seeding
            var newUsers = new List<User>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test",
                    Email = "lukjpl@wp.pl",
                    Login = "test",
                    Password = "Test",
                    CreatedAt = DateTime.UtcNow,
                },
                new()
                {
                    Id = Guid.Parse("79ba5203-7080-4998-85d5-9cfed69b69ba"),
                    Name = "Daniel",
                    Email = "daniel@wp.pl",
                    Login = "daniel",
                    Password = "Daniel",
                    CreatedAt = DateTime.UtcNow,
                },
                new()
                {
                    Id = Guid.Parse("ccbe10aa-0082-4f5e-9c87-4eaaa0d448c9"),
                    Name = "Lukasz",
                    Email = "lukasz@wp.pl",
                    Login = "lukasz",
                    Password = "Lukasz",
                    CreatedAt = DateTime.UtcNow,
                },
                new()
                {
                    Id = Guid.Parse("71c7ee1f-3866-47c8-a55e-19ccdb7827d2"),
                    Name = "Bartek",
                    Email = "bartek@wp.pl",
                    Login = "bartek",
                    Password = "Bartek",
                    CreatedAt = DateTime.UtcNow,
                },
                new()
                {
                    Id = Guid.Parse("34355ad1-fe6e-4e96-bfbe-73664978feb5"),
                    Name = "Krzysztof",
                    Email = "krzysztof@wp.pl",
                    Login = "krzysztof",
                    Password = "Krzysztof",
                    CreatedAt = DateTime.UtcNow,
                },
            };
            modelBuilder.Entity<User>().HasData(newUsers);

            var newEventTypes = new List<EventType>()
            {
                new()
                {
                    Id = Guid.Parse("1873d190-f08b-410e-a9a9-510a9e598cf6"),
                    Name = "Exam",
                    Icon = "biretta"
                },
                new()
                {
                    Id = Guid.Parse("d860e623-9350-49b9-9c04-573f6beff8df"),
                    Name = "Test",
                    Icon = "book"
                },
                new()
                {
                    Id = Guid.Parse("6259683a-adf4-41f2-b71f-dc311156b3b6"),
                    Name = "Presentation",
                    Icon = "board"
                }
            };
            modelBuilder.Entity<EventType>().HasData(newEventTypes);

            var newFriendships = new List<Friendship>()
            {
                new()
                {
                    UserId = Guid.Parse("79ba5203-7080-4998-85d5-9cfed69b69ba"),
                    FriendId = Guid.Parse("ccbe10aa-0082-4f5e-9c87-4eaaa0d448c9"),
                    CreatedAt = DateTime.UtcNow,
                    IsAccepted = true,
                },
                new()
                {
                    UserId = Guid.Parse("79ba5203-7080-4998-85d5-9cfed69b69ba"),
                    FriendId = Guid.Parse("71c7ee1f-3866-47c8-a55e-19ccdb7827d2"),
                    CreatedAt = DateTime.UtcNow,
                    IsAccepted = true,
                },
                new()
                {
                    UserId = Guid.Parse("71c7ee1f-3866-47c8-a55e-19ccdb7827d2"),
                    FriendId = Guid.Parse("ccbe10aa-0082-4f5e-9c87-4eaaa0d448c9"),
                    CreatedAt = DateTime.UtcNow,
                    IsAccepted = true,
                }
            };
            modelBuilder.Entity<Friendship>().HasData(newFriendships);

            var newEvents = new List<Event>()
            {
                new()
                {
                    Id = Guid.Parse("e9880e9b-ffc5-448c-bc97-cc00d6c95601"),
                    Name = "Trudny egzamin",
                    Date = DateTime.UtcNow,
                    Color = "red",
                    IsPublic = true,
                    UserId = Guid.Parse("79ba5203-7080-4998-85d5-9cfed69b69ba"),
                    EventTypeId = Guid.Parse("1873d190-f08b-410e-a9a9-510a9e598cf6"),
                },
                new()
                {
                    Id = Guid.Parse("7d32a906-40a3-4faf-bdab-30a777c028fe"),
                    Name = "Łatwy egzamin",
                    Date = DateTime.UtcNow,
                    Color = "green",
                    IsPublic = true,
                    UserId = Guid.Parse("ccbe10aa-0082-4f5e-9c87-4eaaa0d448c9"),
                    EventTypeId = Guid.Parse("1873d190-f08b-410e-a9a9-510a9e598cf6"),
                },
                new()
                {
                    Id = Guid.Parse("6622a31b-7c5d-403a-99b7-c59e643535ba"),
                    Name = "Łatwy kolos",
                    Date = DateTime.UtcNow,
                    Color = "yellow",
                    IsPublic = true,
                    UserId = Guid.Parse("ccbe10aa-0082-4f5e-9c87-4eaaa0d448c9"),
                    EventTypeId = Guid.Parse("d860e623-9350-49b9-9c04-573f6beff8df"),
                },
            };
            modelBuilder.Entity<Event>().HasData(newEvents);
        }
    }
}
