using FluentValidation;

namespace DSVNbaitapOPP.Model
{
    public class DSNVValidator : AbstractValidator<DSNV>
    {
        public DSNVValidator()
        {
            RuleFor(p => p.Hoten).MaximumLength(20).WithMessage("MaximumLength must be 20 {PropertyName}");
            RuleFor(p => p.Gioitinh).MaximumLength(20).WithMessage("MaximumLength must be 20 {PropertyName}");
            RuleFor(p => p.ngaysinh).MaximumLength(20).WithMessage("MaximumLength must be 20 {PropertyName}");
            RuleFor(p => p.diachi).MaximumLength(20).WithMessage("MaximumLength must be 20 {PropertyName}");
            RuleFor(p => p.chucvu).MaximumLength(20).WithMessage("MaximumLength must be 20 {PropertyName}");
        }
    }
}
