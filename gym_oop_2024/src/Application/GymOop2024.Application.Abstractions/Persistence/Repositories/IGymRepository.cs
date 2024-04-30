using GymOop2024.Application.Models.Models.Entities;

namespace GymOop2024.Application.Abstractions.Persistence.Repositories;

public interface IGymRepository
{
    IEnumerable<Gym> GetAllGyms();

    Gym GetGymByAddress(string gymAddress);

    Gym Add(Gym gym);

    Gym Update(Guid gymId, Gym gym);

    Gym GetById(Guid gymId);

    void Remove(Gym gym);
}