using GymOop2024.Application.Abstractions.Persistence.Repositories;
using GymOop2024.Application.Models;
using GymOop2024.Application.Models.Models.Entities;
using GymOop2024.Application.Models.Models.Interfaces;

namespace GymOop2024.Application.Services;

public class GymService : IGymService
{
    private readonly IGymRepository _gymRepository;

    public GymService(IGymRepository gymRepository)
    {
        _gymRepository = gymRepository;
    }
    public Gym AddGym(Gym gym)
    {
        _gymRepository.Add(gym);

        return gym;
    }
    
    public Gym UpdateGym(Guid gymId, Gym gym)
    {
        return _gymRepository.Update(gymId, gym);
    }
    public void RemoveGym(Gym gym)
    {
        _gymRepository.Remove(gym);
    }
    public Gym GetGymById(Guid gymId)
    {
        return _gymRepository.GetById(gymId);
    }

    public IEnumerable<Gym> GetGyms()
    {
        return _gymRepository.GetAllGyms();
    }
}