public class Item{
    public int id { get; set; }  
    public string name { get; set; }
    public string description { get; set; }
    public int activated { get; set; }                // 0 : 해금안된 상태 1 : 해금된 상태 + 사용 가능 2 : 해금된 상태 + 사용 불가능

}
