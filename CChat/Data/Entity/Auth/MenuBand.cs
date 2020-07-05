namespace CChat.Data.Entity.Auth
{
    public class MenuBand:Base
    {
        public string bandName { get; set; }

        public int? parentId { get; set; }

        public int? shortOrder { get; set; }
    }
}
