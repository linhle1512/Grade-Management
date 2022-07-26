using MRA_Client.DataAccess;
using MRA_Client.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRA_Client.Controller
{
    class StudentMarkController
    {
        internal static DataTable GetListOfSubject(string rollStudent)
        {
            string sql = @"Select S.roll from Subject as S
                        inner join SubjectClass sc	on S.roll = sc.rollsubject
                        inner join ClassDetail cd on sc.rollclass = cd.rollclass
                        left join Student ss on cd.rollstudent = ss.roll
                        where ss.roll = @rollStudent";

            SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@rollStudent", SqlDbType.NChar) { Value = rollStudent}
            };

            return DAO.GetDataBySQL(sql, parameter);
        }

    }
}
