using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    /// <summary>
    /// Заказ
    /// </summary>

    [Table("orders", Schema = "info")]
    public class Order
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; }

        [Column("send_city")]
        public string SendCity { get; set; }

        [Column("send_street")]
        public string SendStreet { get; set; }

        [Column("send_home")]
        public int SendHome { get; set; }

        [Column("rec_city")]
        public string RecCity { get; set; }

        [Column("rec_street")]
        public string RecStreet { get; set; }

        [Column("rec_home")]
        public int RecHome { get; set; }

        [Column("weight")]
        public int Weight { get; set; }

        [Column("date_pickup")]
        public DateTime DatePickup { get; set; }
    }
}