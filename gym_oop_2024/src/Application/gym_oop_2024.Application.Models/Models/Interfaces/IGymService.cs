namespace gym_oop_2024.Application.Models.Models.Interfaces;

public interface IGymService
{
    Gym GetGymById(int gymId);
    IEnumerable<Gym> GetAllGyms();
    IEnumerable<Gym> GetAllGymsByAddress(string GymAddress);
    void AddGym(Gym gym);
    void UpdateGym(Gym gym);
    void DeleteGym(int gymId);
}