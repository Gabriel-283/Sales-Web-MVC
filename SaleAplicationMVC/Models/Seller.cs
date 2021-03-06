using SaleAplicationMVC.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaleAplicationMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Display(Name= "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }
        public Seller(int id, string name, string email, DateTime birthDate, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Department = department;
        }

        public void AddSales(SalesRecord saleRecord)
        {
            Sales.Add(saleRecord);
        }

        public void RemoveSales(SalesRecord saleRecord)
        {
            Sales.Remove(saleRecord);
        }

        public double TotalSales (DateTime initial, DateTime final)
        {
            return Sales.Where(saleRecord => saleRecord.Date >= initial && saleRecord.Date <= final).Sum(SalesRecord => SalesRecord.Amount);
        }


    }
}
