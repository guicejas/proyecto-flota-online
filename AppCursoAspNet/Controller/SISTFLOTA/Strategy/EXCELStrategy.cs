using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Xml;
using CarlosAg.ExcelXmlWriter;
using Controladora;

namespace Controladora.SISTFLOTA.Strategy
{
    public class EXCELStrategy : IStrategy
    {
        Controladora.ControladoraGastos ctrlGastos = new Controladora.ControladoraGastos();

        public string GenerarReporteGastos()
        {
            string filename = @"C:\Program Files (x86)\IIS Express\Reportexcel.xml";
            Workbook book = new Workbook();
            // -----------------------------------------------
            //  Properties
            // -----------------------------------------------
            book.Properties.Author = "Trypep Sistemas";
            book.Properties.LastAuthor = "Trypep Sistemas";
            book.Properties.Created = new System.DateTime(2014, 7, 8, 14, 25, 6, 0);
            book.Properties.Version = "14.00";
            book.ExcelWorkbook.WindowHeight = 7470;
            book.ExcelWorkbook.WindowWidth = 16035;
            book.ExcelWorkbook.WindowTopX = 480;
            book.ExcelWorkbook.WindowTopY = 330;
            book.ExcelWorkbook.ProtectWindows = false;
            book.ExcelWorkbook.ProtectStructure = false;
            // -----------------------------------------------
            //  Generate Styles
            // -----------------------------------------------
            this.GenerateStyles(book.Styles);
            // -----------------------------------------------
            //  Generate Sheet1 Worksheet
            // -----------------------------------------------
            this.GenerateWorksheetSheet1(book.Worksheets);
            // -----------------------------------------------
            //  Generate Sheet2 Worksheet
            // -----------------------------------------------
            this.GenerateWorksheetSheet2(book.Worksheets);
            // -----------------------------------------------
            //  Generate Sheet3 Worksheet
            // -----------------------------------------------
            this.GenerateWorksheetSheet3(book.Worksheets);
            book.Save(filename);

            return "Reportexcel.xml";

        }

        private void GenerateStyles(WorksheetStyleCollection styles)
        {
            // -----------------------------------------------
            //  Default
            // -----------------------------------------------
            WorksheetStyle Default = styles.Add("Default");
            Default.Name = "Normal";
            Default.Font.FontName = "Calibri";
            Default.Font.Size = 11;
            Default.Font.Color = "#000000";
            Default.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s74
            // -----------------------------------------------
            WorksheetStyle s74 = styles.Add("s74");
            s74.Font.Bold = true;
            s74.Font.FontName = "Calibri";
            s74.Font.Size = 12;
            s74.Font.Color = "#000000";
            // -----------------------------------------------
            //  s75
            // -----------------------------------------------
            WorksheetStyle s75 = styles.Add("s75");
            s75.Font.Bold = true;
            s75.Font.FontName = "Calibri";
            s75.Font.Size = 16;
            s75.Font.Color = "#000000";
            // -----------------------------------------------
            //  s76
            // -----------------------------------------------
            WorksheetStyle s76 = styles.Add("s76");
            s76.NumberFormat = "\"$\"#,##0_);[Red]\\(\"$\"#,##0\\)";
            // -----------------------------------------------
            //  s80
            // -----------------------------------------------
            WorksheetStyle s80 = styles.Add("s80");
            s80.Font.Underline = UnderlineStyle.Single;
            s80.Font.FontName = "Calibri";
            s80.Font.Size = 11;
            s80.Font.Color = "#000000";
            s80.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s80.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s81
            // -----------------------------------------------
            WorksheetStyle s81 = styles.Add("s81");
            s81.Font.Italic = true;
            s81.Font.FontName = "Calibri";
            s81.Font.Size = 11;
            s81.Font.Color = "#000000";
            // -----------------------------------------------
            //  s82
            // -----------------------------------------------
            WorksheetStyle s82 = styles.Add("s82");
            s82.Font.Bold = true;
            s82.Font.FontName = "Calibri";
            s82.Font.Size = 11;
            s82.Font.Color = "#000000";
        }

