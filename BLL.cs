using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLL
/// </summary>
public class BLL
{
    public BLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
public int insertstudentinfo(string StudentName, string Address, string PhoneNo, string Email, int Gender, string RollNo, int fid, int sid, int status)
    {
        SqlParameter[] param = new SqlParameter[]
       {
            new SqlParameter("@a", StudentName),
            new SqlParameter("@b", Address),
            new SqlParameter("@c", PhoneNo),
            new SqlParameter("@d", Email),
            new SqlParameter("@e", Gender),
            new SqlParameter("@f",RollNo),
            new SqlParameter("@g",fid),
            new SqlParameter("@h", sid),
            new SqlParameter("@i", status )

      };
        return DAO.IUD("insert into tblStudent values(@a,@b,@c,@d,@e,@f,@g,@h,@i)", param, CommandType.Text);

    }
public int insertteachersinfo(string TeacherName, string Address, string PhoneNo, string Email, int Gender, string shift, int type, int fid, int sid, int subid, int status)
    {
        SqlParameter[] param = new SqlParameter[]
      {
            new SqlParameter("@a", TeacherName),
            new SqlParameter("@b", Address),
            new SqlParameter("@c", PhoneNo),
            new SqlParameter("@d", Email),
            new SqlParameter("@e", Gender),
            new SqlParameter("@f", shift),
            new SqlParameter("@g", type),
            new SqlParameter("@h", fid),
            new SqlParameter("@i", sid),
            new SqlParameter("@j", subid),
            new SqlParameter("@k", status)

     };
        return DAO.IUD("insert into tblTeachers values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k)", param, CommandType.Text);
    }
public int insertsubject(string SubjectName, int fid, int sid, int status)
    {
        SqlParameter[] param = new SqlParameter[]
       {
            new SqlParameter("@a", fid),
            new SqlParameter("@b", sid),
            new SqlParameter("@c", SubjectName),
            new SqlParameter("@d", status)

       };
        return DAO.IUD("insert into tblSubjects values(@a,@b,@c,@d)", param, CommandType.Text);
     }
public int InsertSemester(string SemesterName, int fid, int Status)
    {
        SqlParameter[] param = new SqlParameter[]
       {
            new SqlParameter("@SemesterName", SemesterName),
            new SqlParameter("@fid", fid),
            new SqlParameter("@Status", Status)
       };
        return DAO.IUD("insert into tblSemester values(@fid,@SemesterName,@Status)", param, CommandType.Text);
    }
public DataTable loginvalidation(string Username, string Password)
    {

        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@Username",Username),
            new SqlParameter("@password",Password)
            
                };
        return DAO.GetTable("select * from tblUserInformation where UserName=@Username and Password= @password and Status=1", param, CommandType.Text);
    }
    public DataTable GetFaculty()
    {
        
        return DAO.GetTable("select * from tblFaculty where Status=1", null, CommandType.Text);
    }

    public DataTable GetSemesterByFacultyId(int fid)
    {

        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@fid",fid)
         
                };
        return DAO.GetTable("select * from tblSemester where facultyId=@fid", param, CommandType.Text);
    }
    public DataTable GetSubjectByFacultyIdAndSemesterId(int fid,int sid)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@fid",fid),
            new SqlParameter("@sid",sid)

                };
        return DAO.GetTable("select * from tblSubjects where facultyId=@fid and semesterId=@sid", param, CommandType.Text);
    }
public int InsertUserRole(string RoleName)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@rname", RoleName)

                };
        return DAO.IUD("insert into tblUserRole values(@rname)", param, CommandType.Text);
    }
public DataTable GetUserRole()
    {
        
        return DAO.GetTable("select * from tblUserRole", null, CommandType.Text);
    }
  public int InsertUserInformation(string Fullname, string Username, string Password, int userrole, int gender, string rollno, int fid, int sid, int status)
    {
        SqlParameter[] param = new SqlParameter[]
      {
            new SqlParameter("@a", Fullname),
            new SqlParameter("@b", Username),
            new SqlParameter("@c", Password),
            new SqlParameter("@d", userrole),
            new SqlParameter("@e", gender),
            new SqlParameter("@f", rollno),
            new SqlParameter("@g", fid),
            new SqlParameter("@h", sid),
            new SqlParameter("@i", status)
            
     };
        return DAO.IUD("insert into tblUserInformation values(@a,@b,@c,@d,@e,@f,@g,@h,@i)", param, CommandType.Text);
    }
public DataTable LoadFaculty()
    {
        return DAO.GetTable("select * from tblFaculty", null, CommandType.Text);
    }
public int InsertFacultyInfo(string FacultyName, string Shift, int status) 
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@a", FacultyName),
            new SqlParameter("@b", Shift),
            new SqlParameter("@c", status)
        };
        return DAO.IUD("insert into tblFaculty values(@a,@b,@c)", param, CommandType.Text);
    }
public DataTable GetFacultybyId(int id)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@Id",id)
                };
        return DAO.GetTable("select * from tblFaculty where fId=@Id", param, CommandType.Text);
    }
public int DeleteFaculty(int id)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@Id",id)
                };
        return DAO.IUD("delete from tblFaculty where fId=@Id ", param, CommandType.Text);
    }
public DataTable GetTeacherInfo()
    {
        return DAO.GetTable("select * from tblTeachers", null, CommandType.Text);
    }
public DataTable GetTeacherInfobyId(int id)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@Id",id)
                };
        return DAO.GetTable("select * from tblTeachers where tId=@Id ", param, CommandType.Text);
    }
