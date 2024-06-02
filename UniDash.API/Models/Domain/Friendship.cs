namespace UniDash.API.Models.Domain
{
    public class Friendship
    {   
        public Guid UserId { get; set; }
        public User User { get; set; } // Osoba dodajaca
        public Guid FriendId { get; set; }
        public User Friend { get; set; } // Osoba dodawana
        public DateTime? CreatedAt { get; set; }
        public bool IsAccepted { get; set; }
    }
}
