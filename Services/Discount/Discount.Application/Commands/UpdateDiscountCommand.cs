using Discount.Application.Responses;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Commands;

public sealed record UpdateDiscountCommand(int Id, CouponForUpdateDto CouponForUpdateDto) : IRequest<CouponModel>;