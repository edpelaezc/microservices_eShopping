using Discount.Application.Responses;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Commands;

public sealed record CreateDiscountCommand(CouponDto Coupon): IRequest<CouponModel>;