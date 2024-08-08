using System.ComponentModel.DataAnnotations;

namespace QMS.Data.Entities
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "กรุณากรอกรหัสบัตรประชาชน")]
        public string PersonalId { get; set; }

        [Required(ErrorMessage = "กรุณากรอกรหัสผ่าน")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

}
