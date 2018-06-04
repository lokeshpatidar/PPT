using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;


namespace PPT
{
    public class DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPTConnection"].ConnectionString);
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["eCRFConnection_Master"].ConnectionString);

        //Get Connection
        public string getconstr()
        {
            //SqlConnection sqlcon;
            //sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["eCRFConnection"].ConnectionString);
            return ConfigurationManager.ConnectionStrings["PPTConnection"].ConnectionString;
        }
        public DataSet GetProjectName(string Action = null, string strCMD = null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                //Get Data for Update
                cmd = new SqlCommand(strCMD, con);
                cmd.CommandType = CommandType.Text;
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Action", Action);
                //cmd.Parameters.AddWithValue("@PVID", strCMD);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ////ds.Dispose();
            }
            return ds;
        }
        public DataSet GetUserGroupID(string Action = null, string Project_Name = null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                cmd = new SqlCommand("Get_User_Group_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ////ds.Dispose();
            }
            return ds;
        }
        public DataSet GetUserGroupfunctions(string Action = null, string Project_Name = null, string UserGroup_Name = null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                cmd = new SqlCommand("Get_UserGroup_functions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
                cmd.Parameters.AddWithValue("@UserGroup_Name", Project_Name);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ////ds.Dispose();
            }
            return ds;
        }
        public void AddUserRights(string Action = null, string Project_Name = null, string UserGroup_Name = null, int FunctionID = -1, string User_Name = null, string Parent = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Add_Up_Del_User_Group_Fun", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
                cmd.Parameters.AddWithValue("@UserGroup_Name", UserGroup_Name);
                cmd.Parameters.AddWithValue("@FunctionID", FunctionID);
                cmd.Parameters.AddWithValue("@Parent", Parent);
                cmd.Parameters.AddWithValue("@EnteredBy", ENTEREDBY);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }
        public void AddUserGroupFun(string Action = null, string Project_Name = null, string UserGroup_Name = null, int FunctionID = -1, string Parent = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Add_Up_Del_User_Group_Fun", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
                cmd.Parameters.AddWithValue("@UserGroup_Name", UserGroup_Name);
                cmd.Parameters.AddWithValue("@FunctionID", FunctionID);
                cmd.Parameters.AddWithValue("@Parent", Parent);
                cmd.Parameters.AddWithValue("@EnteredBy", ENTEREDBY);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }
        public void FrmUserGroup(string Action = null, string Project_Name = null, string UserGroup_Name = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Add_Up_Del_User_Group_Fun", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Frm_User_Group");
                cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
                cmd.Parameters.AddWithValue("@UserGroup_Name", UserGroup_Name);
                cmd.Parameters.AddWithValue("@EnteredBy", ENTEREDBY);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }
        public void AddUserGroups(string Action = null, string Project_Name = null, string UserGroup_Name = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Add_Upd_UserGroups", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
                cmd.Parameters.AddWithValue("@UserGroup_Name", UserGroup_Name);
                cmd.Parameters.AddWithValue("@EnteredBy", ENTEREDBY);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }
        public DataSet GetSiteID(string Action = null, string Project_Name = null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                cmd = new SqlCommand("Get_Site_ID_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ////ds.Dispose();
            }
            return ds;
        }
        public DataSet AddUserProfile(string Action = null, string Project_Name = null, string USerGroup_Name = null, string User_Name = null, string Site_ID = null, string INVNAME = null, string Email = null, string User_Dis_Name = null, string ENTEREDBY = null, string USERID = null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                cmd = new SqlCommand("Add_User_Profile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action",Action);
                cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
                cmd.Parameters.AddWithValue("@USerGroup_Name", USerGroup_Name);
                cmd.Parameters.AddWithValue("@User_Name", User_Name);
                cmd.Parameters.AddWithValue("@Site_ID", Site_ID);
                cmd.Parameters.AddWithValue("@INVNAME", INVNAME);
                cmd.Parameters.AddWithValue("@EnteredBy", ENTEREDBY);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@User_Dis_Name", User_Dis_Name);
                cmd.Parameters.AddWithValue("@USERID", USERID);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
            return ds;
        }
        public DataSet GetUserID(string Action = null, string Project_Name = null, string UserGroup_Name = null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                cmd = new SqlCommand("Get_User_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
                cmd.Parameters.AddWithValue("@UserGroup_Name", UserGroup_Name);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ////ds.Dispose();
            }
            return ds;
        }
        public void AddUserFun(string Action = null, string Project_Name = null, string USerGroup_Name = null, string User_Name = null, string Fn_ID = null, string Parent = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Add_Up_Del_User_Fun", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
                cmd.Parameters.AddWithValue("@USerGroup_Name", USerGroup_Name);
                cmd.Parameters.AddWithValue("@User_Name", User_Name);
                cmd.Parameters.AddWithValue("@FunctionID", Fn_ID);
                cmd.Parameters.AddWithValue("@EnteredBy", ENTEREDBY);
                cmd.Parameters.AddWithValue("@Parent", Parent);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }

        #region Library Datalayer start

        //GET SET DEMOGRAPHICS
        public DataSet GetSetDM(string Action = null, string PVID = null, string BRTHDAT = null, string AGE = null, string AGEU = null, string DMDAT = null, string SEX = null, string ETHNIC = null, string RACE = null, string RACEOTH = null, string ENTEREDBY = null, string SUBJINII = null, string ICSUBSCR = null, string ICSCRID = null, string DMMENOYN = null, string DMMENOPDAT = null, string DMFSHVAL = null, string DMFSHRAN = null, string DMFSHYN = null, string DMMENONON = null, bool CONTRAVAS = false, bool CONTRAABST = false, bool CONTRAIUD = false, bool CONTRAORAL = false, bool CONTRATRAD = false, bool CONTRAINJ = false, bool CONTRAIMP = false, bool CONTRADPM = false, bool CONTRACERCAP = false, bool CONTRASPERM = false, string DMMENOPROPERN = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSDM_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);

                if (BRTHDAT != "") { cmd.Parameters.AddWithValue("@BRTHDAT", BRTHDAT); }
                if (AGE != "") { cmd.Parameters.AddWithValue("@AGE", AGE); }
                if (AGEU != "") { cmd.Parameters.AddWithValue("@AGEU", AGEU); }
                if (DMDAT != "") { cmd.Parameters.AddWithValue("@DMDAT", DMDAT); }
                if (SEX != "0") { cmd.Parameters.AddWithValue("@SEX", SEX); }
                if (ETHNIC != "0") { cmd.Parameters.AddWithValue("@ETHNIC", ETHNIC); }
                if (RACE != "0") { cmd.Parameters.AddWithValue("@RACE", RACE); }
                if (RACEOTH != "") { cmd.Parameters.AddWithValue("@RACEOTH", RACEOTH); }

                if (SUBJINII != "") { cmd.Parameters.AddWithValue("@SUBJINII", SUBJINII); }
                if (ICSUBSCR != "0") { cmd.Parameters.AddWithValue("@ICSUBSCR", ICSUBSCR); }
                if (ICSCRID != "") { cmd.Parameters.AddWithValue("@ICSCRID", ICSCRID); }
                if (DMMENOYN != "0") { cmd.Parameters.AddWithValue("@DMMENOYN", DMMENOYN); }
                if (DMMENOPDAT != "") { cmd.Parameters.AddWithValue("@DMMENOPDAT", DMMENOPDAT); }
                if (DMFSHVAL != "") { cmd.Parameters.AddWithValue("@DMFSHVAL", DMFSHVAL); }
                if (DMFSHRAN != "") { cmd.Parameters.AddWithValue("@DMFSHRAN", DMFSHRAN); }
                if (DMFSHYN != "0") { cmd.Parameters.AddWithValue("@DMFSHYN", DMFSHYN); }
                if (DMMENONON != "0") { cmd.Parameters.AddWithValue("@DMMENONON", DMMENONON); }
                if (CONTRAVAS != false) { cmd.Parameters.AddWithValue("@CONTRAVAS", CONTRAVAS); }
                if (CONTRAABST != false) { cmd.Parameters.AddWithValue("@CONTRAABST", CONTRAABST); }
                if (CONTRAIUD != false) { cmd.Parameters.AddWithValue("@CONTRAIUD", CONTRAIUD); }
                if (CONTRAORAL != false) { cmd.Parameters.AddWithValue("@CONTRAORAL", CONTRAORAL); }
                if (CONTRATRAD != false) { cmd.Parameters.AddWithValue("@CONTRATRAD", CONTRATRAD); }
                if (CONTRAINJ != false) { cmd.Parameters.AddWithValue("@CONTRAINJ", CONTRAINJ); }
                if (CONTRAIMP != false) { cmd.Parameters.AddWithValue("@CONTRAIMP", CONTRAIMP); }
                if (CONTRADPM != false) { cmd.Parameters.AddWithValue("@CONTRADPM", CONTRADPM); }
                if (CONTRACERCAP != false) { cmd.Parameters.AddWithValue("@CONTRACERCAP", CONTRACERCAP); }
                if (CONTRASPERM != false) { cmd.Parameters.AddWithValue("@CONTRASPERM", CONTRASPERM); }
                if (DMMENOPROPERN != "") { cmd.Parameters.AddWithValue("@DMMENOPROPERN", DMMENOPROPERN); }

                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        //GET SET DEMOGRAPHICS
        public DataSet GetSetDM1(string Action = null, string PVID = null, string BRTHDAT = null, string AGE = null, string AGEU = null, string DMDAT = null, string SEX = null, string ETHNIC = null, string RACE = null, string RACEOTH = null, string ENTEREDBY = null, string SUBJINII = null, string ICSUBSCR = null, int ICSCRID = -1, string DMMENOYN = null, string DMMENOPDAT = null, string DMFSHVAL = null, string DMFSHRAN = null, string DMFSHYN = null, string DMMENONON = null, bool CONTRAVAS = false, bool CONTRAABST = false, bool CONTRAIUD = false, bool CONTRAORAL = false, bool CONTRATRAD = false, bool CONTRAINJ = false, bool CONTRAIMP = false, bool CONTRADPM = false, bool CONTRACERCAP = false, bool CONTRASPERM = false, string DMMENOPROPERN = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSDM1_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);

                if (CONTRAVAS != false) { cmd.Parameters.AddWithValue("@CONTRAVAS", CONTRAVAS); }
                if (CONTRAABST != false) { cmd.Parameters.AddWithValue("@CONTRAABST", CONTRAABST); }
                if (CONTRAIUD != false) { cmd.Parameters.AddWithValue("@CONTRAIUD", CONTRAIUD); }
                if (CONTRAORAL != false) { cmd.Parameters.AddWithValue("@CONTRAORAL", CONTRAORAL); }
                if (CONTRATRAD != false) { cmd.Parameters.AddWithValue("@CONTRATRAD", CONTRATRAD); }
                if (CONTRAINJ != false) { cmd.Parameters.AddWithValue("@CONTRAINJ", CONTRAINJ); }
                if (CONTRAIMP != false) { cmd.Parameters.AddWithValue("@CONTRAIMP", CONTRAIMP); }
                if (CONTRADPM != false) { cmd.Parameters.AddWithValue("@CONTRADPM", CONTRADPM); }
                if (CONTRACERCAP != false) { cmd.Parameters.AddWithValue("@CONTRACERCAP", CONTRACERCAP); }
                if (CONTRASPERM != false) { cmd.Parameters.AddWithValue("@CONTRASPERM", CONTRASPERM); }
                if (DMMENOPROPERN != "") { cmd.Parameters.AddWithValue("@DMMENOPROPERN", DMMENOPROPERN); }

                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        //GET SET Master Structure
        public DataSet GetSetMaster(string Action = null, string TABLENAME = null, string VISNUM = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["eCRFConnection"].ConnectionString);
            try
            {
                cmd = new SqlCommand("MASTER_DATA_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@TABLENAME", TABLENAME);
                cmd.Parameters.AddWithValue("@VISNUM", VISNUM);
             
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }
        //GET Dropdown data
        public DataSet GetDropDownData(string Action = null, string VariableName = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["eCRFConnection"].ConnectionString);
            try
            {
                cmd = new SqlCommand("FillDropDown_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@VariableName", VariableName);


                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        //GET SET Master Structure
        public DataSet GetSetProjectData(string Action = null, string PVID = null,
           int ContID = 0, string VARIABLENAME = null, string FIELDNAME = null,
               string TABLENAME = null, string CONTROLTYPE = null, string CLASS = null,
            string DATATYPE = null, string DATA = null, string RECID=null, int CONTYN = 0, string ENTEREDBY = null,
            string UPDATEDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
           
            try
            {
                cmd = new SqlCommand("PROJECT_DATA_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@ContID", ContID);
                cmd.Parameters.AddWithValue("@RecID", RECID);
                cmd.Parameters.AddWithValue("@VARIABLENAME", VARIABLENAME);
                cmd.Parameters.AddWithValue("@FIELDNAME", FIELDNAME);
                cmd.Parameters.AddWithValue("@TABLENAME", TABLENAME);
                cmd.Parameters.AddWithValue("@CONTROLTYPE", CONTROLTYPE);
                cmd.Parameters.AddWithValue("@CLASS", CLASS);
                cmd.Parameters.AddWithValue("@DATATYPE", DATATYPE);

                if (CONTROLTYPE == "DROPDOWN")
                {
                    if (DATA != "0")
                    {
                        cmd.Parameters.AddWithValue("@DATA", DATA);
                    }
                }
                else
                {
                    if (DATA != "")
                    {
                        cmd.Parameters.AddWithValue("@DATA", DATA);
                    }
                }
               
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                cmd.Parameters.AddWithValue("@UPDATEDBY", UPDATEDBY);
                cmd.Parameters.AddWithValue("@CONTYN", CONTYN);             

                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }
        //GET SET VISIT DATE
        public DataSet GetSetVIS(string Action = null, string PVID = null, int ContID = -1, string VISDAT = null, bool VISND = false, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSVISDAT_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);

                if (VISDAT != "") { cmd.Parameters.AddWithValue("@VISDAT", VISDAT); }
                if (VISND != false) { cmd.Parameters.AddWithValue("@VISND", VISND); }

                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        //GET SET VITAL SIGNS
        public DataSet GetSetVS(string Action = null, string PVID = null, int ContID = -1, string VSTPT = null, string VSTEST = null,string VSOOR =null, string VSORRES = null, string VSORRESU = null, string VSCLSIG = null, string VSSPID = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSVS_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@ContID", ContID);

                if (VSTPT != "") { cmd.Parameters.AddWithValue("@VSTPT", VSTPT); }
                if (VSTEST != "") { cmd.Parameters.AddWithValue("@VSTEST", VSTEST); }
                if (VSORRES != "") { cmd.Parameters.AddWithValue("@VSORRES", VSORRES); }
                if (VSORRESU != "") { cmd.Parameters.AddWithValue("@VSORRESU", VSORRESU); }
                if (VSCLSIG != "0") { cmd.Parameters.AddWithValue("@VSCLSIG", VSCLSIG); }
                if (VSSPID != "") { cmd.Parameters.AddWithValue("@VSSPID", VSSPID); }
                if (VSOOR != "0") { cmd.Parameters.AddWithValue("@VSOOR", VSOOR); }

                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        //GET SET VITAL SIGNS - Perform
        public DataSet GetSetVSPER(string Action = null, string PVID = null, int ContID = -1, string VSPERF = null, string VSDAT = null, string VSREASND = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSVSPER_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@ContID", ContID);

                if (VSPERF != "") { cmd.Parameters.AddWithValue("@VSPERF", VSPERF); }
                if (VSDAT != "") { cmd.Parameters.AddWithValue("@VSDAT", VSDAT); }
                if (VSREASND != "") { cmd.Parameters.AddWithValue("@VSREASND", VSREASND); }

                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

   

        //GET SET INFORMED CONSENT
        public DataSet GetSetINFORM(string Action = null, string PVID = null, int ContID = -1, string ICSDAT = null, string ICSTIM = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSINFCONS_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);

                if (ICSDAT != "") { cmd.Parameters.AddWithValue("@ICSDAT", ICSDAT); }
                if (ICSTIM != "") { cmd.Parameters.AddWithValue("@ICSTIM", ICSTIM); }

                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        //GET SET PV
        public void GetSetPV(string PVID = null, string INVID = null, string SUBJID = null, string VISITNUM = null, string PAGENUM = null, string PAGESTATUS = null, string ENTEREDBY = null, string SUBJINI = null)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("PV_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@INVID", INVID);
                cmd.Parameters.AddWithValue("@SUBJID", SUBJID);
                cmd.Parameters.AddWithValue("@VISITNUM", VISITNUM);
                cmd.Parameters.AddWithValue("@PAGENUM", PAGENUM);
                cmd.Parameters.AddWithValue("@PAGESTATUS", PAGESTATUS);
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                cmd.Parameters.AddWithValue("@SUBJINI", SUBJINI);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }


        //GET SET MEDICAL HISTORY
        public DataSet GetSetMH(string Action = null, string PVID = null, int ContID = -1, string MHSPID = null, string MHCAT = null, string MHSCAT = null, string MHTERM = null, string MHSTDAT = null, string MHSTUDAT = null, string MHENDAT = null, string MHENUDAT = null, string MHDUR = null, string MHHOSP = null, string MHACNOTH = null, string MHCMYN = null, string MHONGO = null, string MHCTRL = null, string MHOCCUR = null, string MHDAT = null, string MHCOM = null, string ENTEREDBY = null, string MHTRTYN = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSMH_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@ContID", ContID);
                if (PVID != "")
                {
                    if (MHSPID != "") { cmd.Parameters.AddWithValue("@MHSPID", MHSPID); }
                    if (MHCAT != "") { cmd.Parameters.AddWithValue("@MHCAT", MHCAT); }
                    if (MHTERM != "") { cmd.Parameters.AddWithValue("@MHTERM", MHTERM); }
                    if (MHSCAT != "") { cmd.Parameters.AddWithValue("@MHSCAT", MHSCAT); }
                    if (MHSTDAT != "") { cmd.Parameters.AddWithValue("@MHSTDAT", MHSTDAT); }
                    if (MHSTUDAT != "") { cmd.Parameters.AddWithValue("@MHSTUDAT", MHSTUDAT); }
                    if (MHENDAT != "") { cmd.Parameters.AddWithValue("@MHENDAT", MHENDAT); }
                    if (MHENUDAT != "") { cmd.Parameters.AddWithValue("@MHENUDAT", MHENUDAT); }
                    if (MHDUR != "") { cmd.Parameters.AddWithValue("@MHDUR", MHDUR); }
                    if (MHCMYN != "") { cmd.Parameters.AddWithValue("@MHCMYN", MHCMYN); }
                    if (MHONGO != "0") { cmd.Parameters.AddWithValue("@MHONGO", MHONGO); }
                    if (MHHOSP != "0") { cmd.Parameters.AddWithValue("@MHHOSP", MHHOSP); }
                    if (MHACNOTH != "0") { cmd.Parameters.AddWithValue("@MHACNOTH", MHACNOTH); }
                    if (MHCTRL != "") { cmd.Parameters.AddWithValue("@MHCTRL", MHCTRL); }
                    if (MHOCCUR != "") { cmd.Parameters.AddWithValue("@MHOCCUR", MHOCCUR); }
                    if (MHDAT != "") { cmd.Parameters.AddWithValue("@MHDAT", MHDAT); }
                    if (MHCOM != "") { cmd.Parameters.AddWithValue("@MHCOM", MHCOM); }
                    if (MHTRTYN != "0") { cmd.Parameters.AddWithValue("@MHTRTYN", MHTRTYN); }
                    if (ENTEREDBY != "") { cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY); }
                    con.Open();
                    adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);
                    cmd.Dispose();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        // ADD NEW ROW TO MEDICAL HISTORY
        public DataTable AddNewRowToGridMH(GridView Grd)
        {
            //Table Structure
            DataRow drCurrentRow = null;
            DataTable dtCurrentTable;
            int rowIndex = 0;
            int i;
            dtCurrentTable = new DataTable();
            dtCurrentTable.Columns.Add(new DataColumn("ContID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHSPID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHSCAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHTERM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHSTDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHSTUDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHENDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHENUDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHDUR", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHONGO", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHCOM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHHOSP", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHACNOTH", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("MHTRTYN", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("UPDATE_FLAG", typeof(string)));

            if (Grd.Rows.Count > 0)
            {
                for (i = 0; i < Grd.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["ContID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("ContID")).Text;
                    drCurrentRow["MHSPID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("MHSPID")).Text;
                    drCurrentRow["MHSCAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("MHSCAT")).Text;
                    drCurrentRow["MHTERM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("MHTERM")).Text;
                    drCurrentRow["MHSTDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("MHSTDAT")).Text;
                    drCurrentRow["MHSTUDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("MHSTUDAT")).Text;
                    drCurrentRow["MHENDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("MHENDAT")).Text;
                    drCurrentRow["MHENUDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("MHENUDAT")).Text;
                    drCurrentRow["MHDUR"] = ((TextBox)Grd.Rows[rowIndex].FindControl("MHDUR")).Text;
                    drCurrentRow["MHONGO"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("MHONGO")).SelectedValue;
                    drCurrentRow["MHHOSP"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("MHHOSP")).SelectedValue;
                    drCurrentRow["MHACNOTH"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("MHACNOTH")).SelectedValue;
                    drCurrentRow["MHTRTYN"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("MHTRTYN")).SelectedValue;
                    drCurrentRow["MHCOM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("MHCOM")).Text;
                    drCurrentRow["UPDATE_FLAG"] = ((TextBox)Grd.Rows[rowIndex].FindControl("UPDATE_FLAG")).Text;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    rowIndex++;
                }
                if (drCurrentRow["MHSPID"] == "" && drCurrentRow["MHSCAT"] == "" && drCurrentRow["MHTERM"] == "" && drCurrentRow["MHSTDAT"] == "" && drCurrentRow["MHSTUDAT"] == "" && drCurrentRow["MHENDAT"] == "" && drCurrentRow["MHENUDAT"] == "" && drCurrentRow["MHDUR"] == "" && drCurrentRow["MHCOM"] == "" && drCurrentRow["MHONGO"].ToString() == "0" && drCurrentRow["MHHOSP"].ToString() == "0" && drCurrentRow["MHACNOTH"].ToString() == "0"
                    && drCurrentRow["MHTRTYN"].ToString() == "0")
                {

                }
                else
                {
                    //Add Empty Row
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["ContID"] = rowIndex.ToString();
                    drCurrentRow["MHSPID"] = "";
                    drCurrentRow["MHSCAT"] = string.Empty;
                    drCurrentRow["MHTERM"] = string.Empty;
                    drCurrentRow["MHSTDAT"] = string.Empty;
                    drCurrentRow["MHSTUDAT"] = string.Empty;
                    drCurrentRow["MHENDAT"] = string.Empty;
                    drCurrentRow["MHENUDAT"] = string.Empty;
                    drCurrentRow["MHDUR"] = string.Empty;
                    drCurrentRow["MHONGO"] = "0";
                    drCurrentRow["MHHOSP"] = "0";
                    drCurrentRow["MHACNOTH"] = "0";
                    drCurrentRow["MHCOM"] = string.Empty;
                    drCurrentRow["MHTRTYN"] = "0";
                    drCurrentRow["UPDATE_FLAG"] = "0";
                    dtCurrentTable.Rows.Add(drCurrentRow);
                }
            }
            return dtCurrentTable;
        }

        //GET SET MEDICATION
        public DataSet GetSetCM(string Action = null, string PVID = null, int ContID = -1, string CMTRT = null, string CMDSTXT = null, string CMDOSU = null, string CMDOSUOTH = null, string CMDOSFRQ = null, string CMROUTE = null, string CMSTDAT = null, string CMSTUDAT = null, string CMSTTIM = null, string CMENDAT = null, string CMENUDAT = null, string CMENTIM = null, string CMONGO = null, string CMINDC1 = null, string CMINDC2 = null, string CMINDC3 = null, string CMINDC4 = null, string ENTEREDBY = null, string CMDOSFRM = null, string CMDOSFRMSPE = null, string CMINGRD = null, string CMPRETRT = null, string CMROUTEOTH = null, string CMDOSFRQOTH = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSCM_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@ContID", ContID);

                if (CMTRT != "") { cmd.Parameters.AddWithValue("@CMTRT", CMTRT); }
                if (CMDSTXT != "") { cmd.Parameters.AddWithValue("@CMDSTXT", CMDSTXT); }
                if (CMDOSU != "") { cmd.Parameters.AddWithValue("@CMDOSU", CMDOSU); }
                if (CMDOSUOTH != "") { cmd.Parameters.AddWithValue("@CMDOSUOTH", CMDOSUOTH); }
                if (CMDOSFRQ != "") { cmd.Parameters.AddWithValue("@CMDOSFRQ", CMDOSFRQ); }
                if (CMROUTE != "") { cmd.Parameters.AddWithValue("@CMROUTE", CMROUTE); }
                if (CMSTDAT != "") { cmd.Parameters.AddWithValue("@CMSTDAT", CMSTDAT); }
                if (CMSTUDAT != "") { cmd.Parameters.AddWithValue("@CMSTUDAT", CMSTUDAT); }
                if (CMSTTIM != "") { cmd.Parameters.AddWithValue("@CMSTTIM", CMSTTIM); }
                if (CMENDAT != "") { cmd.Parameters.AddWithValue("@CMENDAT", CMENDAT); }
                if (CMENUDAT != "") { cmd.Parameters.AddWithValue("@CMENUDAT", CMENUDAT); }
                if (CMENTIM != "") { cmd.Parameters.AddWithValue("@CMENTIM", CMENTIM); }
                if (CMONGO != "0") { cmd.Parameters.AddWithValue("@CMONGO", CMONGO); }
                if (CMINDC1 != "") { cmd.Parameters.AddWithValue("@CMINDC1", CMINDC1); }
                if (CMINDC2 != "") { cmd.Parameters.AddWithValue("@CMINDC2", CMINDC2); }
                if (CMINDC3 != "") { cmd.Parameters.AddWithValue("@CMINDC3", CMINDC3); }
                if (CMINDC4 != "") { cmd.Parameters.AddWithValue("@CMINDC4", CMINDC4); }


                if (CMDOSFRM != "0") { cmd.Parameters.AddWithValue("@CMDOSFRM", CMDOSFRM); }
                if (CMDOSFRMSPE != "") { cmd.Parameters.AddWithValue("@CMDOSFRMSPE", CMDOSFRMSPE); }
                if (CMINGRD != "") { cmd.Parameters.AddWithValue("@CMINGRD", CMINGRD); }
                if (CMPRETRT != "0") { cmd.Parameters.AddWithValue("@CMPRETRT", CMPRETRT); }
                if (CMROUTEOTH != "") { cmd.Parameters.AddWithValue("@CMROUTEOTH", CMROUTEOTH); }
                if (CMDOSFRQOTH != "") { cmd.Parameters.AddWithValue("@CMDOSFRQOTH", CMDOSFRQOTH); }


                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        //ADD NEW ROW TO MEDICATION
        public DataTable AddNewRowToGridCM(GridView Grd)
        {
            //Table Structure
            DataRow drCurrentRow = null;
            DataTable dtCurrentTable;
            int rowIndex = 0;
            int i;
            dtCurrentTable = new DataTable();
            dtCurrentTable.Columns.Add(new DataColumn("CONTID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMSPID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMTRT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMDSTXT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMDOSU", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMDOSUOTH", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMDOSFRQ", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMROUTE", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMSTDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMSTUDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMSTTIM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMENDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMENUDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMENTIM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMONGO", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMINDC1", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMINDC2", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMINDC3", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMINDC4", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("UPDATE_FLAG", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMROUTEOTH", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMDOSFRM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMDOSFRMSPE", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMINGRD", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMPRETRT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CMDOSFRQOTH", typeof(string)));

            if (Grd.Rows.Count > 0)
            {
                for (i = 0; i < Grd.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["CONTID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CONTID")).Text;
                    drCurrentRow["CMSPID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMSPID")).Text;
                    drCurrentRow["CMTRT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMTRT")).Text;
                    drCurrentRow["CMDSTXT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMDSTXT")).Text;
                    drCurrentRow["CMDOSU"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMDOSU")).Text;
                    drCurrentRow["CMDOSUOTH"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMDOSUOTH")).Text;
                    drCurrentRow["CMDOSFRQ"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMDOSFRQ")).Text;
                    drCurrentRow["CMROUTE"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("CMROUTE")).SelectedValue; ;
                    drCurrentRow["CMSTDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMSTDAT")).Text;
                    drCurrentRow["CMSTUDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMSTUDAT")).Text;
                    drCurrentRow["CMSTTIM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMSTTIM")).Text;
                    drCurrentRow["CMENDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMENDAT")).Text;
                    drCurrentRow["CMENUDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMENUDAT")).Text;
                    drCurrentRow["CMENTIM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMENTIM")).Text;
                    drCurrentRow["CMONGO"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("CMONGO")).SelectedValue;
                    drCurrentRow["CMINDC1"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMINDC1")).Text;
                    drCurrentRow["CMINDC2"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMINDC2")).Text;
                    drCurrentRow["CMINDC3"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMINDC3")).Text;
                    drCurrentRow["CMINDC4"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMINDC4")).Text;
                    drCurrentRow["UPDATE_FLAG"] = ((TextBox)Grd.Rows[rowIndex].FindControl("UPDATE_FLAG")).Text;
                    drCurrentRow["CMDOSFRM"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("CMDOSFRM")).SelectedValue;
                    drCurrentRow["CMROUTEOTH"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMROUTEOTH")).Text;
                    drCurrentRow["CMDOSFRMSPE"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMDOSFRMSPE")).Text;
                    drCurrentRow["CMINGRD"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMINGRD")).Text;
                    drCurrentRow["CMPRETRT"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("CMPRETRT")).SelectedValue;
                    drCurrentRow["CMDOSFRQOTH"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CMDOSFRQOTH")).Text;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    rowIndex++;
                }
                if (drCurrentRow["CMTRT"] == "" && drCurrentRow["CMDSTXT"] == "" && drCurrentRow["CMDOSU"] == "" && drCurrentRow["CMDOSFRQ"] == "" && drCurrentRow["CMROUTE"].ToString() == "0" && drCurrentRow["CMSTDAT"] == "" && drCurrentRow["CMSTUDAT"] == "" && drCurrentRow["CMSTTIM"] == "" && drCurrentRow["CMENDAT"] == "" && drCurrentRow["CMENUDAT"] == "" && drCurrentRow["CMONGO"].ToString() == "0" && drCurrentRow["CMENTIM"] == "" && drCurrentRow["CMINDC1"] == "" && drCurrentRow["CMINDC2"] == "" && drCurrentRow["CMINDC3"] == "" && drCurrentRow["CMINDC4"] == ""
                    && drCurrentRow["CMDOSFRQOTH"] == "" && drCurrentRow["CMDOSFRM"].ToString() == "0" && drCurrentRow["CMPRETRT"].ToString() == "0" && drCurrentRow["CMINGRD"] == "" && drCurrentRow["CMDOSFRMSPE"] == "")
                { //nothing happen when already blank row exists
                }
                else
                {
                    //Add Empty Row
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["CONTID"] = rowIndex.ToString();
                    drCurrentRow["CMSPID"] = rowIndex.ToString();
                    drCurrentRow["CMTRT"] = String.Empty;
                    drCurrentRow["CMDSTXT"] = String.Empty;
                    drCurrentRow["CMDOSU"] = String.Empty;
                    drCurrentRow["CMDOSUOTH"] = String.Empty;
                    drCurrentRow["CMDOSFRQ"] = String.Empty;
                    drCurrentRow["CMROUTE"] = "0";
                    drCurrentRow["CMSTDAT"] = String.Empty;
                    drCurrentRow["CMSTUDAT"] = String.Empty;
                    drCurrentRow["CMSTTIM"] = String.Empty;
                    drCurrentRow["CMENDAT"] = String.Empty;
                    drCurrentRow["CMENUDAT"] = String.Empty;
                    drCurrentRow["CMENTIM"] = String.Empty;
                    drCurrentRow["CMONGO"] = "0";
                    drCurrentRow["CMINDC1"] = String.Empty;
                    drCurrentRow["CMINDC2"] = String.Empty;
                    drCurrentRow["CMINDC3"] = String.Empty;
                    drCurrentRow["CMINDC4"] = String.Empty;
                    drCurrentRow["CMDOSFRM"] = "0";
                    drCurrentRow["CMROUTEOTH"] = String.Empty;
                    drCurrentRow["CMDOSFRMSPE"] = String.Empty;
                    drCurrentRow["CMINGRD"] = String.Empty;
                    drCurrentRow["CMPRETRT"] = "0";
                    drCurrentRow["CMDOSFRQOTH"] = String.Empty;
                    drCurrentRow["UPDATE_FLAG"] = "0";
                    dtCurrentTable.Rows.Add(drCurrentRow);
                }
            }
            return dtCurrentTable;
        }

        //GET SET SUBJECT ELIGIBILITY IC
        public DataSet GetSetIC(string Action = null, string PVID = null, int ContID = -1, int ICSPID = -1, string IECAT = null, string IETEST = null, string IEYN = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSIC_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@ContID", ContID);
                cmd.Parameters.AddWithValue("@ICSPID", ICSPID);
                cmd.Parameters.AddWithValue("@IETEST", IETEST);
                cmd.Parameters.AddWithValue("@IEYN", IEYN);
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        //GET SET SUBJECT ELIGIBILITY EC
        public DataSet GetSetEC(string Action = null, string PVID = null, int ContID = -1, int ICSPID = -1, string IECAT = null, string IETEST = null, string IEEYN = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSEC_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@ContID", ContID);
                cmd.Parameters.AddWithValue("@ICSPID", ICSPID);
                cmd.Parameters.AddWithValue("@IETEST", IETEST);
                cmd.Parameters.AddWithValue("@IEEYN", IEEYN);
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        //GET SET PHYSICAL EXAMINATION
        public DataSet GetSetPE(string Action = null, string PVID = null, int ContID = -1, string PECAT = null, string PETEST = null, string PERES = null, string PEDESC = null, string PECLISIG = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSPE_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@ContID", ContID);

                if (PECAT != "") { cmd.Parameters.AddWithValue("@PECAT", PECAT); }
                if (PETEST != "") { cmd.Parameters.AddWithValue("@PETEST", PETEST); }
                if (PERES != "") { cmd.Parameters.AddWithValue("@PERES", PERES); }
                if (PEDESC != "") { cmd.Parameters.AddWithValue("@PEDESC", PEDESC); }
                if (PECLISIG != "0") { cmd.Parameters.AddWithValue("@PECLISIG", PECLISIG); }

                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        //GET SET ADVERSE EVENT
        public DataSet GetSetAE(string Action = null, string PVID = null, int ContID = 0, string AESPID = null, string AETERM = null, int AESEVCOD = -1, string AESEV = null, string AEOBSPV = null, string AESTDAT = null, string AESTUDAT = null, string AEENDAT = null, string AEENUDAT = null, string AESTTIM = null, string AESTUTIM = null, string AEENTIM = null, string AEENUTIM = null, int AEOUTCOD = -1, string AEOUT = null, int AERELCOD = -1, string AEREL = null, string AEACN = null, string AEACNCOD = null, string AESER = null, bool AESDTH = false, bool AESLIFE = false, bool AESDISAB = false, bool AESHOSP = false, bool AESCONG = false, bool AESMIE = false, string AESAECODN = null, string AESAECODC = null, string ENTEREDBY = null, string AEOUTSEQUELAE = null, string AEACNOTH = null, string AEOTHACTPHY = null, string AEACNOTHSPE = null, string AECAUSE = null, string AECAUSEOTH = null, string AESPIDSAE = null, string AETOXGR = null, string AEDUR = null, string AEDURU = null, string AEINFURN = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSAE_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@ContID", ContID);

                if (AESPID != "") { cmd.Parameters.AddWithValue("@AESPID", AESPID); }
                if (AETERM != "") { cmd.Parameters.AddWithValue("@AETERM", AETERM); }
                if (AESEVCOD != -1) { cmd.Parameters.AddWithValue("@AESEVCOD", AESEVCOD); }
                if (AESEV != "") { cmd.Parameters.AddWithValue("@AESEV", AESEV); }
                if (AEOBSPV != "0") { cmd.Parameters.AddWithValue("@AEOBSPV", AEOBSPV); }
                if (AESTDAT != "") { cmd.Parameters.AddWithValue("@AESTDAT", AESTDAT); }
                if (AESTUDAT != "") { cmd.Parameters.AddWithValue("@AESTUDAT", AESTUDAT); }
                if (AEENDAT != "") { cmd.Parameters.AddWithValue("@AEENDAT", AEENDAT); }
                if (AEENUDAT != "") { cmd.Parameters.AddWithValue("@AEENUDAT", AEENUDAT); }

                if (AESTTIM != "") { cmd.Parameters.AddWithValue("@AESTTIM", AESTTIM); }
                if (AESTUTIM != "") { cmd.Parameters.AddWithValue("@AESTUTIM", AESTUTIM); }
                if (AEENTIM != "") { cmd.Parameters.AddWithValue("@AEENTIM", AEENTIM); }
                if (AEENUTIM != "") { cmd.Parameters.AddWithValue("@AEENUTIM", AEENUTIM); }


                if (AEOUTCOD != -1) { cmd.Parameters.AddWithValue("@AEOUTCOD", AEOUTCOD); }
                if (AEOUT != "") { cmd.Parameters.AddWithValue("@AEOUT", AEOUT); }
                if (AERELCOD != -1) { cmd.Parameters.AddWithValue("@AERELCOD", AERELCOD); }
                if (AEREL != "0") { cmd.Parameters.AddWithValue("@AEREL", AEREL); }
                if (AEACN != "0") { cmd.Parameters.AddWithValue("@AEACN", AEACN); }



                if (AEOUTSEQUELAE != null) { cmd.Parameters.AddWithValue("@AEOUTSEQUELAE", AEOUTSEQUELAE); }
                if (AEACNOTH != "0") { cmd.Parameters.AddWithValue("@AEACNOTH", AEACNOTH); }
                if (AEOTHACTPHY != null) { cmd.Parameters.AddWithValue("@AEOTHACTPHY", AEOTHACTPHY); }
                if (AEACNOTHSPE != null) { cmd.Parameters.AddWithValue("@AEACNOTHSPE", AEACNOTHSPE); }
                if (AECAUSE != "0") { cmd.Parameters.AddWithValue("@AECAUSE", AECAUSE); }
                if (AECAUSEOTH != null) { cmd.Parameters.AddWithValue("@AECAUSEOTH", AECAUSEOTH); }
                if (AESPIDSAE != null) { cmd.Parameters.AddWithValue("@AESPIDSAE", AESPIDSAE); }
                if (AETOXGR != "0") { cmd.Parameters.AddWithValue("@AETOXGR", AETOXGR); }
                if (AEDUR != null) { cmd.Parameters.AddWithValue("@AEDUR", AEDUR); }
                if (AEDURU != null) { cmd.Parameters.AddWithValue("@AEDURU", AEDURU); }
                if (AEINFURN != null) { cmd.Parameters.AddWithValue("@AEINFURN", AEINFURN); }






                cmd.Parameters.AddWithValue("@AEACNCOD", AEACNCOD);

                if (AESER != "0") { cmd.Parameters.AddWithValue("@AESER", AESER); }

                cmd.Parameters.AddWithValue("@AESDTH", AESDTH);
                cmd.Parameters.AddWithValue("@AESLIFE", AESLIFE);
                cmd.Parameters.AddWithValue("@AESDISAB", AESDISAB);
                cmd.Parameters.AddWithValue("@AESHOSP", AESHOSP);
                cmd.Parameters.AddWithValue("@AESCONG", AESCONG);
                cmd.Parameters.AddWithValue("@AESMIE", AESMIE);
                cmd.Parameters.AddWithValue("@AESAECODN", AESAECODN);
                cmd.Parameters.AddWithValue("@AESAECODC", AESAECODC);
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        //ADD BLANK ROW TO ADVERSE EVENT GRID
        public DataTable AddNewRowToGridAE(GridView Grd)
        {
            //Table Structure
            DataRow drCurrentRow = null;
            DataTable dtCurrentTable;
            int rowIndex = 0;
            int i;
            dtCurrentTable = new DataTable();
            dtCurrentTable.Columns.Add(new DataColumn("ContID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AESPID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AETERM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AESEV", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEOBSPV", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AESTDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AESTUDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEENDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEENUDAT", typeof(string)));


            dtCurrentTable.Columns.Add(new DataColumn("AESTTIM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AESTUTIM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEENTIM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEENUTIM", typeof(string)));

            dtCurrentTable.Columns.Add(new DataColumn("AEOUT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEREL", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEACN", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AESER", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AESDTH", typeof(bool)));
            dtCurrentTable.Columns.Add(new DataColumn("AESLIFE", typeof(bool)));
            dtCurrentTable.Columns.Add(new DataColumn("AESDISAB", typeof(bool)));
            dtCurrentTable.Columns.Add(new DataColumn("AESHOSP", typeof(bool)));
            dtCurrentTable.Columns.Add(new DataColumn("AESCONG", typeof(bool)));
            dtCurrentTable.Columns.Add(new DataColumn("AESMIE", typeof(bool)));
            dtCurrentTable.Columns.Add(new DataColumn("AESAECODN", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("UPDATE_FLAG", typeof(string)));

            dtCurrentTable.Columns.Add(new DataColumn("AEINFURN", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEDUR", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEDURU", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AECAUSEOTH", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AECAUSE", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEACNOTHSPE", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEOTHACTPHY", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEACNOTH", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AETOXGR", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AESPIDSAE", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("AEOUTSEQUELAE", typeof(string)));




            if (Grd.Rows.Count > 0)
            {
                for (i = 0; i < Grd.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["ContID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("ContID")).Text;
                    drCurrentRow["AESPID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AESPID")).Text;
                    drCurrentRow["AETERM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AETERM")).Text;
                    drCurrentRow["AESEV"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("AESEV")).SelectedValue;
                    drCurrentRow["AEOBSPV"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("AEOBSPV")).SelectedValue;
                    drCurrentRow["AESTDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AESTDAT")).Text;
                    drCurrentRow["AESTUDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AESTUDAT")).Text;

                    drCurrentRow["AESTTIM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AESTTIM")).Text;
                    drCurrentRow["AESTUTIM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AESTUTIM")).Text;
                    drCurrentRow["AEENTIM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AEENTIM")).Text;
                    drCurrentRow["AEENUTIM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AEENUTIM")).Text;

                    drCurrentRow["AEENDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AEENDAT")).Text;
                    drCurrentRow["AEENUDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AEENUDAT")).Text;
                    drCurrentRow["AEOUT"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("AEOUT")).SelectedValue;
                    drCurrentRow["AEREL"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("AEREL")).SelectedValue;
                    drCurrentRow["AEACN"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("AEACN")).SelectedValue;
                    drCurrentRow["AESER"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("AESER")).SelectedValue;
                    drCurrentRow["AESDTH"] = ((CheckBox)Grd.Rows[rowIndex].FindControl("AESDTH")).Checked;
                    drCurrentRow["AESLIFE"] = ((CheckBox)Grd.Rows[rowIndex].FindControl("AESLIFE")).Checked;
                    drCurrentRow["AESDISAB"] = ((CheckBox)Grd.Rows[rowIndex].FindControl("AESDISAB")).Checked;
                    drCurrentRow["AESHOSP"] = ((CheckBox)Grd.Rows[rowIndex].FindControl("AESHOSP")).Checked;
                    drCurrentRow["AESCONG"] = ((CheckBox)Grd.Rows[rowIndex].FindControl("AESCONG")).Checked;
                    drCurrentRow["AESMIE"] = ((CheckBox)Grd.Rows[rowIndex].FindControl("AESMIE")).Checked;
                    drCurrentRow["AESAECODN"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AESAECODN")).Text;
                    drCurrentRow["UPDATE_FLAG"] = ((TextBox)Grd.Rows[rowIndex].FindControl("UPDATE_FLAG")).Text;
                    drCurrentRow["AEDUR"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AEDUR")).Text;
                    drCurrentRow["AECAUSEOTH"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AECAUSEOTH")).Text;
                    drCurrentRow["AEACNOTHSPE"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AEACNOTHSPE")).Text;
                    drCurrentRow["AEOTHACTPHY"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AEOTHACTPHY")).Text;
                    drCurrentRow["AESPIDSAE"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AESPIDSAE")).Text;
                    drCurrentRow["AEOUTSEQUELAE"] = ((TextBox)Grd.Rows[rowIndex].FindControl("AEOUTSEQUELAE")).Text;
                    drCurrentRow["AEINFURN"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("AEINFURN")).SelectedValue;
                    drCurrentRow["AEDURU"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("AEDURU")).SelectedValue;
                    drCurrentRow["AECAUSE"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("AECAUSE")).SelectedValue;
                    drCurrentRow["AEACNOTH"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("AEACNOTH")).SelectedValue;
                    drCurrentRow["AETOXGR"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("AETOXGR")).SelectedValue;

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    rowIndex++;
                }
                if (drCurrentRow["AETERM"] == "" && drCurrentRow["AESEV"].ToString() == "0"
                    && drCurrentRow["AEOBSPV"].ToString() == "0" && drCurrentRow["AESTDAT"] == "" && drCurrentRow["AESTUDAT"] == ""
                    && drCurrentRow["AEENDAT"] == "" && drCurrentRow["AEENUDAT"] == "" && drCurrentRow["AEOUT"].ToString() == "0"
                    && drCurrentRow["AEREL"].ToString() == "0" && drCurrentRow["AESER"].ToString() == "0" &&
                    drCurrentRow["AEACN"].ToString() == "0" && drCurrentRow["AESDTH"].ToString() == "False" && drCurrentRow["AESLIFE"].ToString() == "False"
                    && drCurrentRow["AESDISAB"].ToString() == "False" && drCurrentRow["AESHOSP"].ToString() == "False"
                    && drCurrentRow["AESCONG"].ToString() == "False" && drCurrentRow["AESAECODN"] == ""
                     && drCurrentRow["AEDUR"] == "" && drCurrentRow["AECAUSEOTH"] == "" && drCurrentRow["AEACNOTHSPE"] == ""
                     && drCurrentRow["AEOTHACTPHY"] == "" && drCurrentRow["AESPIDSAE"] == "" && drCurrentRow["AEOUTSEQUELAE"] == ""
                     && drCurrentRow["AEINFURN"].ToString() == "0" && drCurrentRow["AEDURU"].ToString() == "0" && drCurrentRow["AECAUSE"].ToString() == "0"
                     && drCurrentRow["AEACNOTH"].ToString() == "0" && drCurrentRow["AETOXGR"].ToString() == "0"
                    && drCurrentRow["AESTTIM"] == "" && drCurrentRow["AESTUTIM"] == "" && drCurrentRow["AEENTIM"] == "" && drCurrentRow["AEENUTIM"] == ""

                    )
                {

                }
                else
                {
                    //Add Empty Row
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["ContID"] = rowIndex.ToString();
                    drCurrentRow["AESPID"] = string.Empty;
                    drCurrentRow["AETERM"] = string.Empty;
                    drCurrentRow["AESEV"] = "0";
                    drCurrentRow["AEOBSPV"] = "0";
                    drCurrentRow["AESTDAT"] = string.Empty;
                    drCurrentRow["AESTUDAT"] = string.Empty;
                    drCurrentRow["AEENDAT"] = string.Empty;
                    drCurrentRow["AEENUDAT"] = string.Empty;
                    drCurrentRow["AESTTIM"] = string.Empty;
                    drCurrentRow["AESTUTIM"] = string.Empty;
                    drCurrentRow["AEENTIM"] = string.Empty;
                    drCurrentRow["AEENUTIM"] = string.Empty;

                    drCurrentRow["AEOUT"] = "0";
                    drCurrentRow["AEREL"] = "0";
                    drCurrentRow["AEACN"] = "0";
                    drCurrentRow["AESER"] = "0";
                    drCurrentRow["AESDTH"] = false;
                    drCurrentRow["AESLIFE"] = false;
                    drCurrentRow["AESDISAB"] = false;
                    drCurrentRow["AESHOSP"] = false;
                    drCurrentRow["AESCONG"] = false;
                    drCurrentRow["AESMIE"] = false;
                    drCurrentRow["AESAECODN"] = string.Empty;
                    drCurrentRow["UPDATE_FLAG"] = "0";

                    drCurrentRow["AEDUR"] = string.Empty;
                    drCurrentRow["AECAUSEOTH"] = string.Empty;
                    drCurrentRow["AEACNOTHSPE"] = string.Empty;
                    drCurrentRow["AEOTHACTPHY"] = string.Empty;
                    drCurrentRow["AESPIDSAE"] = string.Empty;
                    drCurrentRow["AEOUTSEQUELAE"] = string.Empty;
                    drCurrentRow["AEINFURN"] = "0";
                    drCurrentRow["AEDURU"] = "0";
                    drCurrentRow["AECAUSE"] = "0";
                    drCurrentRow["AEACNOTH"] = "0";
                    drCurrentRow["AETOXGR"] = "0";

                    dtCurrentTable.Rows.Add(drCurrentRow);
                }
            }

            return dtCurrentTable;
        }

        //ADD NEW ROW TO VACCINATION GRID
        public DataTable AddNewRowToGridVAC(GridView Grd)
        {
            //Table Structure
            DataRow drCurrentRow = null;
            DataTable dtCurrentTable;
            int rowIndex = 0;
            int i;
            dtCurrentTable = new DataTable();
            dtCurrentTable.Columns.Add(new DataColumn("ContID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("VACSEQ", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("VACNAM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("VACDOS", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("VACLSTDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("VACLSTUKDAT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("VACSRC", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("UPDATE_FLAG", typeof(string)));

            if (Grd.Rows.Count > 0)
            {
                for (i = 0; i < Grd.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["ContID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("ContID")).Text;
                    drCurrentRow["VACSEQ"] = ((TextBox)Grd.Rows[rowIndex].FindControl("VACSEQ")).Text;
                    drCurrentRow["VACNAM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("VACNAM")).Text;
                    drCurrentRow["VACDOS"] = ((TextBox)Grd.Rows[rowIndex].FindControl("VACDOS")).Text;
                    drCurrentRow["VACLSTDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("VACLSTDAT")).Text;
                    drCurrentRow["VACLSTUKDAT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("VACLSTUKDAT")).Text;
                    drCurrentRow["VACSRC"] = ((DropDownList)Grd.Rows[rowIndex].FindControl("VACSRC")).SelectedValue;
                    drCurrentRow["UPDATE_FLAG"] = ((TextBox)Grd.Rows[rowIndex].FindControl("UPDATE_FLAG")).Text;

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    rowIndex++;
                }
                if (drCurrentRow["VACSEQ"] == "" && drCurrentRow["VACNAM"] == "" && drCurrentRow["VACDOS"] == "" && drCurrentRow["VACLSTDAT"] == "" && drCurrentRow["VACLSTUKDAT"] == "" && drCurrentRow["VACSRC"].ToString() == "0")
                { //nothing happen when already blank row exists
                }
                else
                {

                    //Add Empty Row
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["ContID"] = rowIndex.ToString();
                    drCurrentRow["VACSEQ"] = string.Empty;
                    drCurrentRow["VACNAM"] = string.Empty;
                    drCurrentRow["VACDOS"] = string.Empty;
                    drCurrentRow["VACLSTDAT"] = string.Empty;
                    drCurrentRow["VACLSTUKDAT"] = string.Empty;
                    drCurrentRow["VACSRC"] = "0";
                    drCurrentRow["UPDATE_FLAG"] = "0";
                    dtCurrentTable.Rows.Add(drCurrentRow);
                }
            }

            return dtCurrentTable;

        }

        //GET SET VACCINATION
        public DataSet GetSetVAC(string Action = null, string PVID = null, string ContID = null, string VACSEQ = null, string VACNAM = null, string VACDOS = null, string VACLSTDAT = null, string VACLSTUKDAT = null, string VACSRC = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("DSVAC_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@ContID", ContID);

                if (VACSEQ != "") { cmd.Parameters.AddWithValue("@VACSEQ", VACSEQ); }
                if (VACNAM != "") { cmd.Parameters.AddWithValue("@VACNAM", VACNAM); }
                if (VACDOS != "") { cmd.Parameters.AddWithValue("@VACDOS", VACDOS); }
                if (VACLSTDAT != "") { cmd.Parameters.AddWithValue("@VACLSTDAT", VACLSTDAT); }
                if (VACLSTUKDAT != "") { cmd.Parameters.AddWithValue("@VACLSTUKDAT", VACLSTUKDAT); }
                if (VACSRC != "0") { cmd.Parameters.AddWithValue("@VACSRC", VACSRC); }

                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }

        #endregion Library datalayer end

        #region Master Datalayer Start

        //GET SET VISIT DEATILS
        public DataSet GetSetVISITDETAILS(string Action = null, string STUDYID = null, int VISITNUM = -1, string VISIT = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("VISITDETAILS_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@STUDYID", STUDYID);

                if (VISITNUM != -1) { cmd.Parameters.AddWithValue("@VISITNUM", VISITNUM); }
                if (VISIT != "") { cmd.Parameters.AddWithValue("@VISIT", VISIT); }

                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }
        //GET SET SUBJECT DEATILS
        public DataSet GetSetSUBJECTDETAILS(string Action = null, int Project_ID = -1, string STUDYID = null, string INVID = null, string SUBJID = null, bool RECYN = false, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("SUBJDETAILS_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@STUDYID", STUDYID);
                cmd.Parameters.AddWithValue("@INVID", INVID);
                cmd.Parameters.AddWithValue("@SUBJID", SUBJID);
                cmd.Parameters.AddWithValue("@DELEGATEYN", RECYN);
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }
        //GET SET INV DEATILS
        public DataSet GetSetINVDETAILS(string Action = null, int Project_ID = -1, string STUDYID = null, string INVID = null, string INVNAME = null, string ADDRESS = null, string TELNO = null, string FAXNO = null, string EMAILID = null, string CCEMAILID = null, string DTENTERED = null, string TMENTERED = null, string STATUS = null, string DEACTIVATEDON = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("INVDETAILS_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@STUDYID", STUDYID);
                cmd.Parameters.AddWithValue("@INVID", INVID);
                cmd.Parameters.AddWithValue("@INVNAME", INVNAME);
                cmd.Parameters.AddWithValue("@ADDRESS", ADDRESS);
                cmd.Parameters.AddWithValue("@TELNO", TELNO);
                cmd.Parameters.AddWithValue("@FAXNO", FAXNO);
                cmd.Parameters.AddWithValue("@EMAILID", EMAILID);
                cmd.Parameters.AddWithValue("@CCEMAILID", CCEMAILID);
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                cmd.Parameters.AddWithValue("@STATUS", STATUS);
                cmd.Parameters.AddWithValue("@DEACTIVATEDON", DEACTIVATEDON);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }
        //GET SET PAGE DEATILS
        public DataSet GetSetPAGEDETAILS(string Action = null, int Project_ID = -1, string STUDYID = null, string VISITNUM = null, string PAGENUM = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("PAGEDETAILS_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@STUDYID", STUDYID);
                cmd.Parameters.AddWithValue("@VISITNUM", VISITNUM);
                cmd.Parameters.AddWithValue("@PAGENUM", PAGENUM);
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }
        //GET SET PROJECT DEATILS
        public DataSet GetSetPROJECTDETAILS(string Action = null, int Project_ID = -1, string STUDYID = null, string PROJNAME = null, string SPONSOR = null, string PROJSTDAT = null, string PROJDUR = null, string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("PROJDETAILS_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@Project_ID", Project_ID);
                cmd.Parameters.AddWithValue("@STUDYID", STUDYID);
                cmd.Parameters.AddWithValue("@PROJNAME", PROJNAME);
                cmd.Parameters.AddWithValue("@SPONSOR", SPONSOR);
                if (PROJSTDAT != "")
                {
                    cmd.Parameters.AddWithValue("@PROJSTDAT", PROJSTDAT);
                }
                cmd.Parameters.AddWithValue("@PROJDUR", PROJDUR);
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
                adp = null;
            }
            return ds;
        }
        //Get Query Data
        public DataSet GetRecordsQueryDetails(string Action=null, string PVID=null, int ID=0, string Inv_Comments=null, string Reason=null, string Cdm_Comments=null,int RECID=0)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                //Get Data for Update
                cmd = new SqlCommand("QUERYDETAILS_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@INV_COMMENTS", Inv_Comments);
                cmd.Parameters.AddWithValue("@REASON", Reason);
                cmd.Parameters.AddWithValue("@CDM_COMMENTS", Cdm_Comments);
                cmd.Parameters.AddWithValue("@RECID", RECID);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }
        //Get Query Reports
        public DataSet GetQueryReports(String Action, String InvId, string SubjId, string VisitNumber, string Page, string Module, string Field, string QueryStatus, string QueryType = null)
        {

            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                //Get Data for Update
                cmd = new SqlCommand("Get_Query_Reports", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@INVID", InvId);
                cmd.Parameters.AddWithValue("@SUBJID", SubjId);
                cmd.Parameters.AddWithValue("@VISITNUM", VisitNumber);
                cmd.Parameters.AddWithValue("@PAGENUM", Page);
                cmd.Parameters.AddWithValue("@MODULENAME", Module);
                cmd.Parameters.AddWithValue("@FIELDNAME", Field);
                cmd.Parameters.AddWithValue("@QUERYSTATUS", QueryStatus);
                cmd.Parameters.AddWithValue("@QUERYTYPE", QueryType);

                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }

        // Get Freeze Data
        public DataSet Get_Freeze_Data(String Action, String InvId, string SubjId, string VisitNumber, string Page, string EnteredBy)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                //Get Data for Update
                cmd = new SqlCommand("Get_Freeze_Data", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@INVID", InvId);
                cmd.Parameters.AddWithValue("@SUBJID", SubjId);
                cmd.Parameters.AddWithValue("@VISITNUM", VisitNumber);
                cmd.Parameters.AddWithValue("@PAGENUM", Page);
                cmd.Parameters.AddWithValue("@EnteredBy", EnteredBy);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }
        // Get Data Lock / Un Lock
        public DataSet Get_Lock_Unlock_Data(String Action, String InvId, string SubjId, string VisitNumber, string Page, string EnteredBy)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                //Get Data for Update
                cmd = new SqlCommand("Get_Data_Lock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@INVID", InvId);
                cmd.Parameters.AddWithValue("@SUBJID", SubjId);
                cmd.Parameters.AddWithValue("@VISITNUM", VisitNumber);
                cmd.Parameters.AddWithValue("@PAGENUM", Page);
                cmd.Parameters.AddWithValue("@EnteredBy", EnteredBy);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }

        //Fill Module And Field Names
        public DataSet Get_Module_Field(String Action, String ModuleName)
        {

            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                //Get Data for Update
                cmd = new SqlCommand("Get_Act_DeAct_Rules", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }

        //Get Active and Deactive Proc Name
        public DataSet Get_Act_DeAct_Rules(String Action, string ActiveYN, string ModuleName,
            string FieldName, string ProcName)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                //Get Data for Update
                cmd = new SqlCommand("Get_Act_DeAct_Rules", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@Active", ActiveYN);
                cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
                cmd.Parameters.AddWithValue("@FieldName", FieldName);
                cmd.Parameters.AddWithValue("@ProcName", ProcName);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }

        //Get Data
        public DataSet GetRecordOpenCRF(string strCMD = null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                //Get Data for Update
                cmd = new SqlCommand(strCMD, con);
                cmd.CommandType = CommandType.Text;
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }

        public DataSet GetPAGEINFO(string PVID = null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                //Get Data
                cmd = new SqlCommand("Get_PAGESTATUS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PVID", PVID);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ////ds.Dispose();
            }
            return ds; ;
        }

        //Get PAGESTATUS
        public string GetPAGESTATUS(string PVID = null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            string PAGESTATUS;
            PAGESTATUS = "0";
            try
            {
                //Get Data
                cmd = new SqlCommand("Get_PAGESTATUS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PVID", PVID);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    PAGESTATUS = "0";
                }
                else
                {
                    PAGESTATUS = ds.Tables[0].Rows[0]["PAGESTATUS"].ToString();
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ////ds.Dispose();
            }
            return PAGESTATUS;
        }
        //To Check If Record Present
        public bool isRecordPresent(string PVID = null, string TABLENAME = null, int VISITNUM = -1)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            bool RecordRecordPresent;
            RecordRecordPresent = false;
            try
            {
                //Get Data
                cmd = new SqlCommand("isRecordPresent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@TABLENAME", TABLENAME);
                cmd.Parameters.AddWithValue("@VISITNUM", VISITNUM);

                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                if (ds.Tables[0].Rows[0]["COUNT"].ToString() == "0")
                {
                    RecordRecordPresent = false;
                }
                else
                {
                    RecordRecordPresent = true;
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ////ds.Dispose();
            }
            return RecordRecordPresent;
        }
        //Excute FED on the basis of module name and subjid on save complete 
        public void ExecuteProc(String SUBJID = null, string TableName = null)
        {
            SqlCommand cmd;
            try
            {                
                cmd = new SqlCommand("EXEC_PROC", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SUBJID", SUBJID);
                cmd.Parameters.AddWithValue("@TableName", TableName);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }
        public DataTable AddNewRowToGridInvDetails(GridView Grd)
        {
            //Table Structure
            DataRow drCurrentRow = null;
            DataTable dtCurrentTable;
            int rowIndex = 0;
            int StudyId =0;
            int i;
            dtCurrentTable = new DataTable();
            dtCurrentTable.Columns.Add(new DataColumn("STUDYID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("INVID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("INVNAME", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("ADDRESS", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("TELNO", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("FAXNO", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("EMAILID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("CCEMAILID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("STATUS", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("DEACTIVATEDON", typeof(string)));

            dtCurrentTable.Columns.Add(new DataColumn("UPDATE_FLAG", typeof(string)));

            if (Grd.Rows.Count > 0)
            {
                for (i = 0; i < Grd.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["STUDYID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("STUDYID")).Text;
                    drCurrentRow["INVID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("INVID")).Text;
                    drCurrentRow["INVNAME"] = ((TextBox)Grd.Rows[rowIndex].FindControl("INVNAME")).Text;
                    drCurrentRow["ADDRESS"] = ((TextBox)Grd.Rows[rowIndex].FindControl("ADDRESS")).Text;
                    drCurrentRow["TELNO"] = ((TextBox)Grd.Rows[rowIndex].FindControl("TELNO")).Text;
                    drCurrentRow["FAXNO"] = ((TextBox)Grd.Rows[rowIndex].FindControl("FAXNO")).Text;
                    drCurrentRow["EMAILID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("EMAILID")).Text;
                    drCurrentRow["CCEMAILID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("CCEMAILID")).Text;
                    drCurrentRow["STATUS"] = ((TextBox)Grd.Rows[rowIndex].FindControl("STATUS")).Text;
                    drCurrentRow["DEACTIVATEDON"] = ((TextBox)Grd.Rows[rowIndex].FindControl("DEACTIVATEDON")).Text;

                    drCurrentRow["UPDATE_FLAG"] = ((TextBox)Grd.Rows[rowIndex].FindControl("UPDATE_FLAG")).Text;

                    StudyId = Convert.ToInt32( ((TextBox)Grd.Rows[rowIndex].FindControl("STUDYID")).Text);
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    rowIndex++;
                }

                //Add Empty Row
                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow = dtCurrentTable.NewRow();

                drCurrentRow["STUDYID"] = StudyId;
                drCurrentRow["INVID"] = "";
                drCurrentRow["INVNAME"] = string.Empty;
                drCurrentRow["ADDRESS"] = string.Empty;
                drCurrentRow["TELNO"] = string.Empty;
                drCurrentRow["FAXNO"] = string.Empty;
                drCurrentRow["EMAILID"] = string.Empty;
                drCurrentRow["CCEMAILID"] = string.Empty;
                drCurrentRow["STATUS"] = string.Empty;
                drCurrentRow["DEACTIVATEDON"] = string.Empty;

                drCurrentRow["UPDATE_FLAG"] = "0";
                dtCurrentTable.Rows.Add(drCurrentRow);
            }

            return dtCurrentTable;

        }
        public DataTable AddNewRowToGridVisitDetails(GridView Grd)
        {
            //Table Structure
            DataRow drCurrentRow = null;
            DataTable dtCurrentTable;
            int rowIndex = 0;
            int i;
            dtCurrentTable = new DataTable();
            dtCurrentTable.Columns.Add(new DataColumn("STUDYID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("VISITNUM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("VISIT", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("UPDATE_FLAG", typeof(string)));

            if (Grd.Rows.Count > 0)
            {
                for (i = 0; i < Grd.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["STUDYID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("STUDYID")).Text;
                    drCurrentRow["VISITNUM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("VISITNUM")).Text;
                    drCurrentRow["VISIT"] = ((TextBox)Grd.Rows[rowIndex].FindControl("VISIT")).Text;
                    drCurrentRow["UPDATE_FLAG"] = ((TextBox)Grd.Rows[rowIndex].FindControl("UPDATE_FLAG")).Text;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    rowIndex++;
                }

                //Add Empty Row
                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow = dtCurrentTable.NewRow();

                drCurrentRow["STUDYID"] = "";
                drCurrentRow["VISITNUM"] = "";
                drCurrentRow["VISIT"] = string.Empty;
                drCurrentRow["UPDATE_FLAG"] = "0";
                dtCurrentTable.Rows.Add(drCurrentRow);
            }

            return dtCurrentTable;

        }
        public DataTable AddNewRowToGridPageDetails(GridView Grd)
        {
            //Table Structure
            DataRow drCurrentRow = null;
            DataTable dtCurrentTable;
            int rowIndex = 0;
            int i;
            dtCurrentTable = new DataTable();
            dtCurrentTable.Columns.Add(new DataColumn("STUDYID", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("VISITNUM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("PAGENUM", typeof(string)));
            dtCurrentTable.Columns.Add(new DataColumn("UPDATE_FLAG", typeof(string)));

            if (Grd.Rows.Count > 0)
            {
                for (i = 0; i < Grd.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["STUDYID"] = ((TextBox)Grd.Rows[rowIndex].FindControl("STUDYID")).Text;
                    drCurrentRow["VISITNUM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("VISITNUM")).Text;
                    drCurrentRow["PAGENUM"] = ((TextBox)Grd.Rows[rowIndex].FindControl("PAGENUM")).Text;
                    drCurrentRow["UPDATE_FLAG"] = ((TextBox)Grd.Rows[rowIndex].FindControl("UPDATE_FLAG")).Text;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    rowIndex++;
                }

                //Add Empty Row
                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow = dtCurrentTable.NewRow();

                drCurrentRow["STUDYID"] = "";
                drCurrentRow["VISITNUM"] = "";
                drCurrentRow["PAGENUM"] = string.Empty;
                drCurrentRow["UPDATE_FLAG"] = "0";
                dtCurrentTable.Rows.Add(drCurrentRow);
            }
            return dtCurrentTable;
        }

        //Get set SDV DETAILS
        public DataSet GetSetSDVDETAILS(string Action, string PVID = null, int CONTID = 0, string TABLENAME = null, string VARIABLENAME = null, bool SDVYN = false, string ENTEREDBY = null,int RECID=0)
        {

            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                //Get Data for Update
                cmd = new SqlCommand("SDVDETAILS_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@CONTID", CONTID);
                cmd.Parameters.AddWithValue("@TABLENAME", TABLENAME);
                cmd.Parameters.AddWithValue("@VARIABLENAME", VARIABLENAME);
                cmd.Parameters.AddWithValue("@SDVYN", SDVYN);
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                cmd.Parameters.AddWithValue("@RECID", RECID);

                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }

        //Get AUDITTRAIL DETAILS
        public DataSet GetAUDITTRAILDETAILS(string Action, string PVID = null, int CONTID = 0, string TABLENAME = null, string VARIABLENAME = null, int RECID =0)
        {

            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {

                cmd = new SqlCommand("AUDITTRAIL_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@CONTID", CONTID);
                cmd.Parameters.AddWithValue("@TABLENAME", TABLENAME);
                cmd.Parameters.AddWithValue("@VARIABLENAME", VARIABLENAME);
                cmd.Parameters.AddWithValue("@RECID", RECID);

                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }

        //Get FIELD COMMENTS DETAILS
        public DataSet GetFieldComments(String Action, String PVID = null, int CONTID = 0, string TABLENAME = null, string FIELDNAME = null, string VARIABLENAME = null, string COMMENTS = null, string ENTEREDBY = null,int RECID=0)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                cmd = new SqlCommand("COMMENTSDETAILS_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@CONTID", CONTID);
                cmd.Parameters.AddWithValue("@TABLENAME", TABLENAME);
                cmd.Parameters.AddWithValue("@FIELDNAME", FIELDNAME);
                cmd.Parameters.AddWithValue("@VARIABLENAME", VARIABLENAME);
                cmd.Parameters.AddWithValue("@COMMENTS", COMMENTS);
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);
                cmd.Parameters.AddWithValue("@RECID", RECID);


                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }

        //Set MANUAL QUERY
        public DataSet SetManualQuery(String Action, String PVID = null, int CONTID = 0, String QID = null, String SUBJID = null, String QUERYTEXT = null, String MODULENAME = null, String FIELDNAME = null, string TABLENAME = null, string VARIABLENAME = null, string ENTEREDBY = null,int RECID=0)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                cmd = new SqlCommand("Manual_Query_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@PVID", PVID);
                cmd.Parameters.AddWithValue("@CONTID", CONTID);
                cmd.Parameters.AddWithValue("@RECID", RECID);
                cmd.Parameters.AddWithValue("@QID", QID);
                cmd.Parameters.AddWithValue("@SUBJID", SUBJID);
                cmd.Parameters.AddWithValue("@QUERYTEXT", QUERYTEXT);
                cmd.Parameters.AddWithValue("@MODULENAME", MODULENAME);
                cmd.Parameters.AddWithValue("@FIELDNAME", FIELDNAME);
                cmd.Parameters.AddWithValue("@TABLENAME", TABLENAME);
                cmd.Parameters.AddWithValue("@VARIABLENAME", VARIABLENAME);
                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);

                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }




        // Get Freeze Data
        public DataSet CommonSP_Execution(String SPName = null, String Action = null, String InvId = null, string SubjId = null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                cmd = new SqlCommand(SPName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@INVID", InvId);
                cmd.Parameters.AddWithValue("@SUBJID", SubjId);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //ds.Dispose();
            }
            return ds;
        }
        #endregion Master Datalayer end


        public DataSet InsertUpdatePPT(string Action = null, string Project_ID = null, string @INVID = null,
            string SUBJID = null, string CONSENT_DATE = null, string GENDER = null,
            string DOB = null,string VISITNUM = null, string ACTUAL_DATE = null,
            string IS_ARRIVE =null, string ET_DATE =null,
            string IS_ELIGIBLE = null,
            string REAS_ELIGIBLE = null,string REAS_ELIGIBLE_OTHER =null,
            string SUB_WITHDRAW = null, string REAS_WITHDRAW = null,string REAS_WITHDRAW_OTHER=null, string FROM_SCH_DT = null,
            string TO_SCH_DT = null, string COMPARE_VISIT = null, string WIN_FROM = null, string WIN_TO = null, string DELEGATEYN = null,
            string ENTEREDBY = null)
        {
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("[INSERTUPDATE_SP]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@Project_ID", Project_ID);
                cmd.Parameters.AddWithValue("@INVID", INVID);
                cmd.Parameters.AddWithValue("@SUBJID", SUBJID);
                cmd.Parameters.AddWithValue("@CONSENT_DATE",CONSENT_DATE);
                cmd.Parameters.AddWithValue("@GENDER", GENDER);
                cmd.Parameters.AddWithValue("@DOB", DOB);

                cmd.Parameters.AddWithValue("@VISITNUM", VISITNUM);

                if (ACTUAL_DATE != "")
                {
                    cmd.Parameters.AddWithValue("@ACTUAL_DATE", ACTUAL_DATE);
                }               
                if (IS_ELIGIBLE != null)
                {
                    cmd.Parameters.AddWithValue("@IS_ELIGIBLE", IS_ELIGIBLE);
                }           
                if (REAS_ELIGIBLE_OTHER != null)
                {
                    cmd.Parameters.AddWithValue("@REAS_ELIGIBLE_OTHER", REAS_ELIGIBLE_OTHER);
                }           
                if (SUB_WITHDRAW != null)
                {
                    cmd.Parameters.AddWithValue("@SUB_WITHDRAW", SUB_WITHDRAW);
                }              
                if (REAS_WITHDRAW_OTHER != null)
                {
                    cmd.Parameters.AddWithValue("@REAS_WITHDRAW_OTHER", REAS_WITHDRAW_OTHER);
                }

                if (ET_DATE != "")
                {
                    cmd.Parameters.AddWithValue("@ET_DATE", ET_DATE);
                }
                if (IS_ARRIVE != null)
                {
                    cmd.Parameters.AddWithValue("@IS_ARRIVE", IS_ARRIVE);
                }
             
                cmd.Parameters.AddWithValue("@REAS_ELIGIBLE", REAS_ELIGIBLE);
                cmd.Parameters.AddWithValue("@REAS_WITHDRAW", REAS_WITHDRAW);

                cmd.Parameters.AddWithValue("@FROM_SCH_DT", FROM_SCH_DT);
                cmd.Parameters.AddWithValue("@TO_SCH_DT", TO_SCH_DT);
                cmd.Parameters.AddWithValue("@COMPARE_VISIT", COMPARE_VISIT);
                cmd.Parameters.AddWithValue("@WIN_FROM", WIN_FROM);
                cmd.Parameters.AddWithValue("@WIN_TO", WIN_TO);
                cmd.Parameters.AddWithValue("@DELEGATEYN", DELEGATEYN);


                cmd.Parameters.AddWithValue("@ENTEREDBY", ENTEREDBY);

                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
            return ds;
        }


        public DataSet Get_Email_ID(string Action = null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                cmd = new SqlCommand("Get_Email_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);

                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
            return ds;
        }

        //Getting User Credentails and Lock/Unlock Status

        public DataSet Get_LockUnlock(string Action = null,string User_Name=null)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd;
            SqlDataAdapter adp;
            try
            {
                cmd = new SqlCommand("[Get_User_Credentails]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@User_Name", User_Name);

                con.Open();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
            return ds;
        }
    }
}
