using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.ViewComponents
{
    public class WhatIDoPart: ViewComponent
    {
        private readonly IWhatIDoService _whatIDoService;

        public WhatIDoPart(IWhatIDoService whatIDoService)
        {
            _whatIDoService = whatIDoService;
        }
        public IViewComponentResult Invoke()
        {
            var result = _whatIDoService.GetAll(1).Data;
            return View(result);
        }
    }
}
