using foodrecipe.DataModels;

namespace foodrecipe.Services.Interfaces
{
    public interface IInstructionService
    {
        Task<IEnumerable<Instruction>> GetAllInstructionsAsync();
        Task<Instruction> GetInstructionByIdAsync(int id);
        Task AddInstructionAsync(Instruction instruction);
        Task UpdateInstructionAsync(Instruction instruction);
        Task DeleteInstructionAsync(int id);
    }
}
