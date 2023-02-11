namespace PetShop.Model
{
    public class Customer : EntityBase
    {
        public Customer(string name, string surname, string phone, string tin)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Tin = tin;

            Transactions = new List<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Tin { get; set; }

        public string CustomerFullName {
            get {
                return string.Format("{0} {1}", Name, Surname);
            }
        }
        // Relations
        public List<Transaction> Transactions { get; set; }
    }
}
