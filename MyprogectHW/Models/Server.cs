namespace MyprogectHW.Models
{
    public class Server
    {
        public int Id { get; set; }
        public string? TitleCompany { get; set; }
        //**************************************************
        public int? ComponentsId {  get; set; }        
        public ServerComponents? Components { get; set; }
        //***************************************************
        public int? OperationSystemId { get; set; }       
        public ServerOperationSystem? OperationSystem { get; set; }
        public int Expiration_date { get; set; }//срок эксплуатации

        public Server() { }
    }
}
