using System.ComponentModel.DataAnnotations.Schema;

namespace CChat.Areas.Auth.Models
{
    [NotMapped]
    public class ModuleAccessPageViewModel
    {


        public int? eRPModuleId { get; set; }
        public string eRPModuleName { get; set; }

        public int active { get; set; }
    


    }
}
