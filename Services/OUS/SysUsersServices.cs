using DomainDTO.EFTables;
using DomainDTO.InputModels;
using DomainDTO.OutPutModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.OUS
{
    public class SysUsersServices : IServices.IOU.ISysUsersServices
    {
        private readonly IRepository.IRepostirySQLDB<SysUsersEFTables> sysUsers;

        public SysUsersServices(IRepository.IRepostirySQLDB<SysUsersEFTables> sysUsers)
        {
            this.sysUsers = sysUsers;
        }
        public int ExecuteAdd(SysUsersInputModels models)
        {
            /*
              
@Sex int,@Birthday datetime,@Disabled bit,@Img nvarchar(200),
@OUID int,@UserAccount nvarchar(20),@LeaderTitle nvarchar(20),@type int,@OuMemberId int)
              */
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter{ ParameterName="@Account", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar,Size=20, SqlValue=models.Account },
            new SqlParameter{ ParameterName="@Password", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar,Size=20, SqlValue=models.Password },
            new SqlParameter{ ParameterName="@SysUser", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.Int, SqlValue=models.SysUser },
            new SqlParameter{ ParameterName="@DisplayName", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar, Size=20, SqlValue=models.DisplayName },
            new SqlParameter{ ParameterName="@Description", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar, Size=20, SqlValue=models.Description },
            new SqlParameter{ ParameterName="@Sex", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar,Size=2,  SqlValue=models.Sex },
            new SqlParameter{ ParameterName="@Birthday", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.DateTime, SqlValue=models.Birthday },
            new SqlParameter{ ParameterName="@Disabled", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.Bit, SqlValue=models.Disabled },
              new SqlParameter{ ParameterName="@Img", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar,Size=200, SqlValue=models.Img },
                new SqlParameter{ ParameterName="@OUID", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.Int,  SqlValue=models.OUID },
            new SqlParameter{ ParameterName="@UserAccount", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar,Size=20,  SqlValue=models.Account },
            new SqlParameter{ ParameterName="@LeaderTitle", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar,Size=20,  SqlValue=models.LeaderTitle },
            new SqlParameter{ ParameterName="@type", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.Int,  SqlValue=models.Type },
            new SqlParameter{ ParameterName="@OuMemberId", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.Int,  SqlValue=models.OuMemberId },
            };

          

            return sysUsers.ExcuteProc("SP_ExcuteSysUsers", parameters);
            // return 0;
        }

        public List<SysUsersOutputModels> GetUsers(int ouId)
        {
            string tableName = "[dbo].[SysOUsEFTables] a inner join dbo.SysOUMembersEFTables b on a.OUID=b.OUID inner join SysUsersEFTables c on b.UId=c.UId";
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter{ ParameterName="@tableName", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar,Size=200, SqlValue=tableName },
            new SqlParameter{ ParameterName="@field", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar,Size=200, SqlValue="c.*" },
            new SqlParameter{ ParameterName="@where", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar,Size=200, SqlValue=" where a.ouid="+ouId },
            new SqlParameter{ ParameterName="@orderByField", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.NVarChar, Size=20, SqlValue="c.uid" },
            new SqlParameter{ ParameterName="@pageIndex", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.Int, SqlValue=1 },
            new SqlParameter{ ParameterName="@pageSize", Direction= System.Data.ParameterDirection.Input, SqlDbType= System.Data.SqlDbType.Int, SqlValue=10 },
            new SqlParameter{ ParameterName="@total", Direction= System.Data.ParameterDirection.Output, SqlDbType= System.Data.SqlDbType.Int }
            };
            return sysUsers.ExcuteSpQuery<SysUsersOutputModels>("SP_Pagniation", parameters);
          
        }
    }
}
