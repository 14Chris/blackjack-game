using Domain.ValueObjects;

namespace Domain;

public sealed record Card(CardColor Color, CardValue Value);