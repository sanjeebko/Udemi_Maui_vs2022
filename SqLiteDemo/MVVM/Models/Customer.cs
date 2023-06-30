using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqLiteDemo.MVVM.Models;

[Table("Customers")]
public class Customer
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Column("name"), Indexed, NotNull]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Address { get; set; }

    [Unique]
    [MaxLength(100)]
    public string Phone { get; set; }

    public int Age { get; set; }

    [Ignore]
    public bool IsYoung => Age > 50;
}