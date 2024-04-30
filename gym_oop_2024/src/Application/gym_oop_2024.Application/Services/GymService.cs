using gym_oop_2024.Application.Models;
using gym_oop_2024.Application.Models.Models.Interfaces;

namespace gym_oop_2024.Application.Services;

public class GymService : IGymService
{
    public Gym GetGymById(int gymId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Gym> GetAllGyms()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Gym> GetAllGymsByAddress(string GymAddress)
    {
        throw new NotImplementedException();
    }

    public void AddGym(Gym gym)
    {
        throw new NotImplementedException();
    }

    public void UpdateGym(Gym gym)
    {
        throw new NotImplementedException();
    }

    public void DeleteGym(int gymId)
    {
        throw new NotImplementedException();
    }
}