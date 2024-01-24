public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
         // You first may want to unbox "value" here and cast to to a DateTime variable!
        if (((DateTime)value) <= DateTime.Now)
            return new ValidationResult("Invalid Future Date!");
        return ValidationResult.Success;
    }
}


       


