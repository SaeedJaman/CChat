namespace CChat.Data.Entity.Auth
{
    public class ModuleAccessPage : Base
    {
        public int? eRPModuleId { get; set; }
        public CChatModule eRPModule { get; set; }

      

        public string applicationRoleId { get; set; }
        public ApplicationRole applicationRole { get; set; }
    }
}
