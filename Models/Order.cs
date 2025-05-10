using System.ComponentModel.DataAnnotations;

namespace RestaurantApplication.Models {
    public class Order {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public decimal TotalPrice { get; set; }
    }
}
