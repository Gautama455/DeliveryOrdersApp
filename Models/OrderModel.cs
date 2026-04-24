using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryOrdersApp.Models
{
    public class Order
    {
        [Key, Column("Id")]
        public int Id { get; init;}

        [Required, MaxLength(10), Column("orderNumber")]
        public decimal OrderNumber { get; init; }

        [Required, MaxLength(100), Column("senderCity")]
        public string SenderCity { get; init; } = string.Empty;

        [Required, MaxLength(200), Column("senderAdress")]
        public string SenderAdress { get; init; } = string.Empty;

        [Required, MaxLength(100), Column("recipientCity")]
        public string RecipientCity { get; init; } = string.Empty;

        [Required, MaxLength(200), Column("recipientAdress")]
        public string RecipientAdress { get; init; } = string.Empty;

        [Required, Range(1, 150), Column("weight")]
        public decimal Weight {get; init;} = 1;

        [Required, Column("pickupDate")]
        public DateTimeOffset PickupDate { get; init; } = default;

        [Column("creatAt")]
        public DateTimeOffset CreatAt {get; init;} = DateTimeOffset.UtcNow;

        public Order( CreateOrderViewModel ovm, decimal orderNumber)
        {
            OrderNumber = orderNumber;
            SenderCity = ovm.SenderCity!;
            SenderAdress = ovm.SenderAdress!;
            RecipientCity = ovm.RecipientCity!;
            RecipientAdress = ovm.RecipientAdress!;
            Weight = ovm.Weight;
            PickupDate = ovm.PickupDate;
            PickupDate = new DateTimeOffset(
                ovm.PickupDate.Year,
                ovm.PickupDate.Month,
                ovm.PickupDate.Day,
                ovm.PickupDate.Hour,
                ovm.PickupDate.Minute,
                ovm.PickupDate.Second,
                TimeSpan.Zero
            );
        }

        public Order(){}
    }
}