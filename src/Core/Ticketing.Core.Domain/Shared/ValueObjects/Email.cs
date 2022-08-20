using System.Net.Mail;

namespace Ticketing.Core.Domain.Shared.ValueObjects
{
    public class Email : BaseValueObject<Email>
    {

        public string Value { get; private set; }
        public static Email FromString(string value) => new(value);

        private Email()
        {

        }

        public Email(string value)
        {
            if (!IsValid(value))
            {
                throw new FormatException("Invalid Email Address.");
            }

            Value = value;
        }

        private static bool IsValid(string email)
        {
            try
            {
                var m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static implicit operator string(Email email) => email.Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
