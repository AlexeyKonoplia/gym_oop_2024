using gym_oop_2024.Application.Models;

namespace a;

public interface IGymRepository
{
    IEnumerable<Gym> GetAllGyms();
    Gym GetGymByAddress(string gymAddress);
    Gym Add(Gym gym);
    Gym Update(Guid gymId, Gym gym);
    Gym GetById(Guid gymId);
    void Remove(Gym gym);
}