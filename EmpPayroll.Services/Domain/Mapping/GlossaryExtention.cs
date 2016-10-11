/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.SDK;
using EmpPayroll.Domain.Models;
using GlossaryItem = DAL.SDK.GlossaryItem;

namespace EmpPayroll.Domain.Mapping
{
    public static class GlossaryExtention
    {
        public static Models.GlossaryItem ToDomainGlossary(this DAL.SDK.GlossaryItem GItem)
        {
            if (GItem == null)
            {
                return null;
            }
            else
            {
                return new Models.GlossaryItem 
                {
                    GId = GItem.GId,
                    GTerm = GItem.GTerm,
                    GDefinition = GItem.GDefinition,

                };
            }
        }

        public static IEnumerable<Models.GlossaryItem> ToDomainGlossary(this IEnumerable<DAL.SDK.GlossaryItem> GItems)
        {
            return GItems.Select(GItem => GItem.ToDomainGlossary());
        }

        public static GlossaryItem ToEntityGlossary(this Models.GlossaryItem GItem)
        {
            if (GItem == null)
            {
                return null;
            }
            else
            {
                return new GlossaryItem
                {
                    GId = GItem.GId,
                    GTerm = GItem.GTerm,
                    GDefinition = GItem.GDefinition
                };
            }
        }
    }
}*/