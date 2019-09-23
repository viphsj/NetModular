﻿using System.Threading.Tasks;
using Nm.Lib.Utils.Core.Result;
using Nm.Module.Admin.Application.ConfigService.ViewModels;
using Nm.Module.Admin.Domain.Config;
using Nm.Module.Admin.Domain.Config.Models;

namespace Nm.Module.Admin.Application.ConfigService
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _repository;

        public ConfigService(IConfigRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResultModel> Query(ConfigQueryModel model)
        {
            var result = new QueryResultModel<ConfigEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };

            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(ConfigAddModel model)
        {
            if (await _repository.Exists(model.Key))
                return ResultModel.HasExists;

            var entity = new ConfigEntity
            {
                Key = model.Key,
                Value = model.Value,
                Remarks = model.Remarks
            };

            var result = await _repository.AddAsync(entity);

            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Delete(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return ResultModel.Failed("数据项不存在");

            var result = await _repository.DeleteAsync(id);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Edit(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return ResultModel.Failed("数据项不存在");

            var model = new ConfigUpdateModel
            {
                Id = id,
                Key = entity.Key,
                Value = entity.Value,
                Remarks = entity.Remarks
            };

            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(ConfigUpdateModel model)
        {
            var entity = await _repository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.Failed("数据项不存在");

            entity.Key = model.Key;
            entity.Value = model.Value;
            entity.Remarks = model.Remarks;

            if (await _repository.Exists(entity))
                return ResultModel.Failed($"{model.Key}键已存在");

            var result = await _repository.UpdateAsync(entity);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> GetValueByKey(string key)
        {
            var entity = await _repository.GetByKey(key);
            if (entity == null)
                return ResultModel.Success(string.Empty);

            return ResultModel.Success(entity.Value);
        }
    }
}
