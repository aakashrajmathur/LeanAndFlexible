﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace NewHorizons
{
    internal class DataImport
    {
        public DataImport()
        {
        }

        public Study ImportFromCSVFile(string filePath)
        {
            Study study = new Study();

            PopulateMachines(filePath, study);
            PopulateParts(filePath, study);
            //study.ComputeDefaultSelections();

            return study;
        }

        private void PopulateMachines(string filePath, Study study)
        {
            int counter = 0;
            string line;

            HashSet<string> machines = new HashSet<string>();
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    if (counter > 0)
                    {
                        string[] tokens = line.Split(',');
                        string[] machineTokens = tokens[4].Split(new string[] { "->" }, StringSplitOptions.None);

                        foreach (String s in machineTokens)
                        {
                            machines.Add(s);
                        }
                    }

                    counter++;
                }
                file.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace.ToString());
            }
            ///////////////////////
            foreach (String s in machines)
            {
                study.machines.Add(new Machine(s));
            }

        }

        private void PopulateParts(string filePath, Study study)
        {
            int counter = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                if (counter > 0)
                {
                    Part part = new Part();

                    string[] tokens = line.Split(',');
                    part.name = tokens[1];
                    part.quantity = Convert.ToSingle(tokens[2]);
                    part.revenue = Convert.ToSingle(tokens[3]);

                    string[] machineTokens = tokens[4].Split(new string[] { "->" }, StringSplitOptions.None);

                    foreach (String s in machineTokens)
                    {
                        Machine currentMachine = GetMachineFromExistingListInStudy(s, study);
                        if (currentMachine != null)
                        {
                            part.routing.Add(currentMachine);
                        }
                    }

                    study.parts.Add(part);
                }
                counter++;
            }
        }

        Machine GetMachineFromExistingListInStudy(string machineName, Study study)
        {
            foreach (Machine m in study.machines)
            {
                if (m.name.CompareTo(machineName) == 0)
                {
                    return m;
                }
            }
            return null;
        }

        /////Excel import: PFAST import: 

        Dictionary<String, Machine> machineMap;

        public Study ImportFromExcelFile(string filePath)
        {
            Study study = new Study();

            machineMap = new Dictionary<string, Machine>();

            string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";" +
                           @"Extended Properties='Excel 8.0;HDR=Yes;'";

            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                
                //Read machines: 
                OleDbCommand command = new OleDbCommand("select * from [Workcenter$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var dataCol0 = dr[0];
                        Console.WriteLine(dataCol0);

                        var dataCol1 = dr[1];
                        Console.WriteLine(dataCol1);

                        Machine machine = new Machine(dataCol1.ToString());
                        machineMap.Add(dataCol0.ToString(), machine);
                        study.machines.Add(machine);
                    }
                }

                //Read parts: 
                command = new OleDbCommand("select * from [Part$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var dataCol0 = dr[0];   //Part No
                        Console.WriteLine(dataCol0);

                        var dataCol1 = dr[1];   //Name
                        Console.WriteLine(dataCol1);

                        var dataCol2 = dr[2];   //Quantity 
                        Console.WriteLine(dataCol2);
                        float quantity = float.Parse(dataCol2.ToString());

                        var dataCol3 = dr[3];   //Revenue
                        Console.WriteLine(dataCol3);
                        float revenue = float.Parse(dataCol3.ToString());

                        List<Machine> routing = GetRouting(dataCol0.ToString(), connection);
                        study.parts.Add(new Part(dataCol0.ToString(), quantity, revenue, routing));
                    }
                }
            }
            return study;
        }

        private List<Machine> GetRouting(string partNo, OleDbConnection connection)
        {
            List<Machine> routing = new List<Machine>();
            OleDbCommand command = new OleDbCommand("select * from [Routing$]", connection);
            using (OleDbDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dataCol0 = dr[0];   //Part no
                    Console.WriteLine(dataCol0);
                    if (dataCol0.ToString().CompareTo(partNo) == 0)
                    {
                        var dataCol1 = dr[1];   //Machine no
                        Console.WriteLine(dataCol1);
                        routing.Add(machineMap[dataCol1.ToString()]);
                    }
                }
            }
            return routing;
        }


        private void readExcel(string filePath)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;";
            strConn += "Data Source= " + filePath + "; Extended Properties='Excel 8.0;HDR=No;IMEX=1'";
            OleDbConnection ObjConn = new OleDbConnection(strConn);
            ObjConn.Open();
            string strSheetName = getSheetName(ObjConn);
            OleDbCommand ObjCmd = new OleDbCommand("SELECT * FROM [" + strSheetName + "]", ObjConn);
            OleDbDataAdapter objDA = new OleDbDataAdapter();
            objDA.SelectCommand = ObjCmd;
            DataSet ObjDataSet = new DataSet();
            objDA.Fill(ObjDataSet);
            ObjConn.Close();
            //return ObjDataSet;
        }

        private string getSheetName(OleDbConnection ObjConn)
        {
            string strSheetName = String.Empty;
            try
            {
                System.Data.DataTable dtSheetNames = ObjConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dtSheetNames.Rows.Count > 0)
                {
                    strSheetName = dtSheetNames.Rows[0]["TABLE_NAME"].ToString();
                }
                return strSheetName;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get the sheet name", ex);
            }
        }
        //var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
        //using (var conn = new OleDbConnection(connectionString))
        //{
        //    conn.Open();

        //    var sheets = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
        //    using (var cmd = conn.CreateCommand())
        //    {
        //        cmd.CommandText = "SELECT * FROM [" + sheets.Rows[0]["TABLE_NAME"].ToString() + "] ";

        //        var adapter = new OleDbDataAdapter(cmd);
        //        var ds = new DataSet();
        //        adapter.Fill(ds);
        //    }
        //}
        //return null;
        //}
        //public Study ImportFromExcelFile(string filePath)
        //{
        //    //
        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;
        //    Excel.Range range;

        //    string str;
        //    int rCnt = 0;
        //    int cCnt = 0;

        //    xlApp = new Excel.Application();

        //    xlWorkBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        //    range = xlWorkSheet.UsedRange;

        //    for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
        //    {
        //        for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
        //        {
        //            str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
        //            MessageBox.Show(str);
        //        }
        //    }

        //    xlWorkBook.Close(true, null, null);
        //    xlApp.Quit();

        //    releaseObject(xlWorkSheet);
        //    releaseObject(xlWorkBook);
        //    releaseObject(xlApp);

        //    return null;
        //}

        //private void releaseObject(object obj)
        //{
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        //        obj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        obj = null;
        //        MessageBox.Show("Unable to release the Object " + ex.ToString());
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}
    }
}