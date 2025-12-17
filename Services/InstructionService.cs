using foodrecipe.DataModels;
using foodrecipe.Repository.Interfaces;
using foodrecipe.Services.Interfaces;

namespace foodrecipe.Services
{
    public class InstructionService : IInstructionService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public InstructionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IEnumerable<Instruction>> GetAllInstructionsAsync()
        {
            return await _repositoryWrapper.InstructionRepository.GetAllAsync();
        }

        public async Task<Instruction> GetInstructionByIdAsync(int id)
        {
            return await _repositoryWrapper.InstructionRepository.GetByIdAsync(id);
        }

        public async Task AddInstructionAsync(Instruction instruction)
        {
            await _repositoryWrapper.InstructionRepository.AddAsync(instruction);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task UpdateInstructionAsync(Instruction instruction)
        {
            await _repositoryWrapper.InstructionRepository.UpdateAsync(instruction);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteInstructionAsync(int id)
        {
            var instruction = await _repositoryWrapper.InstructionRepository.GetByIdAsync(id);
            if (instruction != null)
            {
                await _repositoryWrapper.InstructionRepository.DeleteAsync(instruction);
                await _repositoryWrapper.SaveAsync();
            }
        }
    }
}
