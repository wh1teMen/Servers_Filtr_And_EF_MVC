namespace MyprogectHW.Models
{
    public class ServerOperationSystem
    {
        public int Id { get; set; }
        public string? TitleOS { get; set; }
        List<Server> Servers { get; set; } = new();
        public ServerOperationSystem() { }
    }
}
