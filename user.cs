using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cakes
{
     class Admin
     {
        public Admin()
        {
           Admin = new HashSet<Admin>();
           Vid = new HashSet<Vid>();
        }

        public int Id { get; set; }
        public string Parol{ get; set; }
        public long PaymentAccount { get; set; }
        public string DirectPassvord { get; set; }

        public virtual ICollection<Admin> Admin { get; set; }
        public virtual ICollection<Vid> Vid { get; set; }
     }

    public partial class Cakes
    {
        public Cakes()
        {
            Cakes = new HashSet<Cakes>();
        }

        public int Id { get; set; }
        public string Cakes { get; set; }
        public virtual Cakes Cakes { get; set; }
        public virtual ICollect<Cakes> Cakes { get; set; }
    }







}
