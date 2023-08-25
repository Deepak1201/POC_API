using Microsoft.EntityFrameworkCore;
namespace POCAPI.Model

{
    public class Product
    {
        public int ProductID { get; set; }

        public String ProductName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
