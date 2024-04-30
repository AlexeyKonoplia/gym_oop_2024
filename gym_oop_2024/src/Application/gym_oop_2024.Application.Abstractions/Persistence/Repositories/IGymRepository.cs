using gym_oop_2024.Application.Models;

<<<<<<< HEAD
namespace gym_oop_2024.Application.Abstractions.Repositories;

public interface IGymRepository
{
    Gym GetGymById(int gymId);
    IEnumerable<Gym> GetAllGyms();
    IEnumerable<Gym> GetAllGymsByAddress(string GymAddress);
    void AddGym(Gym gym);
    void UpdateGym(Gym gym);
    void DeleteGym(int gymId);
=======
namespace gym_oop_2024.Application.Abstractions.Repositories;

public interface IGymRepository
{
    IEnumerable<Gym> GetAllGyms();
    Gym GetGymByAddress(string gymAddress);
    Gym Add(Gym gym);
    Gym Update(Guid gymId, Gym gym);
    Gym GetById(Guid gymId);
    void Remove(Gym gym);
>>>>>>> d86933aa3bbcf6737600a6350301c69934350ac1
}