using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class WhatIDoManager : IWhatIDoService
    {
        private readonly IWhatIDoDal _whatIDoDal;
        private readonly IMapper _mapper;

        public WhatIDoManager(IWhatIDoDal whatIDoDal, IMapper mapper)
        {
            _whatIDoDal = whatIDoDal;
            _mapper = mapper;
        }

        public IResult Add(WhatIDoDto dto)
        {
            WhatIDo whatIDo = _mapper.Map<WhatIDo>(dto);
            _whatIDoDal.Add(whatIDo);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            WhatIDo whatIDo = _whatIDoDal.Get(w => w.WhatIdoId == id);
            _whatIDoDal.Delete(whatIDo);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<WhatIDoDto>> GetAll(int isActive)
        {
            List<WhatIDo> whatIDos;
            if (isActive == 0)
                whatIDos = _whatIDoDal.GetAll(w => w.IsActive == false);
            else if (isActive == 1)
                whatIDos = _whatIDoDal.GetAll(w => w.IsActive == true);
            else
                whatIDos = _whatIDoDal.GetAll();
            List<WhatIDoDto> whatIDoDtos = _mapper.Map<List<WhatIDoDto>>(whatIDos);
            return new SuccessDataResult<List<WhatIDoDto>>(whatIDoDtos, Messages.GetAllSuccessfuly);
        }

        public IDataResult<WhatIDoDto> GetById(int id)
        {
            WhatIDo whatIDo = _whatIDoDal.Get(w => w.WhatIdoId == id);
            WhatIDoDto whatIDoDto = _mapper.Map<WhatIDoDto>(whatIDo);
            return new SuccessDataResult<WhatIDoDto>(whatIDoDto, Messages.GetByIdSuccessfuly);
        }

        public IResult Update(WhatIDoDto dto)
        {
            WhatIDo whatIDo = _mapper.Map<WhatIDo>(dto);
            _whatIDoDal.Update(whatIDo);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
    }
}