public int DeleteTeacher(int id)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@Id",id)
                };
        return DAO.IUD("delete from tblTeachers where tId=@Id", param, CommandType.Text);
    }
public int UpdateFaculty(String Facultyname, string shift, int status, int id)
    {
        SqlParameter[] param = new SqlParameter[]
  {
            new SqlParameter("@a", Facultyname),
            new SqlParameter("@b", shift),
            new SqlParameter("@c", status),
            new SqlParameter("@d", id)
           
 };
        return DAO.IUD("update tblFaculty set FacultyName=@a, Shifts=@b, Status=@c where fId=@d",param,CommandType.Text);
    }
public int UpdateTeacher(string Teachername, string address, string phoneno, string email, int gender, string shifts, int type, int facultyid, int semesterid, int subjectid, int status, int id)
    {
        SqlParameter[] param= new SqlParameter[]
        {
            new SqlParameter("@a", Teachername),
            new SqlParameter("@b", address),
            new SqlParameter("@c", phoneno),
            new SqlParameter("@d", email),
            new SqlParameter("@e", gender),
            new SqlParameter("@f", shifts),
            new SqlParameter("@g", type),
            new SqlParameter("@h", facultyid),
            new SqlParameter("@i", semesterid),
            new SqlParameter("@j", subjectid),
            new SqlParameter("@k", status),
            new SqlParameter("@l", id)


 };
        return DAO.IUD("update tblTeachers set TeacherName=@a, Address= @b, PhoneNo= @c,Email= @d, Gender= @e, Shifts= @f, type=@g, facultyId= @h, semesterID= @i, subjectId=@j, Status=@k where tId=@l", param, CommandType.Text);
    }
public DataTable GetStudentInfo()
    {
        return DAO.GetTable("select * from tblStudent", null, CommandType.Text);
    }
public int UpdateStudent(string studentname , string address , string phoneno , string email , int gender , string Rollno , int faculty , int semester , int status , int id)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@a", studentname),
            new SqlParameter("@b", address),
            new SqlParameter("@c", phoneno),
            new SqlParameter("@d", email),
            new SqlParameter("@e", gender),
            new SqlParameter("@f", Rollno),
            new SqlParameter("@g", faculty),
            new SqlParameter("@h",semester),
            new SqlParameter("@i",status),
            new SqlParameter("@j",id)


 };
        return DAO.IUD("update tblStudent set StudentName=@a, Address=@b, PhoneNo=@c, Email=@d, Gender=@e, RollNo=@f, FacultyId=@g, SemesterId=@h, Status=@i where sid=@j", param, CommandType.Text);
    }
public int DeleteStudent(int id)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@Id",id)
                };
        return DAO.IUD("delete from tblStudent where sid=@Id", param, CommandType.Text);
    }
    public DataTable GetStudentInfoById(int id)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@Id",id)
                };
        return DAO.GetTable("select * from tblStudent where sid=@Id ", param, CommandType.Text);
    }
    public DataTable GetSemesterInfo()
    {
        return DAO.GetTable("select * from tblSemester", null, CommandType.Text);
    }
    public DataTable GetSemesterById(int id)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@Id",id)
                };
        return DAO.GetTable("select * from tblStudent where semId=@Id ", param, CommandType.Text);
    }
    public int DeleteSemester(int id)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@Id",id)
                };
        return DAO.IUD("delete from tblSemster where semId=@ID ", param, CommandType.Text);

    }
    public DataTable GetSubjectInfo()
    {
        return DAO.GetTable("select * from tblSubjects", null, CommandType.Text);
    }
    public DataTable GetSubjectInforById(int id)
    {
        SqlParameter[] param = new SqlParameter[]
       {
            new SqlParameter("@Id",id)
               };
        return DAO.GetTable("select * from tblSubjects where subId=Id", param, CommandType.Text);
    }
    public int DeleteSubject(int id)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@Id",id)
                };
        return DAO.IUD("delete from tblSubjects where subId=@ID ", param, CommandType.Text);
    }
    public DataTable LoadAssigment()
    {
        return DAO.GetTable("select * from tblAssignment", null, CommandType.Text);
    }
    public int InsertAssignmentInfo(string StudentName, int faculty, int semester, int subject, DateTime date, string Status)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@sname", StudentName),
            new SqlParameter("@facul", faculty),
            new SqlParameter("@sem", semester),
            new SqlParameter("@sub", subject),
            new SqlParameter("@date", date),
            new SqlParameter("@status", Status),



                };
        return DAO.IUD("insert into tblAssignment values(@sname, @facul, @sem, @sub, @date,@status)", param, CommandType.Text);
    }
    public int UpdateAssignment(string studentname, int faculty, int semester, int subject, DateTime date, int id, string Status) 
    {
        SqlParameter[] param = new SqlParameter[]
       {
            new SqlParameter("@a", studentname),
            new SqlParameter("@b", faculty),
            new SqlParameter("@c", semester),
            new SqlParameter("@d", subject),
            new SqlParameter("@e", date),
            new SqlParameter("@f", id),
            new SqlParameter("@g", Status)

};
        return DAO.IUD("update tblAssignment set StudentName=@a, Faculty=@b, Semester=@c, Subject= @d, SubmittedDate=@e, Status= @g where aid=@f", param, CommandType.Text);
    }
public DataTable GetAssignmentById(int id)
    {
        SqlParameter[] param = new SqlParameter[]
       {
            new SqlParameter("@Id",id)
               };
        return DAO.GetTable("select * from tblAssignment where aid=@Id", param, CommandType.Text);
    }
}
