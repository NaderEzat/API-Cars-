using System.ComponentModel.DataAnnotations;

namespace Demo.Valditions
{
    public class TimeValid : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
           var openData = (DateTime?)value;
            if (openData <= DateTime.Now)
            {
                return true;
            }
            return false;

        }

    }
}
