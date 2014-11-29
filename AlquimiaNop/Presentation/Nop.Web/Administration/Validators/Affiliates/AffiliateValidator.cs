using FluentValidation;
using Nop.Admin.Models.Affiliates;
using Nop.Services.Localization;

namespace Nop.Admin.Validators.Affiliates
{
    public class AffiliateValidator : AbstractValidator<AffiliateModel>
    {
        public AffiliateValidator(ILocalizationService localizationService)
        {
            //I think this code can speak for itself
            RuleFor(m => m.AffiliateWebSite).Length(0, 255);
        }
    }
}