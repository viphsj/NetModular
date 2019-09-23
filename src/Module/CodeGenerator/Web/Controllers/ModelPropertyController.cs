﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nm.Lib.Auth.Web.Attributes;
using Nm.Lib.Utils.Core.Models;
using Nm.Lib.Utils.Core.Result;
using Nm.Module.CodeGenerator.Application.ModelPropertyService;
using Nm.Module.CodeGenerator.Application.ModelPropertyService.ViewModels;
using Nm.Module.CodeGenerator.Domain.ModelProperty.Models;

namespace Nm.Module.CodeGenerator.Web.Controllers
{
    [Description("模型属性管理")]
    [Common]
    public class ModelPropertyController : ModuleController
    {
        private readonly IModelPropertyService _service;

        public ModelPropertyController(IModelPropertyService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]ModelPropertyQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(ModelPropertyAddModel model)
        {
            return _service.Add(model);
        }

        [HttpDelete]
        [Description("删除")]
        public async Task<IResultModel> Delete([BindRequired]Guid id)
        {
            return await _service.Delete(id);
        }

        [HttpGet]
        [Description("编辑")]
        public async Task<IResultModel> Edit([BindRequired]Guid id)
        {
            return await _service.Edit(id);
        }

        [HttpPost]
        [Description("修改")]
        public Task<IResultModel> Update(ModelPropertyUpdateModel model)
        {
            return _service.Update(model);
        }

        [HttpGet]
        [Description("获取排序信息")]
        public Task<IResultModel> Sort([FromQuery]ModelPropertyQueryModel model)
        {
            return _service.QuerySortList(model);
        }

        [HttpPost]
        [Description("更新排序信息")]
        public Task<IResultModel> Sort(SortUpdateModel<Guid> model)
        {
            return _service.UpdateSortList(model);
        }

        [HttpPost]
        [Description("修改可空状态")]
        public Task<IResultModel> UpdateNullable(ModelPropertyUpdateNullableModel model)
        {
            return _service.UpdateNullable(model);
        }

        [HttpGet]
        [Description("获取下拉列表")]
        public Task<IResultModel> Select([FromQuery]ModelPropertyQueryModel model)
        {
            return _service.Select(model);
        }

        [HttpPost]
        [Description("从实体中导入属性")]
        public Task<IResultModel> ImportFromEntity(ModelPropertyImportModel model)
        {
            return _service.ImportFromEntity(model);
        }
    }
}
