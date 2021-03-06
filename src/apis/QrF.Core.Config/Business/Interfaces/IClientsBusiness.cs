﻿using QrF.Core.Config.Dto;
using System.Threading.Tasks;

namespace QrF.Core.Config.Interfaces
{
    public interface IClientsBusiness
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        Task<BasePageOutput<ClientsDto>> GetPageList(PageInput input);
        /// <summary>
        /// 编辑信息
        /// </summary>
        Task EditModel(ClientsDto input);
        /// <summary>
        /// 删除
        /// </summary>
        Task DelModel(int input);
    }
}
