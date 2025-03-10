using FluentValidation;

namespace Church_Management_Service.Models.RequestModel
{
    public class MembershipValidation : AbstractValidator<MembershipRequest>
    {

        public MembershipValidation() 
        {
            RuleFor(x => x.firstName).NotEmpty().Length(3,50).WithMessage("Please specify a first name");
            RuleFor(x => x.lastName).NotEmpty().Length(3,50).WithMessage("Please specify a last name");
            RuleFor(x => x.dob).NotEmpty().WithMessage("Please specify a  date of birth");
            RuleFor(x => x.country).NotEmpty().WithMessage("Please specify a country of origin");
            RuleFor(x => x.email).NotEmpty().Length(10,100).WithMessage("Please specify a email").EmailAddress();
            RuleFor(x => x.phoneNumber).NotEmpty().WithMessage("Please specify a phone number");
        }
    }
}
