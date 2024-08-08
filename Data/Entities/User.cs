using System.ComponentModel.DataAnnotations;

namespace QMS.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }  // Primary key

        [Required(ErrorMessage = "กรุณากรอกรหัสบัตรประชาชน")]
        public string PersonalId { get; set; }

        [Required(ErrorMessage = "กรุณากรอกชื่อ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "กรุณากรอกนามสกุล")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "กรุณากรอกหมายเลขโทรศัพท์")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "กรุณากรอกรหัสผ่าน")]
        public string Password { get; set; }
    }

}
