using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWhatIDoService
    {
        IDataResult<List<WhatIDoDto>> GetAll(int isActive);
        IDataResult<WhatIDoDto> GetById(int id);
        IResult Add(WhatIDoDto dto);
        IResult Update(WhatIDoDto dto);
        IResult Delete(int id);


    }
}
