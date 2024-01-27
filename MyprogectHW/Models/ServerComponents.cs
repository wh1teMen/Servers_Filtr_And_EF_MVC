namespace MyprogectHW.Models
{
    public class ServerComponents
    {
        public int Id { get; set; }//id
        public string? TitleModel { get; set; }//название компании
        public int CountSlot { get; set; } //количесвто слотов
        public int NumberOfcores { get; set; } //количество ядер
        public string? MemoryType { get; set; } //тип памяти
        List<Server> Servers { get; set; } = new(); 
        public ServerComponents() { }
    }
}
