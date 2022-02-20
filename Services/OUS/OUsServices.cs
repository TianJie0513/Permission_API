using AutoMapper;
using DomainDTO.EFTables;
using DomainDTO.InputModels;
using DomainDTO.OutPutModels;
using IRepository;
using System;
using System.Collections.Generic;
using Tools;
using System.Linq;
using DomainDTO.RedisModels;

namespace Services.OUS
{
    public class OUsServices : IServices.IOU.IOUsServices
    {
        private readonly IRepostirySQLDB<SysOUsEFTables> repostirySQLDB;
        private readonly IMapper mapper;
        private readonly IRedisHelper<List<DomainDTO.RedisModels.SysOUsRedisModels>> redis;
        private readonly IRedisHelper<SysOusRedisUpdateModels> updateRedis;

        public OUsServices(IRepostirySQLDB<SysOUsEFTables> repostirySQLDB, IMapper mapper, IRedisHelper<List<DomainDTO.RedisModels.SysOUsRedisModels>> redis, IRedisHelper<SysOusRedisUpdateModels> updateRedis)
        {
            this.repostirySQLDB = repostirySQLDB;
            this.mapper = mapper;
            this.redis = redis;
            this.updateRedis = updateRedis;

        }
        /// <summary>
        /// 执行添加部门的一个方法
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int ExecuteOUs(SysOUsInputModels models)
        {
          var model=  mapper.Map<SysOUsEFTables>(models);
            updateRedis.Set("deptUpdate", new SysOusRedisUpdateModels { Key = "deptUpdate", RedisState = 1 });
            return   repostirySQLDB.ExecuteCommand(model);
            
          
           
        }
        /// <summary>
        /// 这里是获取所有的部门信息
        /// </summary>
        /// <returns></returns>
        public DomainDTO.OutPutModels.OutputResultModels<List<DeptOutPustModels>> GetAllList()
        {
            OutputResultModels <List<DeptOutPustModels>> result = new OutputResultModels<List<DeptOutPustModels>>();
            try
            {

                #region 判断redis中是否存在数据当数据不存在时从数据库获取，当存在时从redis中获取数据
                List<SysOUsRedisModels> alllist = null;
                //redis不存在数据
                if (redis.Get("allDept") == null || redis.Get("allDept").Count <= 0)
                {
                    var allDept = repostirySQLDB.Query().ToList();
                    var redisallDept = mapper.Map<List<SysOUsRedisModels>>(allDept);
                    redis.Set("allDept", redisallDept);
                    alllist = redisallDept;
                    updateRedis.Set("deptUpdate", new SysOusRedisUpdateModels { Key = "deptUpdate", RedisState = 0 });

                }
                else
                {
                    if (updateRedis.Get("deptUpdate").RedisState == 0)
                    {
                        alllist = redis.Get("allDept");
                    }
                    else {
                        var allDept = repostirySQLDB.Query().ToList();
                        var redisallDept = mapper.Map<List<SysOUsRedisModels>>(allDept);
                        redis.Set("allDept", redisallDept);
                        alllist = redisallDept;
                        updateRedis.Set("deptUpdate", new SysOusRedisUpdateModels {  Key= "deptUpdate", RedisState=0 });
                    }
                }

                #endregion

                #region 调用递归
                result.Result= Recursion(0, alllist);
                result.Code = "200";
                result.Message = "OK";
            }
            catch (Exception ex)
            {
                result.Code = "500";
                result.Message = ex.Message;
            }
            return result;
            #endregion
        }
        private List<DeptOutPustModels> Recursion(int parentId, List<SysOUsRedisModels> list)
        {
            DeptOutPustModels a = new DeptOutPustModels();
          
            var slist = (from s in list
                         where s.ParentOUID == parentId
                         select new DeptOutPustModels
                         {
                             Code = s.Code,
                             label = s.OUName,
                             OrderIndex = s.OrderIndex,
                             OUID = s.OUID,
                             OULevel = s.OULevel,
                             ParentOUID = s.ParentOUID,
                             children = Recursion(s.OUID, list)
                         }).ToList();

            return slist;
        }
    }
}
