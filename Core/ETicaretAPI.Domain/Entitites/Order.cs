using ETicaretAPI.Domain.Entitites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entitites
{
    public class Order : BaseEntity
    {
        public  Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; } //bir orderın birden cok productu oldugunu ifade eder.1 e cok iliskide, coktan 1 olana koleksiyon referansı veiriz.Aynı iliskiyi productta da yapınca coka cok iliskiyi kurmus oluruz.
        public Customer Customer { get; set; }
    }
}