        private void GenerateWorksheetSheet1(WorksheetCollection sheets)
        {
            Worksheet sheet = sheets.Add("Sheet1");
            sheet.Table.DefaultRowHeight = 15F;
            sheet.Table.ExpandedColumnCount = 4;
            sheet.Table.ExpandedRowCount = 999;
            sheet.Table.FullColumns = 1;
            sheet.Table.FullRows = 1;
            sheet.Table.Columns.Add(57);
            sheet.Table.Columns.Add(78);
            sheet.Table.Columns.Add(171);
            sheet.Table.Columns.Add(59);
            // -----------------------------------------------
            WorksheetRow Row0 = sheet.Table.Rows.Add();
            Row0.Height = 21;
            Row0.Cells.Add("SISTEMA GESTION FLOTA DE TAXIS - TRYPEP SISTEMAS - 2014 -", DataType.String, "s75");
            // -----------------------------------------------
            WorksheetRow Row1 = sheet.Table.Rows.Add();
            Row1.Height = 15;
            Row1.Cells.Add("INFORME DE GASTOS POR VEHICULO 8/7/2014", DataType.String, "s74");
            // -----------------------------------------------
            WorksheetRow Row2 = sheet.Table.Rows.Add();
            Row2.Index = 4;
            WorksheetCell cell;
            cell = Row2.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = "VEHICULO ";
            cell = Row2.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = "MODELO";
            cell = Row2.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = "DESCRIPCION GASTO";
            cell = Row2.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = "TOTAL";


             List<Modelo.Vehiculo> oVehiculos = ControladoraVehiculos.getINSTANCIA.ListarVehiculosGastos();


                    for (int i = 0; i < oVehiculos.Count; i++)
                    {
                        int num = i + 3;
                        WorksheetRow Row3 = sheet.Table.Rows.Add();
                        cell = Row3.Cells.Add();
                        cell.Data.Type = DataType.String;
                        cell.Data.Text = oVehiculos[i].Patente.ToString();

                        cell = Row3.Cells.Add();
                        cell.Data.Type = DataType.Number;
                        cell.Data.Text = oVehiculos[i].Año.ToString();

                        List<Modelo.Gasto> oGastos = ctrlGastos.ListarGastosdeVehiculo(oVehiculos[i].Patente);

                        if (oGastos.Count > 0)
                        {
                            cell = Row3.Cells.Add();
                            cell.Data.Type = DataType.String;
                            cell.Data.Text = oGastos[0].Descripcion.ToString();

                            Row3.Cells.Add(oGastos[0].Monto.ToString(), DataType.Number, "s76");

                            for (int j = 1; j < oGastos.Count; j++)
                            {
                                WorksheetRow Row4 = sheet.Table.Rows.Add();

                                cell = Row4.Cells.Add();
                                cell.Data.Type = DataType.String;
                                cell.Data.Text = "";

                                cell = Row4.Cells.Add();
                                cell.Data.Type = DataType.String;
                                cell.Data.Text = "";

                                cell = Row4.Cells.Add();
                                cell.Data.Type = DataType.String;
                                cell.Data.Text = oGastos[j].Descripcion.ToString();

                                Row4.Cells.Add(oGastos[j].Monto.ToString(), DataType.Number, "s76");

                            }


                        }
                        WorksheetRow Row5 = sheet.Table.Rows.Add();
                        cell = Row5.Cells.Add();
                        cell.Data.Type = DataType.String;
                        cell.Data.Text = "";

                        cell = Row5.Cells.Add();
                        cell.Data.Type = DataType.String;
                        cell.Data.Text = "";

                        cell = Row5.Cells.Add();
                        cell.StyleID = "s82";
                        cell.Data.Type = DataType.String;
                        cell.Data.Text = "TOTAL";
                        cell.Index = 3;
                        Row5.Cells.Add(oGastos.Sum(x => x.Monto).ToString(), DataType.Number, "s76");

                        if (i < oVehiculos.Count - 1)
                        {
                            WorksheetRow Row7 = sheet.Table.Rows.Add();
                            cell = Row7.Cells.Add();
                            cell.Data.Type = DataType.String;
                            cell.Data.Text = "";
                            Row7.Cells.Add("", DataType.String, "s76");
                        }
                    }

            // -----------------------------------------------
            WorksheetRow Row8 = sheet.Table.Rows.Add();
            Row8.Cells.Add("Este documento es propiedad de Trypep Sistemas y queda prohibida su reproducción " +
                    "total o parcial.", DataType.String, "s81");
            // -----------------------------------------------
            WorksheetRow Row9 = sheet.Table.Rows.Add();
            Row9.Cells.Add("La información contenida en este documento es confidencial.", DataType.String, "s81");
            // -----------------------------------------------
            //  Options
            // -----------------------------------------------
            sheet.Options.Selected = true;
            sheet.Options.ProtectObjects = false;
            sheet.Options.ProtectScenarios = false;
            sheet.Options.PageSetup.Header.Margin = 0.3F;
            sheet.Options.PageSetup.Footer.Margin = 0.3F;
            sheet.Options.PageSetup.PageMargins.Bottom = 0.75F;
            sheet.Options.PageSetup.PageMargins.Left = 0.7F;
            sheet.Options.PageSetup.PageMargins.Right = 0.7F;
            sheet.Options.PageSetup.PageMargins.Top = 0.75F;
            sheet.Options.Print.PaperSizeIndex = 9;
            sheet.Options.Print.ValidPrinterInfo = true;
        }

