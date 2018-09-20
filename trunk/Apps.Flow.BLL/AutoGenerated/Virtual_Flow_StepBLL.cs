//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Apps.Models;
using Apps.Common;
using Microsoft.Practices.Unity;
using System.Transactions;
using Apps.BLL.Core;
using Apps.Locale;
using Apps.Flow.IDAL;
using Apps.Models.Flow;
namespace Apps.Flow.BLL
{
	public class Virtual_Flow_StepBLL
	{
        [Dependency]
        public IFlow_StepRepository m_Rep { get; set; }

		public virtual List<Flow_StepModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<Flow_Step> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
								a=>a.Id.Contains(queryStr)
								|| a.Name.Contains(queryStr)
								|| a.Remark.Contains(queryStr)
								
								|| a.FormId.Contains(queryStr)
								
								
								
								|| a.Execution.Contains(queryStr)
								
								
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            pager.totalRows = queryData.Count();
            //排序
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        public virtual List<Flow_StepModel> CreateModelList(ref IQueryable<Flow_Step> queryData)
        {

            List<Flow_StepModel> modelList = (from r in queryData
                                              select new Flow_StepModel
                                              {
													Id = r.Id,
													Name = r.Name,
													Remark = r.Remark,
													Sort = r.Sort,
													FormId = r.FormId,
													FlowRule = r.FlowRule,
													IsCustom = r.IsCustom,
													IsAllCheck = r.IsAllCheck,
													Execution = r.Execution,
													CompulsoryOver = r.CompulsoryOver,
													IsEditAttr = r.IsEditAttr,
          
                                              }).ToList();

            return modelList;
        }

        public virtual bool Create(ref ValidationErrors errors, Flow_StepModel model)
        {
            try
            {
			    Flow_Step entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Resource.PrimaryRepeat);
                    return false;
                }
                entity = new Flow_Step(); 
				entity.Id = model.Id;
				entity.Name = model.Name;
				entity.Remark = model.Remark;
				entity.Sort = model.Sort;
				entity.FormId = model.FormId;
				entity.FlowRule = model.FlowRule;
				entity.IsCustom = model.IsCustom;
				entity.IsAllCheck = model.IsAllCheck;
				entity.Execution = model.Execution;
				entity.CompulsoryOver = model.CompulsoryOver;
				entity.IsEditAttr = model.IsEditAttr;
  

                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Resource.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }



         public virtual bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public virtual bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        if (m_Rep.Delete(deleteCollection) == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

		
       

        public virtual bool Edit(ref ValidationErrors errors, Flow_StepModel model)
        {
            try
            {
                Flow_Step entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Resource.Disable);
                    return false;
                }
                              				entity.Id = model.Id;
				entity.Name = model.Name;
				entity.Remark = model.Remark;
				entity.Sort = model.Sort;
				entity.FormId = model.FormId;
				entity.FlowRule = model.FlowRule;
				entity.IsCustom = model.IsCustom;
				entity.IsAllCheck = model.IsAllCheck;
				entity.Execution = model.Execution;
				entity.CompulsoryOver = model.CompulsoryOver;
				entity.IsEditAttr = model.IsEditAttr;
 


                if (m_Rep.Edit(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Resource.NoDataChange);
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

      

        public virtual Flow_StepModel GetById(string id)
        {
            if (IsExists(id))
            {
                Flow_Step entity = m_Rep.GetById(id);
                Flow_StepModel model = new Flow_StepModel();
                              				model.Id = entity.Id;
				model.Name = entity.Name;
				model.Remark = entity.Remark;
				model.Sort = entity.Sort;
				model.FormId = entity.FormId;
				model.FlowRule = entity.FlowRule;
				model.IsCustom = entity.IsCustom;
				model.IsAllCheck = entity.IsAllCheck;
				model.Execution = entity.Execution;
				model.CompulsoryOver = entity.CompulsoryOver;
				model.IsEditAttr = entity.IsEditAttr;
 
                return model;
            }
            else
            {
                return null;
            }
        }

        public virtual bool IsExists(string id)
        {
            return m_Rep.IsExist(id);
        }
		  public void Dispose()
        { 
            
        }

	}
}