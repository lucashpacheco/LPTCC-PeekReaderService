namespace PeekReaderService.Models.Domain
{
    public class Peek
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Peek(string id , string name , string email)
        {
            this.Id = id;
            this.Name = name;  
            this.Email = email;
        }

        public Peek()
        {
        }
    }
}
