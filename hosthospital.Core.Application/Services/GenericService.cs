using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using hosthospital.Core.Application.Interfaces.Repositories;
using hosthospital.Core.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Internetbanking.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Entity> : IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Update(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);

            await _repository.UpdateAsync(entity, id);
        }
        public async Task<SaveViewModel> Add(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);

            entity = await _repository.AddAsync(entity);
            SaveViewModel saveVm = _mapper.Map<SaveViewModel>(entity);
            return saveVm;
        }

        public async Task Delete(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
       
        public async Task<SaveViewModel> GetByIdSaveViewModel(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            SaveViewModel vm = _mapper.Map<SaveViewModel>(entity);

            return vm;
        }

        public async Task<List<ViewModel>> GetAllViewModel()
        {
            List<Entity> entity = await _repository.GetAllAsync();

            List<ViewModel> vm = _mapper.Map<List<ViewModel>>(entity);
            return vm;
        }
    }
}