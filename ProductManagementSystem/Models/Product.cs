using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementSystem.Models
{
    public class Product
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")] 
        [MinLength(3, ErrorMessage = "Tên sản phẩm phải có ít nhất 3 ký tự")] 
        public string? Name { get; set; }

        [Required(ErrorMessage = "Giá là bắt buộc")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")] 
        [Column(TypeName = "decimal(18, 2)")] 
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Số lượng tồn kho là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho phải >= 0")] 
        public int Stock { get; set; }

        public string? Description { get; set; }
    }
}