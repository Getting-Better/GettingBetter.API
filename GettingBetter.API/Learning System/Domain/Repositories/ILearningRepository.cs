using GettingBetter.API.Learning_System.Domain.Models;

namespace GettingBetter.API.Learning_System.Domain.Repositories;

public interface ILearningRepository
{
    Task<IEnumerable<Learning>> ListAsync();
    Task AddAsync(Learning learning);
    Task<Learning> FindByIdAsync(int learningId);
 
    Task<IEnumerable<Learning>> FindByStudentIdAsync(int studentId);
    Task<IEnumerable<Learning>> FindByCoachIdAsync(int coachId);
    
    void Update(Learning learning);
    void Remove(Learning learning); 
}