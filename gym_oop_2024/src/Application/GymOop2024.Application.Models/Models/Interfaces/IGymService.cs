using GymOop2024.Application.Models.Models.Entities;

namespace GymOop2024.Application.Models.Models.Interfaces;

public interface IGymService
{
    Gym AddGym(Gym gym);

    Gym UpdateGym(Guid gymId, Gym gym);

    void RemoveGym(Gym gym);

    Gym GetGymById(Guid gymId);

    IEnumerable<Gym> GetGyms();
}