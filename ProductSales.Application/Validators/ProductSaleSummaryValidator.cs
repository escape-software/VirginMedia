//-------------------------------------------------------------------------------------------------
// Name        : ProductSaleSummaryValidator
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using FluentValidation;
using ProductSales.Application.CQRS.Requests.Commands;

namespace ProductSales.Application.Validators;

public class ProductSaleSummaryValidator : AbstractValidator<ProductSaleSummaryInsertUpdateCommandRequest>
{
    public ProductSaleSummaryValidator()
    {
        DateOnly minCreatedDate = new DateOnly(1900,1,1);

        RuleFor(p => p.ProductSaleSummary.SegmentId).GreaterThan(0).WithMessage("Invalid Segment ID. ProductSaleSummary needs an existing Segment.");
        RuleFor(p => p.ProductSaleSummary.DiscountId).GreaterThan(0).WithMessage("Invalid Discount ID. ProductSaleSummary needs an existing Discount.");
        RuleFor(p => p.ProductSaleSummary.CountryId).GreaterThan(0).WithMessage("Invalid Country ID. ProductSaleSummary needs an existing Country.");
        RuleFor(p => p.ProductSaleSummary.ProductId).GreaterThan(0).WithMessage("Invalid Product ID. ProductSaleSummary needs an existing Product.");
        RuleFor(p => p.ProductSaleSummary.SalePrice).GreaterThan(0).WithMessage("ProductSaleSummary needs a Sale Price > 0.");
        RuleFor(p => p.ProductSaleSummary.UnitsSold).GreaterThan(0).WithMessage("ProductSaleSummary needs Units Sold > 0.");
        RuleFor(p => p.ProductSaleSummary.ManufacturingPrice).GreaterThan(0).WithMessage("ProductSaleSummary needs a Manufacturing Price > 0.");
        RuleFor(p => p.ProductSaleSummary.CreatedDate).GreaterThan(minCreatedDate).WithMessage($"ProductSaleSummary needs a Created Date later than {minCreatedDate.ToString("dd/MM/yyyy")}.");
    }
}
