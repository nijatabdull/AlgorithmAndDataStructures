namespace SymbolTable.HashTable.Model
{
    public class PhoneNumber
    {
        public string Number { get; set; }
        public string Prefix { get; set; }
        public string Country { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is PhoneNumber phoneNumber)
            {
                return phoneNumber.Number.Equals(this.Number) && phoneNumber.Prefix.Equals(this.Prefix) && phoneNumber.Country.Equals(this.Country);
            }

            return false;
        }

        public static bool operator ==(PhoneNumber left, PhoneNumber right)
        {
            if (ReferenceEquals(left, right)) return true;

            if(ReferenceEquals(null, left)) return false;

            return left.Equals(right);
        }

        public static bool operator !=(PhoneNumber left, PhoneNumber right) {  return !(left == right); }

        public override int GetHashCode()
        {
            unchecked // Allow arithmetic overflow, numbers will just "wrap around"
            {
                int hashcode = 1430287;
                hashcode = hashcode * 7302013 ^ Number.GetHashCode();
                hashcode = hashcode * 7302013 ^ Prefix.GetHashCode();
                hashcode = hashcode * 7302013 ^ Country.GetHashCode();
                return hashcode;
            }
        }
    }
}
