﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Nm.Lib.Utils.Core.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nm.Lib.Swagger.Core.Filters
{
    /// <summary>
    /// 控制器和方法的描述信息处理
    /// </summary>
    public class DescriptionDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            SetControllerDescription(swaggerDoc, context);
            SetActionDescription(swaggerDoc, context);
        }

        /// <summary>
        /// 设置控制器的描述信息
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        private void SetControllerDescription(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc.Tags == null)
                swaggerDoc.Tags = new List<Tag>();

            foreach (var apiDescription in context.ApiDescriptions)
            {
                if (apiDescription.TryGetMethodInfo(out MethodInfo methodInfo) && methodInfo.DeclaringType != null)
                {
                    var descAttr = (DescriptionAttribute)Attribute.GetCustomAttribute(methodInfo.DeclaringType, typeof(DescriptionAttribute));
                    if (descAttr != null && descAttr.Description.NotNull())
                    {
                        var controllerName = methodInfo.DeclaringType.Name;
                        controllerName = controllerName.Remove(controllerName.Length - 10);
                        if (swaggerDoc.Tags.All(t => t.Name != controllerName))
                        {
                            swaggerDoc.Tags.Add(new Tag
                            {
                                Name = controllerName,
                                Description = descAttr.Description
                            });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置方法的说明
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        private void SetActionDescription(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var path in swaggerDoc.Paths)
            {
                if (TryGetActionDescription(path.Key, context, out string description))
                {
                    if (path.Value.Get != null)
                        path.Value.Get.Summary = description;
                    else if (path.Value.Post != null)
                        path.Value.Post.Summary = description;
                    else if (path.Value.Delete != null)
                        path.Value.Delete.Summary = description;
                    else if (path.Value.Put != null)
                        path.Value.Put.Summary = description;
                    else if (path.Value.Head != null)
                        path.Value.Head.Summary = description;
                    else if (path.Value.Options != null)
                        path.Value.Options.Summary = description;
                    else if (path.Value.Patch != null)
                        path.Value.Patch.Summary = description;
                }
            }
        }

        private bool TryGetActionDescription(string path, DocumentFilterContext context, out string description)
        {
            foreach (var apiDescription in context.ApiDescriptions)
            {
                var apiPath = "/" + apiDescription.RelativePath.ToLower();
                if (apiPath.Equals(path) && apiDescription.TryGetMethodInfo(out MethodInfo methodInfo))
                {
                    var descAttr = (DescriptionAttribute)Attribute.GetCustomAttribute(methodInfo, typeof(DescriptionAttribute));
                    if (descAttr != null && descAttr.Description.NotNull())
                    {
                        description = descAttr.Description;
                        return true;
                    }
                }
            }

            description = "";
            return false;
        }
    }
}
