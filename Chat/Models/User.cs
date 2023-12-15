namespace Chat.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual List<Message>? ToMessage { get; set; }
        public virtual ICollection<Message> FromMessages { get; set; } = new List<Message>();
    }
}