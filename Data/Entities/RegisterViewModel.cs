using System.ComponentModel.DataAnnotations;

namespace QMS.Data.Entities
{
    public class RegisterViewModel
    {
        [Key]
        [Required(ErrorMessage = "กรุณากรอกรหัสบัตรประชาชน"), MaxLength(13)]
        [Display(Name = "รหัสบัตรประชาชน")]
        public string PersonalId { get; set; }

        [Required(ErrorMessage = "กรุณากรอกชื่อจริง"), MaxLength(100)]
        [Display(Name = "ชื่อจริง")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "กรุณากรอกนามสกุล"), MaxLength(100)]
        [Display(Name = "นามสกุล")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "กรุณากรอกเบอร์โทรศัพท์"), MaxLength(10)]
        [Display(Name = "เบอร์โทรศัพท์")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "กรุณากรอกรหัสผ่าน"), MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "กรุณากรอกยืนยันรหัสผ่าน")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "รหัสผ่านไม่ตรงกัน กรุณากรอกใหม่")]
        [Display(Name = "ยืนยันรหัสผ่าน")]
        public string ConfirmPassword { get; set; }
    }

}
