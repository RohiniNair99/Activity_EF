using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityEF_DTO;

namespace ActivityEF_DAL
{
    public class Department_DAL
    {
        Department deptDALObj;
        public int UpdateDepartment(Department_DTO newObj)
        {
            int ret = 0;
            try
             {
            
            AdvConnectDB Advcontext = new AdvConnectDB();



            deptDALObj = Advcontext.Departments.SingleOrDefault(d => d.DepartmentID == newObj.DepartmentID);
                if (deptDALObj != null)
                {
                    deptDALObj.Name = newObj.Name;
                    deptDALObj.GroupName = newObj.GroupName;
                    deptDALObj.ModifiedDate = newObj.ModifiedDate;
                    Advcontext.SaveChanges();
                    ret = 1;


                }
                else
                    throw new Exception();
            
             }

              catch(Exception ex)
              {
                  Console.WriteLine("Update failed.");
              }
            return ret;
        }

        public int deleteDepartment(short DepartmentId)
        {
            int ret = 0;
            try
            {

                using (Advcontext = new AdvConnectDB())
                {
                    Department department = new Department();
                    department = Advcontext.Departments.Find(DepartmentId);
                    Advcontext.Departments.Remove(department);
                    ret = Advcontext.SaveChanges();
                    return ret;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Deletion failed.");
                throw ex;
            }
            
        }

        public List<Department> DisplayDepartment()
        {
            try
            {
                var Advcontext = new AdvConnectDB();

                List<Department> deptList = Advcontext.Departments.ToList();

                return deptList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
