using ProgCentrTestTask.Application.QueryConsts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProgCentrTestTask.Web.Models
{
    public class CreateQueryModel
    {
      private SelectList attributes;
      private SelectList orderParams;
        public CreateQueryModel()
        {
            List<SelectListItem> attributesList = new List<SelectListItem>() { new SelectListItem { Text = "-", Value = string.Empty, Selected = true },  new SelectListItem { Text = "Id", Value = UserAttributes.Id }, new SelectListItem { Text = "Имя", Value = UserAttributes.Name }, new SelectListItem { Text = "Дата создания", Value = UserAttributes.CretedAt } };
            attributes = new SelectList(attributesList, "Value", "Text");

            List<SelectListItem> orderParamList = new List<SelectListItem>() { new SelectListItem { Text = "-", Value = string.Empty, Selected = true }, new SelectListItem { Text = "По возрастанию", Value = OrderParams.Ask }, new SelectListItem { Text = "По убыванию", Value = OrderParams.Desc }};
            orderParams = new SelectList(orderParamList, "Value", "Text");
        }
        [Display(Name = "Строка запроса")]
        public string Search { get; set; }

        [Display(Name = "Сортировка по атрибуту")]
        public string SortBy { get; set; }

        [Display(Name = "Порядок сортировки")]
        public string Order { get; set; }

        [Display(Name = "Страница")]
        [Range(1, 1000)]
        public string Page { get; set; }

        [Display(Name = "Записей на странице")]
        [Range(1, 1000)]
        public string Limit { get; set; }

        public SelectList AttributesSeclectList{ get { return attributes; } }

        public SelectList OrderParamsSeclectList { get { return orderParams; } }
    }
}