namespace a;

public interface IGymRepository
{
    Gym GetGymById(int gymId);
    IEnumerable<Gym> GetAllGyms();
    IEnumerable<Gym> GetAllGymsByAddress(string GymAddress);
    void AddGym(Gym gym);
    void UpdateGym(Gym gym);
    void DeleteGym(int gymId);
}