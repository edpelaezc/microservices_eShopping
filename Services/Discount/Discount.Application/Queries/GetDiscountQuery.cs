using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Queries;

public sealed record GetDiscountQuery(string productName) : IRequest<CouponModel>;