        private void GenerateWorksheetSheet2(WorksheetCollection sheets)
        {
            Worksheet sheet = sheets.Add("Sheet2");
            sheet.Table.DefaultRowHeight = 15F;
            sheet.Table.ExpandedColumnCount = 1;
            sheet.Table.ExpandedRowCount = 1;
            sheet.Table.FullColumns = 1;
            sheet.Table.FullRows = 1;
            // -----------------------------------------------
            //  Options
            // -----------------------------------------------
            sheet.Options.ProtectObjects = false;
            sheet.Options.ProtectScenarios = false;
            sheet.Options.PageSetup.Header.Margin = 0.3F;
            sheet.Options.PageSetup.Footer.Margin = 0.3F;
            sheet.Options.PageSetup.PageMargins.Bottom = 0.75F;
            sheet.Options.PageSetup.PageMargins.Left = 0.7F;
            sheet.Options.PageSetup.PageMargins.Right = 0.7F;
            sheet.Options.PageSetup.PageMargins.Top = 0.75F;
        }

        private void GenerateWorksheetSheet3(WorksheetCollection sheets)
        {
            Worksheet sheet = sheets.Add("Sheet3");
            sheet.Table.DefaultRowHeight = 15F;
            sheet.Table.ExpandedColumnCount = 1;
            sheet.Table.ExpandedRowCount = 1;
            sheet.Table.FullColumns = 1;
            sheet.Table.FullRows = 1;
            // -----------------------------------------------
            //  Options
            // -----------------------------------------------
            sheet.Options.ProtectObjects = false;
            sheet.Options.ProtectScenarios = false;
            sheet.Options.PageSetup.Header.Margin = 0.3F;
            sheet.Options.PageSetup.Footer.Margin = 0.3F;
            sheet.Options.PageSetup.PageMargins.Bottom = 0.75F;
            sheet.Options.PageSetup.PageMargins.Left = 0.7F;
            sheet.Options.PageSetup.PageMargins.Right = 0.7F;
            sheet.Options.PageSetup.PageMargins.Top = 0.75F;
        }



        public void GenerarReporteVehiculosActivos()
        {
            /*
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();

            ExcelApp.Application.Workbooks.Add(Type.Missing);

            ExcelApp.Columns.ColumnWidth = 20;
            

            for (int i = 1; i < dgvDatos.Columns.Count + 1; i++)
            {

                ExcelApp.Cells[1, i] = dgvDatos.Columns[i - 1].HeaderText;

            }
            for (int i = 0; i < dgvDatos.Rows.Count; i++)
            {

                for (int j = 0; j < dgvDatos.Columns.Count; j++)
                {

                    ExcelApp.Cells[i + 2, j + 1] = dgvDatos.Rows[i].Cells[j].Value.ToString();

                }

            }

            ExcelApp.ActiveWorkbook.SaveCopyAs("test.xls");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.ActiveWorkbook.WebPagePreview();

            ExcelApp.Quit();
            */
        }


    
    }
}
